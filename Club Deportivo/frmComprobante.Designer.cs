namespace Club_Deportivo
{
    partial class frmComprobante
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlRecibo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFechaHoy = new System.Windows.Forms.Label();
            this.lblL1 = new System.Windows.Forms.Label();
            this.lblSocio = new System.Windows.Forms.Label();
            this.lblL2 = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblL3 = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblL4 = new System.Windows.Forms.Label();
            this.lblTipoCuota = new System.Windows.Forms.Label();
            this.lblL5 = new System.Windows.Forms.Label();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.lblL6 = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblL7 = new System.Windows.Forms.Label();
            this.lblVencimiento = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlRecibo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRecibo
            // 
            this.pnlRecibo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRecibo.Controls.Add(this.lblTitulo);
            this.pnlRecibo.Controls.Add(this.lblFechaHoy);
            this.pnlRecibo.Controls.Add(this.lblL1);
            this.pnlRecibo.Controls.Add(this.lblSocio);
            this.pnlRecibo.Controls.Add(this.lblL2);
            this.pnlRecibo.Controls.Add(this.lblDni);
            this.pnlRecibo.Controls.Add(this.lblL3);
            this.pnlRecibo.Controls.Add(this.lblCategoria);
            this.pnlRecibo.Controls.Add(this.lblL4);
            this.pnlRecibo.Controls.Add(this.lblTipoCuota);
            this.pnlRecibo.Controls.Add(this.lblL5);
            this.pnlRecibo.Controls.Add(this.lblFormaPago);
            this.pnlRecibo.Controls.Add(this.lblL6);
            this.pnlRecibo.Controls.Add(this.lblMonto);
            this.pnlRecibo.Controls.Add(this.lblL7);
            this.pnlRecibo.Controls.Add(this.lblVencimiento);
            this.pnlRecibo.Location = new System.Drawing.Point(25, 20);
            this.pnlRecibo.Name = "pnlRecibo";
            this.pnlRecibo.Size = new System.Drawing.Size(490, 310);
            this.pnlRecibo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(110, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(423, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "CLUB DEPORTIVO - COMPROBANTE";
            // 
            // lblFechaHoy
            // 
            this.lblFechaHoy.AutoSize = true;
            this.lblFechaHoy.Location = new System.Drawing.Point(370, 45);
            this.lblFechaHoy.Name = "lblFechaHoy";
            this.lblFechaHoy.Size = new System.Drawing.Size(54, 20);
            this.lblFechaHoy.TabIndex = 1;
            this.lblFechaHoy.Text = "Fecha";
            // 
            // lblL1
            // 
            this.lblL1.AutoSize = true;
            this.lblL1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblL1.Location = new System.Drawing.Point(30, 65);
            this.lblL1.Name = "lblL1";
            this.lblL1.Size = new System.Drawing.Size(83, 28);
            this.lblL1.TabIndex = 2;
            this.lblL1.Text = "Cliente:";
            // 
            // lblSocio
            // 
            this.lblSocio.AutoSize = true;
            this.lblSocio.Location = new System.Drawing.Point(180, 65);
            this.lblSocio.Name = "lblSocio";
            this.lblSocio.Size = new System.Drawing.Size(118, 20);
            this.lblSocio.TabIndex = 3;
            this.lblSocio.Text = "Nombre Cliente";
            // 
            // lblL2
            // 
            this.lblL2.AutoSize = true;
            this.lblL2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblL2.Location = new System.Drawing.Point(30, 95);
            this.lblL2.Name = "lblL2";
            this.lblL2.Size = new System.Drawing.Size(54, 28);
            this.lblL2.TabIndex = 4;
            this.lblL2.Text = "DNI:";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(180, 95);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(37, 20);
            this.lblDni.TabIndex = 5;
            this.lblDni.Text = "DNI";
            // 
            // lblL3
            // 
            this.lblL3.AutoSize = true;
            this.lblL3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblL3.Location = new System.Drawing.Point(30, 125);
            this.lblL3.Name = "lblL3";
            this.lblL3.Size = new System.Drawing.Size(108, 28);
            this.lblL3.TabIndex = 6;
            this.lblL3.Text = "Categoría:";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(180, 125);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(78, 20);
            this.lblCategoria.TabIndex = 7;
            this.lblCategoria.Text = "Categoría";
            // 
            // lblL4
            // 
            this.lblL4.AutoSize = true;
            this.lblL4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblL4.Location = new System.Drawing.Point(30, 155);
            this.lblL4.Name = "lblL4";
            this.lblL4.Size = new System.Drawing.Size(149, 28);
            this.lblL4.TabIndex = 8;
            this.lblL4.Text = "Tipo de Cuota:";
            // 
            // lblTipoCuota
            // 
            this.lblTipoCuota.AutoSize = true;
            this.lblTipoCuota.Location = new System.Drawing.Point(180, 155);
            this.lblTipoCuota.Name = "lblTipoCuota";
            this.lblTipoCuota.Size = new System.Drawing.Size(39, 20);
            this.lblTipoCuota.TabIndex = 9;
            this.lblTipoCuota.Text = "Tipo";
            // 
            // lblL5
            // 
            this.lblL5.AutoSize = true;
            this.lblL5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblL5.Location = new System.Drawing.Point(30, 185);
            this.lblL5.Name = "lblL5";
            this.lblL5.Size = new System.Drawing.Size(158, 28);
            this.lblL5.TabIndex = 10;
            this.lblL5.Text = "Forma de Pago:";
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Location = new System.Drawing.Point(180, 185);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(96, 20);
            this.lblFormaPago.TabIndex = 11;
            this.lblFormaPago.Text = "Forma Pago";
            // 
            // lblL6
            // 
            this.lblL6.AutoSize = true;
            this.lblL6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblL6.Location = new System.Drawing.Point(30, 225);
            this.lblL6.Name = "lblL6";
            this.lblL6.Size = new System.Drawing.Size(170, 30);
            this.lblL6.TabIndex = 12;
            this.lblL6.Text = "Total Abonado:";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMonto.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblMonto.Location = new System.Drawing.Point(180, 225);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(77, 30);
            this.lblMonto.TabIndex = 13;
            this.lblMonto.Text = "$ 0.00";
            // 
            // lblL7
            // 
            this.lblL7.AutoSize = true;
            this.lblL7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblL7.Location = new System.Drawing.Point(30, 265);
            this.lblL7.Name = "lblL7";
            this.lblL7.Size = new System.Drawing.Size(183, 25);
            this.lblL7.TabIndex = 14;
            this.lblL7.Text = "Próximo Vencimiento:";
            // 
            // lblVencimiento
            // 
            this.lblVencimiento.AutoSize = true;
            this.lblVencimiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblVencimiento.Location = new System.Drawing.Point(180, 265);
            this.lblVencimiento.Name = "lblVencimiento";
            this.lblVencimiento.Size = new System.Drawing.Size(110, 25);
            this.lblVencimiento.TabIndex = 15;
            this.lblVencimiento.Text = "Vencimiento";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(90, 345);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(150, 36);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(300, 345);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(150, 36);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmComprobante
            // 
            this.ClientSize = new System.Drawing.Size(528, 400);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.pnlRecibo);
            this.Name = "frmComprobante";
            this.Text = "Comprobante de Pago";
            this.Load += new System.EventHandler(this.frmComprobante_Load);
            this.pnlRecibo.ResumeLayout(false);
            this.pnlRecibo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRecibo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFechaHoy;
        private System.Windows.Forms.Label lblL1;
        private System.Windows.Forms.Label lblSocio;
        private System.Windows.Forms.Label lblL2;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblL3;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblL4;
        private System.Windows.Forms.Label lblTipoCuota;
        private System.Windows.Forms.Label lblL5;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.Label lblL6;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblL7;
        private System.Windows.Forms.Label lblVencimiento;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCerrar;
    }
}
