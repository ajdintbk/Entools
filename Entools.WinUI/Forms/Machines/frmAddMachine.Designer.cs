
namespace Entools.WinUI.Forms.Machines
{
    partial class frmAddMachine
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
            this.components = new System.ComponentModel.Container();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOznaka = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSnaga = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBrojObrtaja = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblNaslov = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Button();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.pbMachine = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMachine)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(251, 92);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(100, 23);
            this.txtNaziv.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Naziv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Oznaka";
            // 
            // txtOznaka
            // 
            this.txtOznaka.Location = new System.Drawing.Point(251, 150);
            this.txtOznaka.Name = "txtOznaka";
            this.txtOznaka.Size = new System.Drawing.Size(100, 23);
            this.txtOznaka.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Snaga";
            // 
            // txtSnaga
            // 
            this.txtSnaga.Location = new System.Drawing.Point(397, 92);
            this.txtSnaga.Name = "txtSnaga";
            this.txtSnaga.Size = new System.Drawing.Size(100, 23);
            this.txtSnaga.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(397, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Broj obrtaja";
            // 
            // txtBrojObrtaja
            // 
            this.txtBrojObrtaja.Location = new System.Drawing.Point(397, 150);
            this.txtBrojObrtaja.Name = "txtBrojObrtaja";
            this.txtBrojObrtaja.Size = new System.Drawing.Size(100, 23);
            this.txtBrojObrtaja.TabIndex = 6;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(420, 194);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(77, 19);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Dostupna";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lblNaslov
            // 
            this.lblNaslov.AutoSize = true;
            this.lblNaslov.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNaslov.Location = new System.Drawing.Point(12, 9);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.Size = new System.Drawing.Size(196, 40);
            this.lblNaslov.TabIndex = 9;
            this.lblNaslov.Text = "Nova mašina";
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(251, 191);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 10;
            this.btnAction.Text = "Kreiraj";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // pbMachine
            // 
            this.pbMachine.Location = new System.Drawing.Point(21, 62);
            this.pbMachine.Name = "pbMachine";
            this.pbMachine.Size = new System.Drawing.Size(187, 152);
            this.pbMachine.TabIndex = 11;
            this.pbMachine.TabStop = false;
            this.pbMachine.Click += new System.EventHandler(this.pbMachine_Click);
            // 
            // frmAddMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 268);
            this.Controls.Add(this.pbMachine);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.lblNaslov);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBrojObrtaja);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSnaga);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOznaka);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNaziv);
            this.Name = "frmAddMachine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nova masina";
            this.Load += new System.EventHandler(this.frmAddMachine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMachine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOznaka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSnaga;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBrojObrtaja;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.PictureBox pbMachine;
    }
}