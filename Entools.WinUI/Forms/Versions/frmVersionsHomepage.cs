using Entools.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entools.WinUI.Forms.Versions
{
    public partial class frmVersionsHomepage : Form
    {
        private readonly APIService _apiService = new APIService("Parts");
        private readonly APIService _apiServicePreview = new APIService("Parts/preview");
        private readonly APIService _apiServiceVersion = new APIService("Version");
        protected Model.Parts selectedPart;
        protected List<PartVersionsVM> selectedPartVersions;

        public frmVersionsHomepage()
        {
            InitializeComponent();
        }

        private async void frmVersionsHomepage_Load(object sender, EventArgs e)
        {

            var items = await _apiService.Get<List<Model.Parts>>();
            items.Insert(0, new Model.Parts()
            {
                Name = "Izaberi komad"
            });

            cmbParts.ValueMember = "Id";
            cmbParts.DisplayMember = "Name";

            cmbParts.DataSource = items;
        }

        private async void cmbParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(int.Parse(cmbParts.SelectedValue.ToString()) > 0)
            {
                selectedPart = await _apiService.GetById<Model.Parts>(int.Parse(cmbParts.SelectedValue.ToString()));
                pictureBox1.ImageLocation = selectedPart.ImagePath;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                selectedPartVersions = await _apiServicePreview.GetById<List<PartVersionsVM>>(selectedPart.Id);

                if (dataGridView1.Columns.Contains("btnGetGCode"))
                    dataGridView1.Columns.Remove(dataGridView1.Columns["btnGetGCode"]);
                if (dataGridView1.Columns.Contains("btnDetalji"))
                    dataGridView1.Columns.Remove(dataGridView1.Columns["btnDetalji"]);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = selectedPartVersions;

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[5].Visible = false;

                DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                bcol.HeaderText = "Akcija";
                bcol.Text = "Preuzmi GCode";
                bcol.Name = "btnGetGCode";

                DataGridViewButtonColumn details = new DataGridViewButtonColumn();
                details.HeaderText = "Akcija";
                details.Text = "Detalji";
                details.Name = "btnDetalji";


                bcol.UseColumnTextForButtonValue = true;
                details.UseColumnTextForButtonValue = true;
                if (!dataGridView1.Columns.Contains("btnGetGCode"))
                    dataGridView1.Columns.Add(bcol);
                if (!dataGridView1.Columns.Contains("btnDetalji"))
                    dataGridView1.Columns.Add(details);
            }

        }

        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 7)
                {
                    if(selectedPartVersions[e.RowIndex].GCodePath != null && selectedPartVersions[e.RowIndex].GCodePath.Length > 0)
                    {
                        try
                        {
                            File.Copy(selectedPartVersions[e.RowIndex].GCodePath, Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory) +@"\" + selectedPartVersions[e.RowIndex].Name +".txt",true);
                            MessageBox.Show("GCode uspjesno generisan na Desktop!");
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        
                    }
                    else
                        MessageBox.Show("Ova verzija nema GCode");
                }
                if(e.ColumnIndex == 8)
                {
                    var version = await _apiServiceVersion.GetById<Model.Versions>(dataGridView1[0, e.RowIndex].Value.ToString());
                    frmNewVersion frm = new frmNewVersion(version, true);
                    frm.ShowDialog();
                }
            }
        }

        private async void btnNewVersion_Click(object sender, EventArgs e)
        {
            if (cmbParts.SelectedIndex == 0)
                errorProvider1.SetError(cmbParts, "Izaberite komad!");
            else
            {
                errorProvider1.Clear();
                PartVersionsVM defaultVer = null;
                foreach (var item in selectedPartVersions)
                {
                    if (item.Name.StartsWith("Default"))
                    {
                        defaultVer = item;
                    }
                }
                var defaultVersion = await _apiServiceVersion.GetById<Model.Versions>(defaultVer.VersionId);
                frmNewVersion frm = new frmNewVersion(defaultVersion, false);
                frm.ShowDialog();
            }

        }
    }
}
