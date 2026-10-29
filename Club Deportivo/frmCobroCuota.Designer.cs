namespace Club_Deportivo
{
    partial class frmCobroCuota
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitulo = new System.Windows.Forms.Label();
            this.lblBuscarDni = new System.Windows.Forms.Label();
            this.txtBuscarDni = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblInfoCliente = new System.Windows.Forms.Label();
            this.lblInfoCategoria = new System.Windows.Forms.Label();
            this.lblInfoEstado = new System.Windows.Forms.Label();
            this.lblMontoTitulo = new System.Windows.Forms.Label();
            this.lblDetalleCuotas = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.grpTipoCuota = new System.Windows.Forms.GroupBox();
            this.rdbDiaria = new System.Windows.Forms.RadioButton();
            this.rdbMensual = new System.Windows.Forms.RadioButton();
            this.grpFormaPago = new System.Windows.Forms.GroupBox();
            this.lblCuotas = new System.Windows.Forms.Label();
            this.cmbCuotasTarjeta = new System.Windows.Forms.ComboBox();
            this.rdbTarjeta = new System.Windows.Forms.RadioButton();
            this.rdbEfectivo = new System.Windows.Forms.RadioButton();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnComprobante = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.grpTipoCuota.SuspendLayout();
            this.grpFormaPago.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(218, 226, 236);
            this.pnlHeader.Controls.Add(this.lblHeaderTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(600, 42);
            this.pnlHeader.TabIndex = 12;
            // 
            // lblHeaderTitulo
            // 
            this.lblHeaderTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitulo.ForeColor = System.Drawing.Color.FromArgb(20, 30, 45);
            this.lblHeaderTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblHeaderTitulo.Name = "lblHeaderTitulo";
            this.lblHeaderTitulo.Size = new System.Drawing.Size(600, 42);
            this.lblHeaderTitulo.TabIndex = 0;
            this.lblHeaderTitulo.Text = "COBRO DE CUOTAS";
            this.lblHeaderTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBuscarDni
            // 
            this.lblBuscarDni.AutoSize = true;
            this.lblBuscarDni.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBuscarDni.ForeColor = System.Drawing.Color.FromArgb(170, 180, 195);
            this.lblBuscarDni.Location = new System.Drawing.Point(35, 58);
            this.lblBuscarDni.Name = "lblBuscarDni";
            this.lblBuscarDni.Size = new System.Drawing.Size(78, 19);
            this.lblBuscarDni.TabIndex = 1;
            this.lblBuscarDni.Text = "Buscar DNI:";
            // 
            // txtBuscarDni
            // 
            this.txtBuscarDni.BackColor = System.Drawing.Color.FromArgb(200, 210, 222);
            this.txtBuscarDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarDni.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtBuscarDni.ForeColor = System.Drawing.Color.FromArgb(25, 30, 40);
            this.txtBuscarDni.Location = new System.Drawing.Point(125, 55);
            this.txtBuscarDni.Name = "txtBuscarDni";
            this.txtBuscarDni.Size = new System.Drawing.Size(265, 26);
            this.txtBuscarDni.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(195, 205, 215);
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(25, 35, 50);
            this.btnBuscar.Location = new System.Drawing.Point(405, 53);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(155, 30);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(200, 210, 222);
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Controls.Add(this.lblInfoCliente);
            this.pnlInfo.Controls.Add(this.lblInfoCategoria);
            this.pnlInfo.Controls.Add(this.lblInfoEstado);
            this.pnlInfo.Location = new System.Drawing.Point(35, 95);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(525, 90);
            this.pnlInfo.TabIndex = 4;
            // 
            // lblInfoCliente
            // 
            this.lblInfoCliente.AutoSize = true;
            this.lblInfoCliente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfoCliente.ForeColor = System.Drawing.Color.FromArgb(20, 25, 35);
            this.lblInfoCliente.Location = new System.Drawing.Point(15, 10);
            this.lblInfoCliente.Name = "lblInfoCliente";
            this.lblInfoCliente.Size = new System.Drawing.Size(68, 19);
            this.lblInfoCliente.TabIndex = 0;
            this.lblInfoCliente.Text = "Cliente: -";
            // 
            // lblInfoCategoria
            // 
            this.lblInfoCategoria.AutoSize = true;
            this.lblInfoCategoria.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblInfoCategoria.ForeColor = System.Drawing.Color.FromArgb(30, 35, 45);
            this.lblInfoCategoria.Location = new System.Drawing.Point(15, 34);
            this.lblInfoCategoria.Name = "lblInfoCategoria";
            this.lblInfoCategoria.Size = new System.Drawing.Size(78, 17);
            this.lblInfoCategoria.TabIndex = 1;
            this.lblInfoCategoria.Text = "Categoría: -";
            // 
            // lblInfoEstado
            // 
            this.lblInfoEstado.AutoSize = true;
            this.lblInfoEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblInfoEstado.ForeColor = System.Drawing.Color.FromArgb(180, 40, 40);
            this.lblInfoEstado.Location = new System.Drawing.Point(15, 58);
            this.lblInfoEstado.Name = "lblInfoEstado";
            this.lblInfoEstado.Size = new System.Drawing.Size(61, 17);
            this.lblInfoEstado.TabIndex = 2;
            this.lblInfoEstado.Text = "Estado: -";
            // 
            // lblMontoTitulo
            // 
            this.lblMontoTitulo.AutoSize = true;
            this.lblMontoTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMontoTitulo.ForeColor = System.Drawing.Color.FromArgb(200, 210, 225);
            this.lblMontoTitulo.Location = new System.Drawing.Point(35, 200);
            this.lblMontoTitulo.Name = "lblMontoTitulo";
            this.lblMontoTitulo.Size = new System.Drawing.Size(115, 19);
            this.lblMontoTitulo.TabIndex = 5;
            this.lblMontoTitulo.Text = "Monto Base: $";
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.FromArgb(200, 210, 222);
            this.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonto.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.txtMonto.ForeColor = System.Drawing.Color.FromArgb(25, 30, 40);
            this.txtMonto.Location = new System.Drawing.Point(155, 197);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(95, 26);
            this.txtMonto.TabIndex = 6;
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            // 
            // lblDetalleCuotas
            // 
            this.lblDetalleCuotas.AutoSize = true;
            this.lblDetalleCuotas.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDetalleCuotas.ForeColor = System.Drawing.Color.FromArgb(80, 215, 160);
            this.lblDetalleCuotas.Location = new System.Drawing.Point(260, 201);
            this.lblDetalleCuotas.Name = "lblDetalleCuotas";
            this.lblDetalleCuotas.Size = new System.Drawing.Size(0, 17);
            this.lblDetalleCuotas.TabIndex = 15;
            // 
            // grpTipoCuota
            // 
            this.grpTipoCuota.Controls.Add(this.rdbDiaria);
            this.grpTipoCuota.Controls.Add(this.rdbMensual);
            this.grpTipoCuota.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.grpTipoCuota.ForeColor = System.Drawing.Color.FromArgb(170, 180, 195);
            this.grpTipoCuota.Location = new System.Drawing.Point(35, 235);
            this.grpTipoCuota.Name = "grpTipoCuota";
            this.grpTipoCuota.Size = new System.Drawing.Size(250, 60);
            this.grpTipoCuota.TabIndex = 7;
            this.grpTipoCuota.TabStop = false;
            this.grpTipoCuota.Text = "Tipo de Cuota";
            // 
            // rdbDiaria
            // 
            this.rdbDiaria.AutoSize = true;
            this.rdbDiaria.Location = new System.Drawing.Point(135, 25);
            this.rdbDiaria.Name = "rdbDiaria";
            this.rdbDiaria.Size = new System.Drawing.Size(60, 21);
            this.rdbDiaria.TabIndex = 1;
            this.rdbDiaria.TabStop = true;
            this.rdbDiaria.Text = "Diaria";
            this.rdbDiaria.UseVisualStyleBackColor = true;
            this.rdbDiaria.CheckedChanged += new System.EventHandler(this.rdbDiaria_CheckedChanged);
            // 
            // rdbMensual
            // 
            this.rdbMensual.AutoSize = true;
            this.rdbMensual.Location = new System.Drawing.Point(20, 25);
            this.rdbMensual.Name = "rdbMensual";
            this.rdbMensual.Size = new System.Drawing.Size(75, 21);
            this.rdbMensual.TabIndex = 0;
            this.rdbMensual.TabStop = true;
            this.rdbMensual.Text = "Mensual";
            this.rdbMensual.UseVisualStyleBackColor = true;
            this.rdbMensual.CheckedChanged += new System.EventHandler(this.rdbMensual_CheckedChanged);
            // 
            // grpFormaPago
            // 
            this.grpFormaPago.Controls.Add(this.lblCuotas);
            this.grpFormaPago.Controls.Add(this.cmbCuotasTarjeta);
            this.grpFormaPago.Controls.Add(this.rdbTarjeta);
            this.grpFormaPago.Controls.Add(this.rdbEfectivo);
            this.grpFormaPago.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.grpFormaPago.ForeColor = System.Drawing.Color.FromArgb(170, 180, 195);
            this.grpFormaPago.Location = new System.Drawing.Point(310, 235);
            this.grpFormaPago.Name = "grpFormaPago";
            this.grpFormaPago.Size = new System.Drawing.Size(250, 95);
            this.grpFormaPago.TabIndex = 8;
            this.grpFormaPago.TabStop = false;
            this.grpFormaPago.Text = "Forma de Pago";
            // 
            // lblCuotas
            // 
            this.lblCuotas.AutoSize = true;
            this.lblCuotas.Location = new System.Drawing.Point(12, 60);
            this.lblCuotas.Name = "lblCuotas";
            this.lblCuotas.Size = new System.Drawing.Size(51, 17);
            this.lblCuotas.TabIndex = 2;
            this.lblCuotas.Text = "Cuotas:";
            // 
            // cmbCuotasTarjeta
            // 
            this.cmbCuotasTarjeta.BackColor = System.Drawing.Color.FromArgb(200, 210, 222);
            this.cmbCuotasTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCuotasTarjeta.FormattingEnabled = true;
            this.cmbCuotasTarjeta.Location = new System.Drawing.Point(68, 57);
            this.cmbCuotasTarjeta.Name = "cmbCuotasTarjeta";
            this.cmbCuotasTarjeta.Size = new System.Drawing.Size(168, 25);
            this.cmbCuotasTarjeta.TabIndex = 3;
            this.cmbCuotasTarjeta.SelectedIndexChanged += new System.EventHandler(this.cmbCuotasTarjeta_SelectedIndexChanged);
            // 
            // rdbTarjeta
            // 
            this.rdbTarjeta.AutoSize = true;
            this.rdbTarjeta.Location = new System.Drawing.Point(135, 25);
            this.rdbTarjeta.Name = "rdbTarjeta";
            this.rdbTarjeta.Size = new System.Drawing.Size(65, 21);
            this.rdbTarjeta.TabIndex = 1;
            this.rdbTarjeta.TabStop = true;
            this.rdbTarjeta.Text = "Tarjeta";
            this.rdbTarjeta.UseVisualStyleBackColor = true;
            this.rdbTarjeta.CheckedChanged += new System.EventHandler(this.rdbFormaPago_CheckedChanged);
            // 
            // rdbEfectivo
            // 
            this.rdbEfectivo.AutoSize = true;
            this.rdbEfectivo.Location = new System.Drawing.Point(12, 25);
            this.rdbEfectivo.Name = "rdbEfectivo";
            this.rdbEfectivo.Size = new System.Drawing.Size(117, 21);
            this.rdbEfectivo.TabIndex = 0;
            this.rdbEfectivo.TabStop = true;
            this.rdbEfectivo.Text = "Efvo. (10% desc)";
            this.rdbEfectivo.UseVisualStyleBackColor = true;
            this.rdbEfectivo.CheckedChanged += new System.EventHandler(this.rdbFormaPago_CheckedChanged);
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.FromArgb(140, 210, 180);
            this.btnPagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagar.FlatAppearance.BorderSize = 0;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPagar.ForeColor = System.Drawing.Color.FromArgb(15, 35, 25);
            this.btnPagar.Location = new System.Drawing.Point(35, 345);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(240, 40);
            this.btnPagar.TabIndex = 9;
            this.btnPagar.Text = "REGISTRAR PAGO Y HABILITAR";
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // btnComprobante
            // 
            this.btnComprobante.BackColor = System.Drawing.Color.FromArgb(100, 155, 255);
            this.btnComprobante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComprobante.FlatAppearance.BorderSize = 0;
            this.btnComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComprobante.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnComprobante.ForeColor = System.Drawing.Color.FromArgb(15, 25, 45);
            this.btnComprobante.Location = new System.Drawing.Point(290, 345);
            this.btnComprobante.Name = "btnComprobante";
            this.btnComprobante.Size = new System.Drawing.Size(135, 40);
            this.btnComprobante.TabIndex = 10;
            this.btnComprobante.Text = "COMPROBANTE";
            this.btnComprobante.UseVisualStyleBackColor = false;
            this.btnComprobante.Click += new System.EventHandler(this.btnComprobante_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(195, 205, 215);
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(40, 20, 20);
            this.btnCancelar.Location = new System.Drawing.Point(440, 345);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 40);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmCobroCuota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 20, 24);
            this.ClientSize = new System.Drawing.Size(600, 410);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnComprobante);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.grpFormaPago);
            this.Controls.Add(this.grpTipoCuota);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lblMontoTitulo);
            this.Controls.Add(this.lblDetalleCuotas);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscarDni);
            this.Controls.Add(this.lblBuscarDni);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCobroCuota";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Módulo de Cobro de Cuotas";
            this.Load += new System.EventHandler(this.frmCobroCuota_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.grpTipoCuota.ResumeLayout(false);
            this.grpTipoCuota.PerformLayout();
            this.grpFormaPago.ResumeLayout(false);
            this.grpFormaPago.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitulo;
        private System.Windows.Forms.Label lblBuscarDni;
        private System.Windows.Forms.TextBox txtBuscarDni;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblInfoCliente;
        private System.Windows.Forms.Label lblInfoCategoria;
        private System.Windows.Forms.Label lblInfoEstado;
        private System.Windows.Forms.Label lblMontoTitulo;
        private System.Windows.Forms.Label lblDetalleCuotas;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.GroupBox grpTipoCuota;
        private System.Windows.Forms.RadioButton rdbDiaria;
        private System.Windows.Forms.RadioButton rdbMensual;
        private System.Windows.Forms.GroupBox grpFormaPago;
        private System.Windows.Forms.RadioButton rdbTarjeta;
        private System.Windows.Forms.RadioButton rdbEfectivo;
        private System.Windows.Forms.Label lblCuotas;
        private System.Windows.Forms.ComboBox cmbCuotasTarjeta;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnComprobante;
        private System.Windows.Forms.Button btnCancelar;
    }
}
