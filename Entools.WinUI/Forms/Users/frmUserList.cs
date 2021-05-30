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
    public partial class frmUserList : Form
    {
        private readonly APIService _userService = new APIService("Users");

        public frmUserList()
        {
            InitializeComponent();
        }

        private async Task GetData(List<Model.Users> users = null)
        {


            List<Model.Users> list;

            if (dgvUserList.Columns.Contains("btnDetails"))
                dgvUserList.Columns.Remove("btnDetails");

            if (users == null)
                list = await _userService.Get<List<Model.Users>>();
            else
                list = users;

            
            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Action";
            bcol.Text = "Details";
            bcol.Name = "btnDetails";

            dgvUserList.DataSource = list;
            dgvUserList.Columns[0].Visible = false;

            bcol.UseColumnTextForButtonValue = true;
            if (!dgvUserList.Columns.Contains("btnDetails"))
                dgvUserList.Columns.Add(bcol);

            //lblNumberOfRows.Text = "Number of rows: " + list.Count.ToString();


        }
        private async void frmUserList_Load(object sender, EventArgs e)
        {
            await GetData();
        }
    }
}
