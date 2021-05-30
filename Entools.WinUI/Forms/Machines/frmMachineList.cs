using Entools.Model.Requests.Machines;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entools.WinUI.Forms.Machines
{
    public partial class frmMachineList : Form
    {
        private readonly APIService _apiService = new APIService("Machine");
        public frmMachineList()
        {
            InitializeComponent();
        }

        private void GetData(List<Model.Machines> data)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = data;
            if (dataGridView1.Columns.Contains("btnDetails"))
                dataGridView1.Columns.Remove(dataGridView1.Columns["btnDetails"]);
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["ImagePath"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "Naziv";
            dataGridView1.Columns["Label"].HeaderText = "Oznaka";
            dataGridView1.Columns["Power"].HeaderText = "Snaga";
            dataGridView1.Columns["Speed"].HeaderText = "Broj obrtaja";
            dataGridView1.Columns["IsAvailable"].HeaderText = "Dostupna";

            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Akcija";
            bcol.Text = "Detalji";
            bcol.Name = "btnDetails";

            bcol.UseColumnTextForButtonValue = true;
            if (!dataGridView1.Columns.Contains("btnDetails"))
                dataGridView1.Columns.Add(bcol);

            lblCount.Text = data.Count.ToString();
        }
        private async void frmMachineList_Load(object sender, EventArgs e)
        {
            cmbDostupnost.DisplayMember = "Text";
            cmbDostupnost.ValueMember = "Value";

            var items = new[] {
                new { Text = "Sve", Value = "0" },
                new { Text = "Samo dostupne", Value = "1" },
                new { Text = "Samo nedostupne", Value = "2" }
            };

            cmbDostupnost.DataSource = items;

            txtFromSpeed.Text = "0";
            txtToSpeed.Text = "0";
            txtPower.Text = "0";
            
            var list = await _apiService.Get<List<Model.Machines>>();
            GetData(list);

            
        }
        private MachineSearchRequest Filter()
        {
            var request = new MachineSearchRequest()
            {
                Name = txtName.Text,
                FromSpeed = txtFromSpeed.Text.Length > 0 ? int.Parse(txtFromSpeed.Text) : 0,
                ToSpeed = txtToSpeed.Text.Length > 0 ? int.Parse(txtToSpeed.Text) : 0,
                Power = txtPower.Text.Length > 0 ? int.Parse(txtPower.Text) : 0,
                Availability = int.Parse(cmbDostupnost.SelectedValue.ToString())
            };
            return request;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtFromSpeed.Text) > int.Parse(txtToSpeed.Text))
                err.SetError(txtFromSpeed, "Pocetna brzina je veca od krajnje!");
            else
                err.Clear();

            var data = await _apiService.Get<List<Model.Machines>>(Filter());
            GetData(data);
        }

        private async void txtName_TextChanged(object sender, EventArgs e)
        {
            var data = await _apiService.Get<List<Model.Machines>>(Filter());
            GetData(data);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 7)
                {
                    frmAddMachine addmachine = new frmAddMachine(int.Parse(dataGridView1[0, e.RowIndex].Value.ToString()));
                    addmachine.ShowDialog();
                }
            }
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 6)
                {
                    var machineUpdate = new InsertUpdateRequest()
                    {
                        IsAvailable = !(bool)dataGridView1[e.ColumnIndex, e.RowIndex].Value,
                        ToggleAvailability = true
                    };
                    await _apiService.Update<Model.Machines>(dataGridView1[0, e.RowIndex].Value, machineUpdate);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddMachine addmachine = new frmAddMachine();
            addmachine.ShowDialog();
        }
    }
}
