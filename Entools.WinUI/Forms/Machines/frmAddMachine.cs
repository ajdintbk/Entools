using Entools.Model.Requests.Machines;
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

namespace Entools.WinUI.Forms.Machines
{
    public partial class frmAddMachine : Form
    {
        protected readonly int EditMachineId = 0;
        protected Model.Machines openedMachine;
        protected string newImagePath;
        private readonly APIService _apiService = new APIService("Machine");
        public frmAddMachine()
        {
            InitializeComponent();
        }
        public frmAddMachine(int id) : this()
        {
            this.EditMachineId = id;
        }

        private async void frmAddMachine_Load(object sender, EventArgs e)
        {
            if(EditMachineId != 0)
            {
                openedMachine = await _apiService.GetById<Model.Machines>(EditMachineId);
                btnAction.Text = "Spasi";
                lblNaslov.Text = "Detalji mašine " + openedMachine.Name;
                txtNaziv.Text = openedMachine.Name;
                txtOznaka.Text = openedMachine.Label;
                txtSnaga.Text = openedMachine.Power.ToString();
                txtBrojObrtaja.Text = openedMachine.Speed.ToString();
                checkBox1.Checked = openedMachine.IsAvailable;
                
                pbMachine.ImageLocation = openedMachine.ImagePath;
                pbMachine.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pbMachine.ImageLocation = "../../../../Images/noimage.jpg";
                pbMachine.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private bool Validate(Control obj)
        {
            if (obj is ComboBox && int.Parse((obj as ComboBox).SelectedValue.ToString()) == 0)
            {
                err.SetError(obj, "This field is required!");
                obj.Focus();
                return false;
            }
            else if (obj is TextBox && string.IsNullOrWhiteSpace((obj as TextBox).Text))
            {
                err.SetError(obj, "This field is required!");
                return false;
            }
            err.Clear();
            return true;
        }
        public string ImagePathHelper()
        {
            string imagename = "";
            if(newImagePath != null)
            {
                int pos = newImagePath.LastIndexOf(@"\") + 1;
                imagename = newImagePath.Substring(pos, newImagePath.Length - pos);
                File.Copy(newImagePath, "../../../../Images/" + imagename, true);
            }
            if (imagename.Length > 0)
                return "../../../../Images/" + imagename;
            else return "../../../../Images/noimage.jpg";
        }
        private async void btnAction_Click(object sender, EventArgs e)
        {
            if(EditMachineId != 0)
            {
                try
                {
                    if (Validate(txtNaziv) && Validate(txtOznaka) && Validate(txtSnaga) && Validate(txtBrojObrtaja))
                    {
                        var updateReq = new InsertUpdateRequest()
                        {
                            Name = txtNaziv.Text,
                            Label = txtOznaka.Text.ToUpper(),
                            IsAvailable = checkBox1.Checked,
                            Power = int.Parse(txtSnaga.Text),
                            Speed = int.Parse(txtBrojObrtaja.Text),
                        };

                        if (newImagePath != null)
                            updateReq.ImagePath = ImagePathHelper();
                        else
                            updateReq.ImagePath = openedMachine.ImagePath;

                        await _apiService.Update<Model.Machines>(EditMachineId, updateReq);
                        MessageBox.Show("Masina uspjesno izmjenjena!", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error " + er, "Greska", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    throw;
                }
            }
            else
            {
                if (Validate(txtNaziv) && Validate(txtOznaka) && Validate(txtSnaga) && Validate(txtBrojObrtaja))
                {
                    try
                    {
                        var addNewMachine = new InsertUpdateRequest()
                        {
                            ImagePath = ImagePathHelper(),
                            IsAvailable = checkBox1.Checked,
                            Label = txtOznaka.Text,
                            Name = txtNaziv.Text,
                            Power = int.Parse(txtSnaga.Text),
                            Speed = int.Parse(txtBrojObrtaja.Text)
                        };
                        await _apiService.Insert<Model.Machines>(addNewMachine);
                        MessageBox.Show("Uspjesno ste dodali masinu oznake " + addNewMachine.Label, "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Greska prilikom kreiranja nove masine", "Greska", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        throw;
                    }
                }
            }
        }

        private void pbMachine_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";

                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    pbMachine.Image = new Bitmap(dlg.FileName);


                    newImagePath = dlg.FileName;

                }
            }
        }
    }
}
