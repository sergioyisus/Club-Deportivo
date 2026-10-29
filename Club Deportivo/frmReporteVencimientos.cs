using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Club_Deportivo.Datos;

namespace Club_Deportivo
{
    // Formulario de visualizacion e impresion del reporte de vencimientos de cuotas (Caso de Uso C004)
    public partial class frmReporteVencimientos : Form
    {
        private Cliente capaDatos = new Cliente();

        public frmReporteVencimientos()
        {
            InitializeComponent();
            FormStyler.ApplyPinkStyle(this);
        }

        // Configura los dos filtros iniciales: por defecto Socios y Vencen Hoy (consigna de catedra)
        private void frmReporteVencimientos_Load(object sender, EventArgs e)
        {
            // 1. Filtro de Categoria
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Socios");
            cmbCategoria.Items.Add("No Socios");
            cmbCategoria.Items.Add("Todos");

            // 2. Filtro de Criterio de Fecha
            cmbFiltro.Items.Clear();
            cmbFiltro.Items.Add("Vencen Hoy");
            cmbFiltro.Items.Add("Vencidas / Morosos");
            cmbFiltro.Items.Add("Vigentes / Al Día");
            cmbFiltro.Items.Add("Todas");

            // Seleccion por defecto establecida en la consigna
            cmbCategoria.SelectedIndex = 0; // "Socios"
            cmbFiltro.SelectedIndex = 0;    // "Vencen Hoy"
        }

        // Dispara la recarga de la grilla ante cualquier cambio en los filtros
        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaGrilla();
        }

        // Carga y actualiza el DataGridView dinamicamente segun los dos filtros seleccionados
        public void CargaGrilla()
        {
            try
            {
                if (cmbCategoria.SelectedItem == null || cmbFiltro.SelectedItem == null)
                    return;

                string categoriaSeleccionada = cmbCategoria.SelectedItem.ToString();
                string criterioSeleccionado = cmbFiltro.SelectedItem.ToString();

                // Adaptamos el titulo dinamico del encabezado segun lo filtrado
                string etiquetaCat = categoriaSeleccionada == "Todos" ? "CLIENTES" : categoriaSeleccionada.ToUpper();
                switch (criterioSeleccionado)
                {
                    case "Vencen Hoy":
                        lblHeaderTitulo.Text = etiquetaCat + " CON CUOTA QUE VENCE HOY (" + DateTime.Today.ToShortDateString() + ")";
                        break;
                    case "Vencidas / Morosos":
                        lblHeaderTitulo.Text = "CUOTAS VENCIDAS / " + etiquetaCat + " MOROSOS";
                        break;
                    case "Vigentes / Al Día":
                        lblHeaderTitulo.Text = "CUOTAS VIGENTES / " + etiquetaCat + " AL DÍA";
                        break;
                    case "Todas":
                        lblHeaderTitulo.Text = "HISTORIAL GENERAL (" + etiquetaCat + ")";
                        break;
                }

                // Consultamos las cuotas en la base de datos aplicando los filtros
                DataTable dt = capaDatos.ObtenerReporteCuotas(criterioSeleccionado, categoriaSeleccionada);

                dgvVencimientos.Rows.Clear();

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        int renglon = dgvVencimientos.Rows.Add();
                        dgvVencimientos.Rows[renglon].Cells[0].Value = Convert.ToString(fila["Dni"]);
                        dgvVencimientos.Rows[renglon].Cells[1].Value = Convert.ToString(fila["ApellidoYNombre"]);
                        dgvVencimientos.Rows[renglon].Cells[2].Value = Convert.ToString(fila["Categoria"]);
                        dgvVencimientos.Rows[renglon].Cells[3].Value = Convert.ToString(fila["Vencimiento"]);
                    }
                }
                else
                {
                    // Regla de Negocio de la catedra (Flujo Alternativo del Caso de Uso):
                    // Notificar con el mensaje oficial cuando no existan socios que venzan hoy
                    if (categoriaSeleccionada == "Socios" && criterioSeleccionado == "Vencen Hoy")
                    {
                        MessageBox.Show("No hay vencimientos registrados para el día de hoy", "Vencimientos del Día",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MENSAJE DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Imprime el listado visualizado en el DataGridView
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvVencimientos.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros en la grilla para imprimir bajo este criterio.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnImprimir.Visible = false;
            btnVolver.Visible = false;

            FormBorderStyle estiloOriginal = this.FormBorderStyle;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Refresh();

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(ImprimirReporte);
            pd.Print();

            this.FormBorderStyle = estiloOriginal;
            btnImprimir.Visible = true;
            btnVolver.Visible = true;

            MessageBox.Show("Reporte impreso exitosamente.", "AVISO DEL SISTEMA",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ImprimirReporte(object o, PrintPageEventArgs e)
        {
            int ancho = this.ClientSize.Width;
            int alto = this.ClientSize.Height;

            Bitmap img = new Bitmap(ancho, alto);
            Rectangle bounds = new Rectangle(0, 0, ancho, alto);

            this.DrawToBitmap(img, bounds);
            Point p = new Point(60, 60);
            e.Graphics.DrawImage(img, p);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
