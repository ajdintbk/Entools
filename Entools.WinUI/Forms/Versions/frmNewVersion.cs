using Entools.Model.Requests.Versions;
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
    public partial class frmNewVersion : Form
    {
        protected Model.Versions dv;
        private float result;
        private bool details = false;
        private string gcodePath = "";
        private readonly APIService _apiService = new APIService("Version");

        public frmNewVersion()
        {
            InitializeComponent();
        }
        public frmNewVersion(Model.Versions defaultver, bool details) : this()
        {
            dv = defaultver;
            this.details = details;
        }

        private void frmNewVersion_Load(object sender, EventArgs e)
        {
            gbDetalji.Visible = false;
            groupBox2.Visible = false;
            if (details)
            {
                groupBox2.Visible = true;
                lblVersionName.Text = "Detalji verzije " + dv.Name;
                lblDescription.Text = "Prikazane vrijednosti su preuzete od verzije " + dv.Name + " komada";
                gbDetalji.Visible = true;
                lblDatum.Text = dv.DateCreated.ToString("dd/MM/yyyy");
                lblKreirao.Text = dv.CreatedBy;
                if(dv.GCodePath != null && dv.GCodePath.Length > 0)
                {
                    groupBox2.Visible = false;
                    gbGcodeExist.Visible = true;
                }
            }
            pictureBox1.ImageLocation = "/Images/prvikomadfront.jpg";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            pbBottom.ImageLocation = "/Images/prvikomadbottom.jpg";
            pbBottom.SizeMode = PictureBoxSizeMode.StretchImage;

            if (dv == null)
                return;

            d1sketch1.Text = dv.D1Sketch1.ToString();
            d2sketch1.Text = dv.D2Sketch1.ToString();
            d1sketch2.Text = dv.D1Sketch2.ToString();
            d5sketch2.Text = dv.D5Sketch2.ToString();
            d6sketch2.Text = dv.D6Sketch2.ToString();
            d7sketch2.Text = dv.D7Sketch2.ToString();
            d9sketch2.Text = dv.D9Sketch2.ToString();
            d10sketch2.Text = dv.D10Sketch2.ToString();
            d11sketch2.Text = dv.D11Sketch2.ToString();
            d12sketch2.Text = dv.D12Sketch2.ToString();
            d8sketch2.Text = dv.D8Sketch2.ToString();
            d14sketch2.Text = dv.D14Sketch2.ToString();
            d15sketch2.Text = dv.D15Sketch2.ToString();
            d4sketch2.Text = dv.D4Sketch2.ToString();
            d16sketch2.Text = dv.D16Sketch2.ToString();
            d17sketch2.Text = dv.D17Sketch2.ToString();
            d21sketch2.Text = dv.D21Sketch2.ToString();
            d1sketch3.Text = dv.D1Sketch3.ToString();
            d2sketch3.Text = dv.D2Sketch3.ToString();
            d3sketch3.Text = dv.D3Sketch3.ToString();
            d4sketch3.Text = dv.D4Sketch3.ToString();
            d5sketch3.Text = dv.D5Sketch3.ToString();
            d7sketch3.Text = dv.D7Sketch3.ToString();
            d8sketch3.Text = dv.D8Sketch3.ToString();
            d9sketch3.Text = dv.D9Sketch3.ToString();
            d10sketch3.Text = dv.D10Sketch3.ToString();
            d2sketch4.Text = dv.D2Sketch4.ToString();
            d3sketch4.Text = dv.D3Sketch4.ToString();
            d2sketch5.Text = dv.D2Sketch5.ToString();
            d3sketch5.Text = dv.D3Sketch5.ToString();
            d1sketch5.Text = dv.D1Sketch5.ToString();
            d1bossextrude1.Text = dv.D1BossExtrude1.ToString();
            d1bossextrude2.Text = dv.D1BossExtrude2.ToString();
            d1cutextrude1.Text = dv.D1CutExtrude1.ToString();
            d1cutextrude2.Text = dv.D1CutExtrude2.ToString();

        }
        private async Task<bool> SaveVersion()
        {
            foreach (TabPage t in tabControl1.TabPages)
            {
                foreach (Control x in t.Controls)
                {
                    if(x is TextBox)
                    {
                        if (string.IsNullOrEmpty(((TextBox)x).Text) || !float.TryParse(((TextBox)x).Text, out result))
                        {
                            errorProvider1.SetError(x, "Vrijednost nije ispravna!");
                            return false;
                        }
                        else
                            errorProvider1.Clear();
                    }
                }
            }


            if (string.IsNullOrEmpty(txtVersionName.Text))
            {
                errorProvider1.SetError(txtVersionName, "Naziv verzije je obavezan!");
                return false; ;
            }
            else
                errorProvider1.Clear();

            try
            {
                var newVersion = new VersionInsertUpdateRequest()
                {
                    D1Sketch1 = float.Parse(d1sketch1.Text),
                    D2Sketch1 = float.Parse(d2sketch1.Text),
                    D1Sketch2 = float.Parse(d1sketch2.Text),
                    D5Sketch2 = float.Parse(d5sketch2.Text),
                    D6Sketch2 = float.Parse(d6sketch2.Text),
                    D7Sketch2 = float.Parse(d7sketch2.Text),
                    D9Sketch2 = float.Parse(d9sketch2.Text),
                    D10Sketch2 = float.Parse(d10sketch2.Text),
                    D11Sketch2 = float.Parse(d11sketch2.Text),
                    D12Sketch2 = float.Parse(d12sketch2.Text),
                    D8Sketch2 = float.Parse(d8sketch2.Text),
                    D14Sketch2 = float.Parse(d14sketch2.Text),
                    D15Sketch2 = float.Parse(d15sketch2.Text),
                    D4Sketch2 = float.Parse(d4sketch2.Text),
                    D16Sketch2 = float.Parse(d16sketch2.Text),
                    D17Sketch2 = float.Parse(d17sketch2.Text),
                    D21Sketch2 = float.Parse(d21sketch2.Text),
                    D1Sketch3 = float.Parse(d1sketch3.Text),
                    D2Sketch3 = float.Parse(d2sketch3.Text),
                    D3Sketch3 = float.Parse(d3sketch3.Text),
                    D4Sketch3 = float.Parse(d4sketch3.Text),
                    D5Sketch3 = float.Parse(d5sketch3.Text),
                    D7Sketch3 = float.Parse(d7sketch3.Text),
                    D8Sketch3 = float.Parse(d8sketch3.Text),
                    D9Sketch3 = float.Parse(d9sketch3.Text),
                    D10Sketch3 = float.Parse(d10sketch3.Text),
                    D2Sketch4 = float.Parse(d2sketch4.Text),
                    D3Sketch4 = float.Parse(d3sketch4.Text),
                    D2Sketch5 = float.Parse(d2sketch5.Text),
                    D3Sketch5 = float.Parse(d3sketch5.Text),
                    D1Sketch5 = float.Parse(d1sketch5.Text),
                    D1BossExtrude1 = float.Parse(d1bossextrude1.Text),
                    D1BossExtrude2 = float.Parse(d1bossextrude2.Text),
                    D1CutExtrude1 = float.Parse(d1cutextrude1.Text),
                    D1CutExtrude2 = float.Parse(d1cutextrude2.Text),
                    D13Sketch2 = dv.D13Sketch2,
                    D18Sketch2 = dv.D18Sketch2,
                    D19Sketch2 = dv.D19Sketch2,
                    D1CutExtrude3 = dv.D1CutExtrude3,
                    D20Sketch2 = dv.D20Sketch2,
                    D3Sketch2 = dv.D3Sketch2,
                    D6Sketch3 = dv.D6Sketch3,
                    Name = txtVersionName.Text,
                    PartId = dv.PartId
                };
                var version = await _apiService.Insert<Model.Versions>(newVersion);
                MessageBox.Show("Verzija je uspjesno kreirana");
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Verzija sa tim imenom vec postoji!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
       
        private async void btnSaveExcel_Click(object sender, EventArgs e)
        {
            btnSaveExcel.Enabled = false;
            var pass = await SaveVersion();
            if (pass == false)
            {
                btnSaveExcel.Enabled = true;
                return;
            }
            //Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory) + @"\"
            Excel _excel = new Excel(@"C:\Users\ajdin\Desktop\DIPLOMSKI\kmd.xlsx", 1);
            int i = _excel.LastRowRecorded() + 1;

            _excel.InsertCell(i, 1, txtVersionName.Text);
            _excel.InsertCell(i, 2, (d1sketch1.Text));
            _excel.InsertCell(i, 3, (d2sketch1.Text));
            _excel.InsertCell(i, 4, (d1bossextrude1.Text));
            _excel.InsertCell(i, 5, (d1sketch2.Text));
            _excel.InsertCell(i, 6, dv.D3Sketch2.ToString());
            _excel.InsertCell(i, 7, (d5sketch2.Text));
            _excel.InsertCell(i, 8, (d6sketch2.Text));
            _excel.InsertCell(i, 9, (d7sketch2.Text));
            _excel.InsertCell(i, 10, (d9sketch2.Text));
            _excel.InsertCell(i, 11, (d10sketch2.Text));
            _excel.InsertCell(i, 12, (d11sketch2.Text));
            _excel.InsertCell(i, 13, (d12sketch2.Text));
            _excel.InsertCell(i, 14, (d8sketch2.Text));
            _excel.InsertCell(i, 15, (d14sketch2.Text));
            _excel.InsertCell(i, 16, (d15sketch2.Text));
            _excel.InsertCell(i, 17, dv.D13Sketch2.ToString());
            _excel.InsertCell(i, 18, (d4sketch2.Text));
            _excel.InsertCell(i, 19, (d16sketch2.Text));
            _excel.InsertCell(i, 20, dv.D18Sketch2.ToString());
            _excel.InsertCell(i, 21, dv.D19Sketch2.ToString());
            _excel.InsertCell(i, 22, (d17sketch2.Text));
            _excel.InsertCell(i, 23, dv.D20Sketch2.ToString());
            _excel.InsertCell(i, 24, (d21sketch2.Text));
            _excel.InsertCell(i, 25, (d1bossextrude2.Text));
            _excel.InsertCell(i, 26, (d1sketch3.Text));
            _excel.InsertCell(i, 27, (d2sketch3.Text));
            _excel.InsertCell(i, 28, (d3sketch3.Text));
            _excel.InsertCell(i, 29, (d4sketch3.Text));
            _excel.InsertCell(i, 30, (d5sketch3.Text));
            _excel.InsertCell(i, 31, dv.D6Sketch3.ToString());
            _excel.InsertCell(i, 32, (d7sketch3.Text));
            _excel.InsertCell(i, 33, (d8sketch3.Text));
            _excel.InsertCell(i, 34, (d9sketch3.Text));
            _excel.InsertCell(i, 35, (d10sketch3.Text));
            _excel.InsertCell(i, 36, (d1cutextrude1.Text));
            _excel.InsertCell(i, 37, (d2sketch4.Text));
            _excel.InsertCell(i, 38, (d3sketch4.Text));
            _excel.InsertCell(i, 39, (d1cutextrude2.Text));
            _excel.InsertCell(i, 40, (d1sketch5.Text));
            _excel.InsertCell(i, 41, (d2sketch5.Text));
            _excel.InsertCell(i, 42, (d3sketch5.Text));
            _excel.InsertCell(i, 43, dv.D1CutExtrude3.ToString());
            _excel.Close();
            MessageBox.Show("Nova verzija je kreirana u Excel dokumentu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSaveExcel.Enabled = true;

        }

        private void btnUploadGCode_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Ucitaj GCode";
                dlg.Filter = "txt files (*.txt)|*.txt";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    gcodePath = dlg.FileName;

                    string gcodename = "";
                    if (gcodePath != null)
                    {
                        int pos = gcodePath.LastIndexOf(@"\") + 1;
                        gcodename = gcodePath.Substring(pos, gcodePath.Length - pos);
                        try
                        {
                            File.Copy(gcodePath, "/Files/" + gcodename, false);
                            lblPath.Visible = true;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("File sa istim imenom vec postoji","Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        try
                        {
                            var req = new VersionInsertUpdateRequest();
                            req.GCodePath = "/Files/" + gcodename;
                            var versionUpdate = _apiService.Update<Model.Versions>(dv.Id, req);
                            MessageBox.Show("GCode uspješno spašen!");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Greska");
                        }
                    }
                }
            }
        }
    }
}
