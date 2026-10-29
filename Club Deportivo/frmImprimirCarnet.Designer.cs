namespace Club_Deportivo
{
    partial class frmImprimirCarnet
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
            this.pnlCarnet = new System.Windows.Forms.Panel();
            this.pnlHeaderCarnet = new System.Windows.Forms.Panel();
            this.lblTituloCarnet = new System.Windows.Forms.Label();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.lblTagSocio = new System.Windows.Forms.Label();
            this.lblNroCarnet = new System.Windows.Forms.Label();
            this.lblTagNombre = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTagApellido = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblTagDni = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlCarnet.SuspendLayout();
            this.pnlHeaderCarnet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCarnet
            // 
            this.pnlCarnet.BackColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.pnlCarnet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCarnet.Controls.Add(this.pnlHeaderCarnet);
            this.pnlCarnet.Controls.Add(this.picFoto);
            this.pnlCarnet.Controls.Add(this.lblTagSocio);
            this.pnlCarnet.Controls.Add(this.lblNroCarnet);
            this.pnlCarnet.Controls.Add(this.lblTagNombre);
            this.pnlCarnet.Controls.Add(this.lblNombre);
            this.pnlCarnet.Controls.Add(this.lblTagApellido);
            this.pnlCarnet.Controls.Add(this.lblApellido);
            this.pnlCarnet.Controls.Add(this.lblTagDni);
            this.pnlCarnet.Controls.Add(this.lblDni);
            this.pnlCarnet.Location = new System.Drawing.Point(25, 20);
            this.pnlCarnet.Name = "pnlCarnet";
            this.pnlCarnet.Size = new System.Drawing.Size(460, 230);
            this.pnlCarnet.TabIndex = 0;
            // 
            // pnlHeaderCarnet
            // 
            this.pnlHeaderCarnet.BackColor = System.Drawing.Color.FromArgb(100, 180, 150);
            this.pnlHeaderCarnet.Controls.Add(this.lblTituloCarnet);
            this.pnlHeaderCarnet.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderCarnet.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderCarnet.Name = "pnlHeaderCarnet";
            this.pnlHeaderCarnet.Size = new System.Drawing.Size(458, 38);
            this.pnlHeaderCarnet.TabIndex = 0;
            // 
            // lblTituloCarnet
            // 
            this.lblTituloCarnet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTituloCarnet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloCarnet.ForeColor = System.Drawing.Color.FromArgb(15, 30, 25);
            this.lblTituloCarnet.Location = new System.Drawing.Point(0, 0);
            this.lblTituloCarnet.Name = "lblTituloCarnet";
            this.lblTituloCarnet.Size = new System.Drawing.Size(458, 38);
            this.lblTituloCarnet.TabIndex = 0;
            this.lblTituloCarnet.Text = "CLUB DEPORTIVO - CARNET DE SOCIO";
            this.lblTituloCarnet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picFoto
            // 
            this.picFoto.BackColor = System.Drawing.Color.FromArgb(205, 215, 225);
            this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFoto.Image = global::Club_Deportivo.Properties.Resources._3727437992a7ea7a6912cec2ad51e2e9;
            this.picFoto.Location = new System.Drawing.Point(20, 52);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(125, 155);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 1;
            this.picFoto.TabStop = false;
            // 
            // lblTagSocio
            // 
            this.lblTagSocio.AutoSize = true;
            this.lblTagSocio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTagSocio.ForeColor = System.Drawing.Color.FromArgb(25, 35, 45);
            this.lblTagSocio.Location = new System.Drawing.Point(165, 58);
            this.lblTagSocio.Name = "lblTagSocio";
            this.lblTagSocio.Size = new System.Drawing.Size(81, 19);
            this.lblTagSocio.TabIndex = 2;
            this.lblTagSocio.Text = "Nro Socio:";
            // 
            // lblNroCarnet
            // 
            this.lblNroCarnet.AutoSize = true;
            this.lblNroCarnet.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblNroCarnet.ForeColor = System.Drawing.Color.FromArgb(15, 80, 45);
            this.lblNroCarnet.Location = new System.Drawing.Point(255, 58);
            this.lblNroCarnet.Name = "lblNroCarnet";
            this.lblNroCarnet.Size = new System.Drawing.Size(73, 19);
            this.lblNroCarnet.TabIndex = 3;
            this.lblNroCarnet.Text = "000000";
            // 
            // lblTagNombre
            // 
            this.lblTagNombre.AutoSize = true;
            this.lblTagNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTagNombre.ForeColor = System.Drawing.Color.FromArgb(25, 35, 45);
            this.lblTagNombre.Location = new System.Drawing.Point(165, 96);
            this.lblTagNombre.Name = "lblTagNombre";
            this.lblTagNombre.Size = new System.Drawing.Size(62, 17);
            this.lblTagNombre.TabIndex = 4;
            this.lblTagNombre.Text = "Nombre:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(25, 35, 45);
            this.lblNombre.Location = new System.Drawing.Point(255, 95);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(59, 19);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre";
            // 
            // lblTagApellido
            // 
            this.lblTagApellido.AutoSize = true;
            this.lblTagApellido.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTagApellido.ForeColor = System.Drawing.Color.FromArgb(25, 35, 45);
            this.lblTagApellido.Location = new System.Drawing.Point(165, 134);
            this.lblTagApellido.Name = "lblTagApellido";
            this.lblTagApellido.Size = new System.Drawing.Size(63, 17);
            this.lblTagApellido.TabIndex = 6;
            this.lblTagApellido.Text = "Apellido:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(25, 35, 45);
            this.lblApellido.Location = new System.Drawing.Point(255, 133);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(58, 19);
            this.lblApellido.TabIndex = 7;
            this.lblApellido.Text = "Apellido";
            // 
            // lblTagDni
            // 
            this.lblTagDni.AutoSize = true;
            this.lblTagDni.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTagDni.ForeColor = System.Drawing.Color.FromArgb(25, 35, 45);
            this.lblTagDni.Location = new System.Drawing.Point(165, 172);
            this.lblTagDni.Name = "lblTagDni";
            this.lblTagDni.Size = new System.Drawing.Size(35, 17);
            this.lblTagDni.TabIndex = 8;
            this.lblTagDni.Text = "DNI:";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDni.ForeColor = System.Drawing.Color.FromArgb(25, 35, 45);
            this.lblDni.Location = new System.Drawing.Point(255, 171);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(73, 19);
            this.lblDni.TabIndex = 9;
            this.lblDni.Text = "00000000";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(140, 210, 180);
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(15, 40, 25);
            this.btnImprimir.Location = new System.Drawing.Point(75, 270);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(160, 36);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "IMPRIMIR";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(195, 205, 215);
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(25, 35, 50);
            this.btnCerrar.Location = new System.Drawing.Point(275, 270);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(160, 36);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click_1);
            // 
            // frmImprimirCarnet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(218, 226, 236);
            this.ClientSize = new System.Drawing.Size(510, 325);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.pnlCarnet);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImprimirCarnet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carnet de Socio - Club Deportivo";
            this.Load += new System.EventHandler(this.frmImprimirCarnet_Load);
            this.pnlCarnet.ResumeLayout(false);
            this.pnlCarnet.PerformLayout();
            this.pnlHeaderCarnet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlCarnet;
        private System.Windows.Forms.Panel pnlHeaderCarnet;
        private System.Windows.Forms.Label lblTituloCarnet;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Label lblTagSocio;
        private System.Windows.Forms.Label lblNroCarnet;
        private System.Windows.Forms.Label lblTagNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTagApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblTagDni;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCerrar;
    }
}