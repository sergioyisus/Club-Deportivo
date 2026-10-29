using System.Drawing;
using System.Windows.Forms;

namespace Club_Deportivo
{
    public partial class frmAptoFisico : Form
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitulo = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblSocio = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstadoApto = new System.Windows.Forms.ComboBox();
            this.lblFechaPres = new System.Windows.Forms.Label();
            this.dtpPresentacion = new System.Windows.Forms.DateTimePicker();
            this.lblFechaVenc = new System.Windows.Forms.Label();
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.btnGuardarApto = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(218, 226, 236);
            this.pnlHeader.Controls.Add(this.lblHeaderTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(520, 42);
            this.pnlHeader.TabIndex = 6;
            // 
            // lblHeaderTitulo
            // 
            this.lblHeaderTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitulo.ForeColor = System.Drawing.Color.FromArgb(20, 30, 45);
            this.lblHeaderTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblHeaderTitulo.Name = "lblHeaderTitulo";
            this.lblHeaderTitulo.Size = new System.Drawing.Size(520, 42);
            this.lblHeaderTitulo.TabIndex = 0;
            this.lblHeaderTitulo.Text = "GESTIÓN DE APTO FÍSICO";
            this.lblHeaderTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(200, 210, 222);
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Controls.Add(this.lblSocio);
            this.pnlInfo.Location = new System.Drawing.Point(30, 58);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(460, 38);
            this.pnlInfo.TabIndex = 0;
            // 
            // lblSocio
            // 
            this.lblSocio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSocio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSocio.ForeColor = System.Drawing.Color.FromArgb(20, 30, 45);
            this.lblSocio.Location = new System.Drawing.Point(0, 0);
            this.lblSocio.Name = "lblSocio";
            this.lblSocio.Size = new System.Drawing.Size(458, 36);
            this.lblSocio.TabIndex = 0;
            this.lblSocio.Text = "Cliente: DNI -";
            this.lblSocio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(170, 180, 195);
            this.lblEstado.Location = new System.Drawing.Point(30, 115);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(107, 19);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.Text = "Estado del Apto:";
            // 
            // cmbEstadoApto
            // 
            this.cmbEstadoApto.BackColor = System.Drawing.Color.FromArgb(200, 210, 222);
            this.cmbEstadoApto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoApto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEstadoApto.FormattingEnabled = true;
            this.cmbEstadoApto.Location = new System.Drawing.Point(200, 112);
            this.cmbEstadoApto.Name = "cmbEstadoApto";
            this.cmbEstadoApto.Size = new System.Drawing.Size(290, 25);
            this.cmbEstadoApto.TabIndex = 2;
            // 
            // lblFechaPres
            // 
            this.lblFechaPres.AutoSize = true;
            this.lblFechaPres.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFechaPres.ForeColor = System.Drawing.Color.FromArgb(170, 180, 195);
            this.lblFechaPres.Location = new System.Drawing.Point(30, 155);
            this.lblFechaPres.Name = "lblFechaPres";
            this.lblFechaPres.Size = new System.Drawing.Size(147, 19);
            this.lblFechaPres.TabIndex = 3;
            this.lblFechaPres.Text = "Fecha de Presentación:";
            // 
            // dtpPresentacion
            // 
            this.dtpPresentacion.CalendarFont = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpPresentacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpPresentacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPresentacion.Location = new System.Drawing.Point(200, 152);
            this.dtpPresentacion.Name = "dtpPresentacion";
            this.dtpPresentacion.Size = new System.Drawing.Size(290, 25);
            this.dtpPresentacion.TabIndex = 4;
            // 
            // lblFechaVenc
            // 
            this.lblFechaVenc.AutoSize = true;
            this.lblFechaVenc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFechaVenc.ForeColor = System.Drawing.Color.FromArgb(170, 180, 195);
            this.lblFechaVenc.Location = new System.Drawing.Point(30, 195);
            this.lblFechaVenc.Name = "lblFechaVenc";
            this.lblFechaVenc.Size = new System.Drawing.Size(143, 19);
            this.lblFechaVenc.TabIndex = 5;
            this.lblFechaVenc.Text = "Fecha de Vencimiento:";
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.CalendarFont = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpVencimiento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimiento.Location = new System.Drawing.Point(200, 192);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(290, 25);
            this.dtpVencimiento.TabIndex = 6;
            // 
            // btnGuardarApto
            // 
            this.btnGuardarApto.BackColor = System.Drawing.Color.FromArgb(140, 210, 180);
            this.btnGuardarApto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarApto.FlatAppearance.BorderSize = 0;
            this.btnGuardarApto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarApto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardarApto.ForeColor = System.Drawing.Color.FromArgb(15, 35, 25);
            this.btnGuardarApto.Location = new System.Drawing.Point(70, 245);
            this.btnGuardarApto.Name = "btnGuardarApto";
            this.btnGuardarApto.Size = new System.Drawing.Size(180, 40);
            this.btnGuardarApto.TabIndex = 7;
            this.btnGuardarApto.Text = "GUARDAR APTO";
            this.btnGuardarApto.UseVisualStyleBackColor = false;
            this.btnGuardarApto.Click += new System.EventHandler(this.btnGuardarApto_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(195, 205, 215);
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnVolver.ForeColor = System.Drawing.Color.FromArgb(40, 20, 20);
            this.btnVolver.Location = new System.Drawing.Point(270, 245);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(180, 40);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "VOLVER";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmAptoFisico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 20, 24);
            this.ClientSize = new System.Drawing.Size(520, 310);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnGuardarApto);
            this.Controls.Add(this.dtpVencimiento);
            this.Controls.Add(this.lblFechaVenc);
            this.Controls.Add(this.dtpPresentacion);
            this.Controls.Add(this.lblFechaPres);
            this.Controls.Add(this.cmbEstadoApto);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAptoFisico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Apto Físico - Club Deportivo";
            this.Load += new System.EventHandler(this.frmAptoFisico_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitulo;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblSocio;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstadoApto;
        private System.Windows.Forms.Label lblFechaPres;
        private System.Windows.Forms.DateTimePicker dtpPresentacion;
        private System.Windows.Forms.Label lblFechaVenc;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.Button btnGuardarApto;
        private System.Windows.Forms.Button btnVolver;
    }
}