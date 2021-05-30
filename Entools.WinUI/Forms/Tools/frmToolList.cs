using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entools.WinUI.Forms.Tools
{
    public partial class frmToolList : Form
    {
        private readonly APIService _apiService = new APIService("Tools");
        private int editId = 1;

        public frmToolList()
        {
            InitializeComponent();
        }

        private async void frmToolList_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            dataGridView1.RowTemplate.Height = 120;
            var list = await _apiService.Get<List<Model.Tools>>();
            var counter = 0;
            dataGridView1.DataSource = list;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText= "Naziv";
            dataGridView1.Columns["Label"].HeaderText= "Oznaka";
            dataGridView1.Columns["ImagePath"].Visible = false;

                DataGridViewImageColumn bcol = new DataGridViewImageColumn();
                bcol.HeaderText = "Slika";
                dataGridView1.Columns.Add(bcol);
            foreach (var item in list)
            {
                dataGridView1[4, counter++].Value = Image.FromFile(item.ImagePath);
            }
            pictureBox1.Image = Image.FromFile(list[0].ImagePath);
            txtName.Text = list[0].Name;
            txtLabel.Text = list[0].Label;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var tool = dataGridView1.CurrentRow.DataBoundItem as Model.Tools;
                editId = tool.Id;
                pictureBox1.Image = Image.FromFile(tool.ImagePath);
                txtName.Text = tool.Name;
                txtLabel.Text = tool.Label;
            }
        }
        private bool Validate(Control obj)
        {
            if (obj is ComboBox && int.Parse((obj as ComboBox).SelectedValue.ToString()) == 0)
            {
                err.SetError(obj, "Obavezno polje");
                obj.Focus();
                return false;
            }
            else if (obj is TextBox && string.IsNullOrWhiteSpace((obj as TextBox).Text))
            {
                err.SetError(obj, "Obavezno polje");
                return false;
            }
            err.Clear();
            return true;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if(Validate(txtLabel) || Validate(txtName))
            {
                try
                {
                    var request = new Model.Requests.Tools.ToolsInsertUpdateRequest()
                    {
                        Label = txtLabel.Text,
                        Name = txtName.Text
                    };
                    var tool = await _apiService.Update<Model.Tools>(editId, request);
                    if(tool != null)
                    {
                        MessageBox.Show("Alat uspjesno izmjenjen!");
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Izmjena podataka nije uspjela");
                }
                
            }
        }
    }
}
