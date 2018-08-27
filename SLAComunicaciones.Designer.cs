namespace CargadeSLA
{
    partial class SLAComunicaciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardarSLATel = new System.Windows.Forms.Button();
            this.servicios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ransa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alicorp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csgr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agrChira = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.palmas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tramarsa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.servicios,
            this.ransa,
            this.alicorp,
            this.csgr,
            this.agrChira,
            this.primax,
            this.palmas,
            this.tramarsa,
            this.otros});
            this.dataGridView1.Location = new System.Drawing.Point(18, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.Size = new System.Drawing.Size(963, 195);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "SLA Servicios Telefonica";
            // 
            // btnGuardarSLATel
            // 
            this.btnGuardarSLATel.Location = new System.Drawing.Point(374, 20);
            this.btnGuardarSLATel.Name = "btnGuardarSLATel";
            this.btnGuardarSLATel.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarSLATel.TabIndex = 2;
            this.btnGuardarSLATel.Text = "Guardar";
            this.btnGuardarSLATel.UseVisualStyleBackColor = true;
            this.btnGuardarSLATel.Click += new System.EventHandler(this.btnGuardarSLATel_Click);
            // 
            // servicios
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.servicios.DefaultCellStyle = dataGridViewCellStyle1;
            this.servicios.HeaderText = "Servicios";
            this.servicios.Name = "servicios";
            this.servicios.ReadOnly = true;
            this.servicios.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ransa
            // 
            this.ransa.HeaderText = "Ransa";
            this.ransa.Name = "ransa";
            this.ransa.Width = 110;
            // 
            // alicorp
            // 
            this.alicorp.HeaderText = "Alicorp";
            this.alicorp.Name = "alicorp";
            this.alicorp.Width = 110;
            // 
            // csgr
            // 
            this.csgr.HeaderText = "CSGR";
            this.csgr.Name = "csgr";
            this.csgr.Width = 110;
            // 
            // agrChira
            // 
            this.agrChira.HeaderText = "Agri. Chira";
            this.agrChira.Name = "agrChira";
            // 
            // primax
            // 
            this.primax.HeaderText = "Primax";
            this.primax.Name = "primax";
            this.primax.Width = 110;
            // 
            // palmas
            // 
            this.palmas.HeaderText = "Palmas";
            this.palmas.Name = "palmas";
            this.palmas.Width = 110;
            // 
            // tramarsa
            // 
            this.tramarsa.HeaderText = "Tramarsa";
            this.tramarsa.Name = "tramarsa";
            // 
            // otros
            // 
            this.otros.HeaderText = "Otros";
            this.otros.Name = "otros";
            this.otros.Width = 110;
            // 
            // SLAComunicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 270);
            this.Controls.Add(this.btnGuardarSLATel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SLAComunicaciones";
            this.Text = "SLAComunicaciones";
            this.Load += new System.EventHandler(this.SLAComunicaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardarSLATel;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicios;
        private System.Windows.Forms.DataGridViewTextBoxColumn ransa;
        private System.Windows.Forms.DataGridViewTextBoxColumn alicorp;
        private System.Windows.Forms.DataGridViewTextBoxColumn csgr;
        private System.Windows.Forms.DataGridViewTextBoxColumn agrChira;
        private System.Windows.Forms.DataGridViewTextBoxColumn primax;
        private System.Windows.Forms.DataGridViewTextBoxColumn palmas;
        private System.Windows.Forms.DataGridViewTextBoxColumn tramarsa;
        private System.Windows.Forms.DataGridViewTextBoxColumn otros;
    }
}