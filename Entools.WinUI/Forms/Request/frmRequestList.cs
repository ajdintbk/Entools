using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entools.WinUI.Forms.Request
{
    public partial class frmRequestList : Form
    {
        private readonly APIService _apiService = new APIService("Request");

        public frmRequestList()
        {
            InitializeComponent();
        }

        private async void frmRequestList_Load(object sender, EventArgs e)
        {
            var list = await _apiService.Get<List<Model.Request>>();
            dataGridView1.DataSource = list;
            lblCount.Text = list.Count.ToString();

            if (dataGridView1.Columns.Contains("btnDetails"))
                dataGridView1.Columns.Remove(dataGridView1.Columns["btnDetails"]);
            
            dataGridView1.Columns["DateCreated"].HeaderText = "Datum kreiranja";
            dataGridView1.Columns["CreatedBy"].HeaderText = "Kreirao";
            dataGridView1.Columns["IsApproved"].HeaderText = "Odobren";
            dataGridView1.Columns["IsOpened"].HeaderText = "Pregledan";

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;

            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Akcija";
            bcol.Text = "Detalji";
            bcol.Name = "btnDetails";

            bcol.UseColumnTextForButtonValue = true;
            if (!dataGridView1.Columns.Contains("btnDetails"))
                dataGridView1.Columns.Add(bcol);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 10)
                {
                    frmRequestDetails addmachine = new frmRequestDetails(int.Parse(dataGridView1[0, e.RowIndex].Value.ToString()));
                    addmachine.ShowDialog();
                }
            }
        }
    }
}
