using Entools.WinUI.Forms.GCode;
using Entools.WinUI.Forms.Machines;
using Entools.WinUI.Forms.Request;
using Entools.WinUI.Forms.Tools;
using Entools.WinUI.Forms.Users;
using Entools.WinUI.Forms.Versions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entools.WinUI
{
    public partial class Homepage : Form
    {
        private readonly APIService _apiService = new APIService("Request");

        public Homepage()
        {
            InitializeComponent();
        }

        private void btnMasine_Click(object sender, EventArgs e)
        {
            frmMachineList machineList = new frmMachineList();
            machineList.TopLevel = false;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(machineList);
            machineList.Show();
        }

        private void btnVerzije_Click(object sender, EventArgs e)
        {
            frmVersionsHomepage versions = new frmVersionsHomepage();
            versions.TopLevel = false;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(versions);
            versions.Show();
        }

        private void btnKorisnici_Click(object sender, EventArgs e)
        {
            frmUserList users = new frmUserList();
            users.TopLevel = false;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(users);
            users.Show();
        }

        private void btnAlati_Click(object sender, EventArgs e)
        {
            frmToolList tools = new frmToolList();
            tools.TopLevel = false;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(tools);
            tools.Show();
        }

        private void btnGcode_Click(object sender, EventArgs e)
        {
            lblRequestCount.Visible = false;
            frmRequestList tools = new frmRequestList();
            tools.TopLevel = false;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(tools);
            tools.Show();
        }

        private async void Homepage_Load(object sender, EventArgs e)
        {
            int counter = 0;
            var requests =await _apiService.Get<List<Model.Request>>();
            foreach (var item in requests)
            {
                if (!item.IsOpened)
                    counter++;
            }
            if(counter >0)
            lblRequestCount.Visible = true;
            lblRequestCount.Text = "+" + counter.ToString();
        }
    }
}
