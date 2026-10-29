namespace Club_Deportivo
{
    partial class frmReporteVencimientos
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
            this.lblFiltro = new System.Windows.Forms.Label();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.dgvVencimientos = new System.Windows.Forms.DataGridView();
            this.colDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVencimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(218, 226, 236);
            this.pnlHeader.Controls.Add(this.lblHeaderTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(680, 42);
            this.pnlHeader.TabIndex = 4;
            // 
            // lblHeaderTitulo
            // 
            this.lblHeaderTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitulo.ForeColor = System.Drawing.Color.FromArgb(20, 30, 45);
            this.lblHeaderTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblHeaderTitulo.Name = "lblHeaderTitulo";
            this.lblHeaderTitulo.Size = new System.Drawing.Size(680, 42);
            this.lblHeaderTitulo.TabIndex = 0;
            this.lblHeaderTitulo.Text = "REPORTE DE ESTADO Y VENCIMIENTO DE CUOTAS";
            this.lblHeaderTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(240, 245, 250);
            this.lblCategoria.Location = new System.Drawing.Point(40, 58);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(73, 17);
            this.lblCategoria.TabIndex = 0;
            this.lblCategoria.Text = "Categoría:";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.BackColor = System.Drawing.Color.FromArgb(200, 210, 222);
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCategoria.ForeColor = System.Drawing.Color.FromArgb(20, 30, 45);
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(120, 55);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(145, 25);
            this.cmbCategoria.TabIndex = 1;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFiltro.ForeColor = System.Drawing.Color.FromArgb(240, 245, 250);
            this.lblFiltro.Location = new System.Drawing.Point(285, 58);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(107, 17);
            this.lblFiltro.TabIndex = 2;
            this.lblFiltro.Text = "Criterio / Fecha:";
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.BackColor = System.Drawing.Color.FromArgb(200, 210, 222);
            this.cmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbFiltro.ForeColor = System.Drawing.Color.FromArgb(20, 30, 45);
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Location = new System.Drawing.Point(400, 55);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(240, 25);
            this.cmbFiltro.TabIndex = 3;
            this.cmbFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // dgvVencimientos
            // 
            this.dgvVencimientos.AllowUserToAddRows = false;
            this.dgvVencimientos.AllowUserToDeleteRows = false;
            this.dgvVencimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVencimientos.BackgroundColor = System.Drawing.Color.FromArgb(200, 210, 222);
            this.dgvVencimientos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVencimientos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(218, 226, 236);
            this.dgvVencimientos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(20, 30, 45);
            this.dgvVencimientos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvVencimientos.ColumnHeadersHeight = 32;
            this.dgvVencimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVencimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDni,
            this.colNombre,
            this.colCategoria,
            this.colVencimiento});
            this.dgvVencimientos.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(235, 240, 246);
            this.dgvVencimientos.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(25, 30, 40);
            this.dgvVencimientos.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvVencimientos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(100, 155, 255);
            this.dgvVencimientos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(15, 25, 45);
            this.dgvVencimientos.EnableHeadersVisualStyles = false;
            this.dgvVencimientos.GridColor = System.Drawing.Color.FromArgb(170, 185, 200);
            this.dgvVencimientos.Location = new System.Drawing.Point(40, 95);
            this.dgvVencimientos.Name = "dgvVencimientos";
            this.dgvVencimientos.ReadOnly = true;
            this.dgvVencimientos.RowHeadersVisible = false;
            this.dgvVencimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVencimientos.Size = new System.Drawing.Size(600, 235);
            this.dgvVencimientos.TabIndex = 2;
            // 
            // colDni
            // 
            this.colDni.FillWeight = 75F;
            this.colDni.HeaderText = "DNI";
            this.colDni.Name = "colDni";
            this.colDni.ReadOnly = true;
            // 
            // colNombre
            // 
            this.colNombre.FillWeight = 140F;
            this.colNombre.HeaderText = "APELLIDO Y NOMBRE";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            // 
            // colCategoria
            // 
            this.colCategoria.FillWeight = 85F;
            this.colCategoria.HeaderText = "CATEGORÍA";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            // 
            // colVencimiento
            // 
            this.colVencimiento.FillWeight = 80F;
            this.colVencimiento.HeaderText = "VENCIMIENTO";
            this.colVencimiento.Name = "colVencimiento";
            this.colVencimiento.ReadOnly = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(100, 155, 255);
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(15, 25, 45);
            this.btnImprimir.Location = new System.Drawing.Point(60, 345);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(250, 42);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "IMPRIMIR REPORTE";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(195, 205, 215);
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnVolver.ForeColor = System.Drawing.Color.FromArgb(25, 35, 50);
            this.btnVolver.Location = new System.Drawing.Point(370, 345);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(250, 42);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "VOLVER AL MENÚ";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmReporteVencimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 20, 24);
            this.ClientSize = new System.Drawing.Size(680, 410);
            this.Controls.Add(this.cmbFiltro);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dgvVencimientos);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmReporteVencimientos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Cuotas y Vencimientos";
            this.Load += new System.EventHandler(this.frmReporteVencimientos_Load);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVencimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitulo;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.DataGridView dgvVencimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVencimiento;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnVolver;
    }
}
