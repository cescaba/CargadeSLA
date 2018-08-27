namespace CargadeSLA
{
    partial class AltaEnlace
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cboacceso = new System.Windows.Forms.ComboBox();
            this.cbozona = new System.Windows.Forms.ComboBox();
            this.cboempresa = new System.Windows.Forms.ComboBox();
            this.cboprioridad = new System.Windows.Forms.ComboBox();
            this.txtabrev = new System.Windows.Forms.TextBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtcd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cboacceso);
            this.groupBox1.Controls.Add(this.cbozona);
            this.groupBox1.Controls.Add(this.cboempresa);
            this.groupBox1.Controls.Add(this.cboprioridad);
            this.groupBox1.Controls.Add(this.txtabrev);
            this.groupBox1.Controls.Add(this.txtnombre);
            this.groupBox1.Controls.Add(this.txtcd);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 221);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo Enlace";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboacceso
            // 
            this.cboacceso.FormattingEnabled = true;
            this.cboacceso.Items.AddRange(new object[] {
            "Fibra",
            "Cobre",
            "Radio Punto a Punto",
            "Satelital",
            "Otros"});
            this.cboacceso.Location = new System.Drawing.Point(105, 187);
            this.cboacceso.Name = "cboacceso";
            this.cboacceso.Size = new System.Drawing.Size(147, 21);
            this.cboacceso.TabIndex = 13;
            // 
            // cbozona
            // 
            this.cbozona.FormattingEnabled = true;
            this.cbozona.Items.AddRange(new object[] {
            "Lima y Urbano",
            "Semiurbano",
            "Rural"});
            this.cbozona.Location = new System.Drawing.Point(105, 160);
            this.cbozona.Name = "cbozona";
            this.cbozona.Size = new System.Drawing.Size(147, 21);
            this.cbozona.TabIndex = 12;
            // 
            // cboempresa
            // 
            this.cboempresa.FormattingEnabled = true;
            this.cboempresa.Location = new System.Drawing.Point(105, 133);
            this.cboempresa.Name = "cboempresa";
            this.cboempresa.Size = new System.Drawing.Size(147, 21);
            this.cboempresa.TabIndex = 11;
            // 
            // cboprioridad
            // 
            this.cboprioridad.FormattingEnabled = true;
            this.cboprioridad.Items.AddRange(new object[] {
            "Otros",
            "Principal"});
            this.cboprioridad.Location = new System.Drawing.Point(105, 106);
            this.cboprioridad.Name = "cboprioridad";
            this.cboprioridad.Size = new System.Drawing.Size(147, 21);
            this.cboprioridad.TabIndex = 10;
            // 
            // txtabrev
            // 
            this.txtabrev.Location = new System.Drawing.Point(105, 79);
            this.txtabrev.Name = "txtabrev";
            this.txtabrev.Size = new System.Drawing.Size(295, 20);
            this.txtabrev.TabIndex = 9;
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(105, 53);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(295, 20);
            this.txtnombre.TabIndex = 8;
            // 
            // txtcd
            // 
            this.txtcd.Location = new System.Drawing.Point(105, 27);
            this.txtcd.Name = "txtcd";
            this.txtcd.Size = new System.Drawing.Size(100, 20);
            this.txtcd.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Acceso";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Zona";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Empresa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Prioridad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "CD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre Abreviado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // AltaEnlace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 240);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaEnlace";
            this.Text = "Alta de Enlace";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboacceso;
        private System.Windows.Forms.ComboBox cbozona;
        private System.Windows.Forms.ComboBox cboempresa;
        private System.Windows.Forms.ComboBox cboprioridad;
        private System.Windows.Forms.TextBox txtabrev;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.TextBox txtcd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;

    }
}