using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Club_Deportivo
{
    // Formulario que visualiza e imprime el comprobante de pago oficial de cuota o pase diario
    public partial class frmComprobante : Form
    {
        // Propiedades publicas para recibir los datos del cobro efectuado
        public string SocioNombre { get; set; }
        public string DniCliente { get; set; }
        public string Categoria { get; set; }
        public string TipoCuota { get; set; }
        public string FormaPago { get; set; }
        public decimal MontoAbonado { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public frmComprobante()
        {
            InitializeComponent();
            FormStyler.ApplyPinkStyle(this);
        }

        // Carga los datos de la transaccion en los controles de la constancia
        private void frmComprobante_Load(object sender, EventArgs e)
        {
            lblFechaHoy.Text = DateTime.Now.ToShortDateString();
            this.lblSocio.Text = SocioNombre;
            lblDni.Text = DniCliente;
            lblCategoria.Text = Categoria;
            lblTipoCuota.Text = TipoCuota;
            lblFormaPago.Text = FormaPago;
            lblMonto.Text = "$" + MontoAbonado.ToString("N2");
            lblVencimiento.Text = FechaVencimiento.ToShortDateString();
        }

        // Envia el comprobante a imprimir ocultando temporalmente los botones de accion
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            btnImprimir.Visible = false;
            btnCerrar.Visible = false;

            FormBorderStyle estiloOriginal = this.FormBorderStyle;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Refresh();

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(ImprimirRecibo);
            pd.Print();

            this.FormBorderStyle = estiloOriginal;
            btnImprimir.Visible = true;
            btnCerrar.Visible = true;

            MessageBox.Show("Comprobante enviado a impresión exitosamente.", "AVISO DEL SISTEMA",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Captura el documento graficamente como mapa de bits y lo plasma en la pagina
        private void ImprimirRecibo(object o, PrintPageEventArgs e)
        {
            int ancho = this.ClientSize.Width;
            int alto = this.ClientSize.Height;

            Bitmap img = new Bitmap(ancho, alto);
            Rectangle bounds = new Rectangle(0, 0, ancho, alto);

            this.DrawToBitmap(img, bounds);
            Point p = new Point(100, 100);
            e.Graphics.DrawImage(img, p);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
