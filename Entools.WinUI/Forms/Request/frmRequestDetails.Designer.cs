
namespace Entools.WinUI.Forms.Request
{
    partial class frmRequestDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.btnOdobri = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblKomad = new System.Windows.Forms.Label();
            this.lblKreirao = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.lblZahtjevId = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 156);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(512, 253);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.lblInfo);
            this.groupBox1.Controls.Add(this.gbActions);
            this.groupBox1.Controls.Add(this.lblKomad);
            this.groupBox1.Controls.Add(this.lblKreirao);
            this.groupBox1.Controls.Add(this.lblDatum);
            this.groupBox1.Controls.Add(this.lblZahtjevId);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 138);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalji zahtjeva";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.Green;
            this.lblInfo.Location = new System.Drawing.Point(327, 79);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(147, 15);
            this.lblInfo.TabIndex = 7;
            this.lblInfo.Text = "Zahtjev je već procesuiran.";
            this.lblInfo.Visible = false;
            // 
            // gbActions
            // 
            this.gbActions.Controls.Add(this.btnOdobri);
            this.gbActions.Controls.Add(this.button1);
            this.gbActions.Location = new System.Drawing.Point(204, 50);
            this.gbActions.Name = "gbActions";
            this.gbActions.Size = new System.Drawing.Size(292, 72);
            this.gbActions.TabIndex = 6;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "Akcije";
            // 
            // btnOdobri
            // 
            this.btnOdobri.BackColor = System.Drawing.Color.LimeGreen;
            this.btnOdobri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdobri.ForeColor = System.Drawing.Color.White;
            this.btnOdobri.Location = new System.Drawing.Point(112, 22);
            this.btnOdobri.Name = "btnOdobri";
            this.btnOdobri.Size = new System.Drawing.Size(84, 32);
            this.btnOdobri.TabIndex = 4;
            this.btnOdobri.Text = "Odobri";
            this.btnOdobri.UseVisualStyleBackColor = false;
            this.btnOdobri.Click += new System.EventHandler(this.btnOdobri_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(202, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "Odbij";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lblKomad
            // 
            this.lblKomad.AutoSize = true;
            this.lblKomad.Location = new System.Drawing.Point(28, 107);
            this.lblKomad.Name = "lblKomad";
            this.lblKomad.Size = new System.Drawing.Size(48, 15);
            this.lblKomad.TabIndex = 3;
            this.lblKomad.Text = "Komad:";
            // 
            // lblKreirao
            // 
            this.lblKreirao.AutoSize = true;
            this.lblKreirao.Location = new System.Drawing.Point(28, 88);
            this.lblKreirao.Name = "lblKreirao";
            this.lblKreirao.Size = new System.Drawing.Size(47, 15);
            this.lblKreirao.TabIndex = 2;
            this.lblKreirao.Text = "Kreirao:";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(28, 69);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(94, 15);
            this.lblDatum.TabIndex = 1;
            this.lblDatum.Text = "Datum kreiranja:";
            // 
            // lblZahtjevId
            // 
            this.lblZahtjevId.AutoSize = true;
            this.lblZahtjevId.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblZahtjevId.Location = new System.Drawing.Point(27, 33);
            this.lblZahtjevId.Name = "lblZahtjevId";
            this.lblZahtjevId.Size = new System.Drawing.Size(98, 32);
            this.lblZahtjevId.TabIndex = 0;
            this.lblZahtjevId.Text = "Zahtjev";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(451, 19);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 15);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "#status";
            // 
            // frmRequestDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 417);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmRequestDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRequestDetails";
            this.Load += new System.EventHandler(this.frmRequestDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOdobri;
        private System.Windows.Forms.Label lblKomad;
        private System.Windows.Forms.Label lblKreirao;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Label lblZahtjevId;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblStatus;
    }
}