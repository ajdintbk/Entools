using Flurl.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entools.WinUI.Forms.Users
{
    public partial class frmLogin : Form
    {
        protected APIService _service = new APIService("Users");

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void Login()
        {
            try
            {
                btnLogin.Enabled = false;
                APIService.username = txtUsername.Text;
                APIService.password = txtPassword.Text;

                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("All fields are required! Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnLogin.Enabled = true;
                    return;
                }

                else
                {
                    var request = new Model.Requests.Users.UserLoginRequest
                    {
                        Username = txtUsername.Text,
                        Password = txtPassword.Text
                    };
                    var url = $"{Properties.Settings.Default.APIurl}/Users/Login";
                    var response = await url.PostJsonAsync(request);
                    //var findUser = new Model.Requests.Users.UserSearchRequest()
                    //{
                    //    Username = txtUsername.Text
                    //};
                    //var user = await _service.Get<List<Model.Users>>(findUser);
                    //if (user != null)
                    //{
                    //    APIService.loggedUser = user[0];
                    //}

                    this.Hide();
                    Homepage home = new Homepage();
                    home.Closed += (s, args) => this.Close();
                    home.Show();
                }
            }
            catch (Exception)
            {
                btnLogin.Enabled = true;
                MessageBox.Show("Wrong username or password", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLogin.Enabled = true;
            }

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
    }
}
