namespace ClienteEjemploCSReporter
{
    partial class FormMain
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPassContrato = new System.Windows.Forms.TextBox();
            this.textBoxRFCContrato = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBajarZip = new System.Windows.Forms.Button();
            this.dataGridViewCFDIs = new System.Windows.Forms.DataGridView();
            this.buttonDescargaSAT = new System.Windows.Forms.Button();
            this.panelPrincipal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCFDIs)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.Controls.Add(this.groupBox1);
            this.panelPrincipal.Controls.Add(this.label2);
            this.panelPrincipal.Controls.Add(this.label1);
            this.panelPrincipal.Controls.Add(this.buttonBajarZip);
            this.panelPrincipal.Controls.Add(this.dataGridViewCFDIs);
            this.panelPrincipal.Controls.Add(this.buttonDescargaSAT);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(901, 550);
            this.panelPrincipal.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxPassContrato);
            this.groupBox1.Controls.Add(this.textBoxRFCContrato);
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(550, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 86);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos proporcionados por tu ejecutivo de CSFacturación";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "CONTRASEÑA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "RFC CONTRATO";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBoxPassContrato
            // 
            this.textBoxPassContrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassContrato.Location = new System.Drawing.Point(119, 54);
            this.textBoxPassContrato.Name = "textBoxPassContrato";
            this.textBoxPassContrato.PasswordChar = '*';
            this.textBoxPassContrato.Size = new System.Drawing.Size(133, 20);
            this.textBoxPassContrato.TabIndex = 8;
            // 
            // textBoxRFCContrato
            // 
            this.textBoxRFCContrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRFCContrato.Location = new System.Drawing.Point(119, 27);
            this.textBoxRFCContrato.Name = "textBoxRFCContrato";
            this.textBoxRFCContrato.Size = new System.Drawing.Size(133, 20);
            this.textBoxRFCContrato.TabIndex = 7;
            this.textBoxRFCContrato.Text = "Introduce RFC";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(672, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(648, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "RFC de contrato:";
            // 
            // buttonBajarZip
            // 
            this.buttonBajarZip.Enabled = false;
            this.buttonBajarZip.Location = new System.Drawing.Point(194, 23);
            this.buttonBajarZip.Name = "buttonBajarZip";
            this.buttonBajarZip.Size = new System.Drawing.Size(149, 32);
            this.buttonBajarZip.TabIndex = 2;
            this.buttonBajarZip.Text = "Descargar archivo ZIP";
            this.buttonBajarZip.UseVisualStyleBackColor = true;
            this.buttonBajarZip.Click += new System.EventHandler(this.buttonBajarZip_Click);
            // 
            // dataGridViewCFDIs
            // 
            this.dataGridViewCFDIs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCFDIs.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewCFDIs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCFDIs.Location = new System.Drawing.Point(26, 109);
            this.dataGridViewCFDIs.Name = "dataGridViewCFDIs";
            this.dataGridViewCFDIs.Size = new System.Drawing.Size(851, 421);
            this.dataGridViewCFDIs.TabIndex = 1;
            // 
            // buttonDescargaSAT
            // 
            this.buttonDescargaSAT.Location = new System.Drawing.Point(26, 23);
            this.buttonDescargaSAT.Name = "buttonDescargaSAT";
            this.buttonDescargaSAT.Size = new System.Drawing.Size(149, 32);
            this.buttonDescargaSAT.TabIndex = 0;
            this.buttonDescargaSAT.Text = "Consultar al SAT";
            this.buttonDescargaSAT.UseVisualStyleBackColor = true;
            this.buttonDescargaSAT.Click += new System.EventHandler(this.buttonDescargaSAT_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 550);
            this.Controls.Add(this.panelPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(650, 300);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente ejemplo | CSReporter";
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCFDIs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Button buttonDescargaSAT;
        private System.Windows.Forms.DataGridView dataGridViewCFDIs;
        private System.Windows.Forms.Button buttonBajarZip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPassContrato;
        private System.Windows.Forms.TextBox textBoxRFCContrato;
        private System.Windows.Forms.Label label4;
    }
}

