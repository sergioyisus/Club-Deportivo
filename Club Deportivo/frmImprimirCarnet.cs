using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Club_Deportivo
{
    // Formulario que visualiza e imprime la credencial / carnet de socio
    public partial class frmImprimirCarnet : Form
    {
        public frmImprimirCarnet(string nombre, string apellido, string dni, string nroCarnet)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Poblamos los datos del socio en la tarjeta
            lblNombre.Text = nombre;
            lblApellido.Text = apellido;
            lblDni.Text = dni;
            lblNroCarnet.Text = nroCarnet;
        }

        private void frmImprimirCarnet_Load(object sender, EventArgs e)
        {
        }

        // Envia a la impresora la tarjeta del carnet
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(ImprimirFormulario);
            pd.Print();

            MessageBox.Show("Credencial enviada a impresión exitosamente.", "AVISO DEL SISTEMA",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Dibuja unicamente el panel de la credencial (pnlCarnet) en el centro de la hoja
        private void ImprimirFormulario(object o, PrintPageEventArgs e)
        {
            int ancho = pnlCarnet.Width;
            int alto = pnlCarnet.Height;

            Bitmap img = new Bitmap(ancho, alto);
            Rectangle bounds = new Rectangle(0, 0, ancho, alto);

            pnlCarnet.DrawToBitmap(img, bounds);

            // Centramos la credencial en la hoja de impresion
            Point p = new Point(120, 120);
            e.Graphics.DrawImage(img, p);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
