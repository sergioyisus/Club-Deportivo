using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Club_Deportivo.Datos;

namespace Club_Deportivo
{
    public partial class frmCobroCuota : Form
    {
        private Cliente capaDatos = new Cliente();
        private frmComprobante docComprobante = new frmComprobante();

        // Variables para guardar los datos del cliente actual buscado
        private int dniActual = 0;
        private string nombreCompletoActual = "";
        private string categoriaActual = "";
        private bool clienteEncontrado = false;

        public frmCobroCuota()
        {
            InitializeComponent();
            FormStyler.ApplyPinkStyle(this);
        }

        private void frmCobroCuota_Load(object sender, EventArgs e)
        {
            // Opciones de cuotas con tarjeta (según Contexto: promociones en 3 y 6 cuotas)
            cmbCuotasTarjeta.Items.Clear();
            cmbCuotasTarjeta.Items.Add("1 pago (Total)");
            cmbCuotasTarjeta.Items.Add("3 cuotas sin interés");
            cmbCuotasTarjeta.Items.Add("6 cuotas sin interés");
            cmbCuotasTarjeta.SelectedIndex = 0;

            // Valores por defecto
            rdbMensual.Checked = true;
            rdbEfectivo.Checked = true;
            ActualizarMontoSegunSeleccion();
            btnPagar.Enabled = false;
            btnComprobante.Enabled = false;
        }

        // Busca el cliente por DNI: determina si es Socio o No Socio, evalua estado de cuota y carga ultimo pago
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscarDni.Text))
            {
                MessageBox.Show("Por favor, ingrese un número de DNI para buscar.", "AVISO DEL SISTEMA",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtBuscarDni.Text.Trim(), out int dni))
            {
                MessageBox.Show("El DNI debe contener solo números.", "Formato Inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = capaDatos.BuscarClientePorDni(dni);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow fila = dt.Rows[0];
                dniActual = Convert.ToInt32(fila["Dni"]);
                string nombre = Convert.ToString(fila["Nombre"]);
                string apellido = Convert.ToString(fila["Apellido"]);
                nombreCompletoActual = nombre + " " + apellido;

                bool tieneCarnet = fila["IdCarnet"] != DBNull.Value;
                DateTime? ultimoVenc = (fila["ultimoVencimiento"] != DBNull.Value) ? (DateTime?)Convert.ToDateTime(fila["ultimoVencimiento"]) : null;

                // 1. Lógica diferenciada: Socio vs. No Socio
                if (tieneCarnet)
                {
                    string nroCarnet = Convert.ToString(fila["nroCarnet"]);
                    categoriaActual = "SOCIO (Nro Carnet: " + nroCarnet + ")";
                    rdbMensual.Checked = true;
                    rdbMensual.Enabled = true;
                    rdbDiaria.Enabled = false; // El socio abona únicamente cuota mensual

                    // Control de vencimiento e inhabilitación automática para socios
                    if (ultimoVenc.HasValue)
                    {
                        if (ultimoVenc.Value.Date < DateTime.Today)
                        {
                            lblInfoEstado.Text = "Estado: INHABILITADO (Cuota vencida el " + ultimoVenc.Value.ToShortDateString() + ")";
                            lblInfoEstado.ForeColor = Color.FromArgb(170, 20, 20);
                        }
                        else
                        {
                            lblInfoEstado.Text = "Estado: HABILITADO (Vence el " + ultimoVenc.Value.ToShortDateString() + ")";
                            lblInfoEstado.ForeColor = Color.FromArgb(15, 110, 40);
                        }
                    }
                    else
                    {
                        lblInfoEstado.Text = "Estado: INHABILITADO (Sin cuotas abonadas)";
                        lblInfoEstado.ForeColor = Color.FromArgb(170, 20, 20);
                    }
                }
                else
                {
                    categoriaActual = "NO SOCIO (Pase Diario)";
                    rdbDiaria.Checked = true;
                    rdbDiaria.Enabled = true;
                    rdbMensual.Enabled = false; // El no socio abona únicamente cuota diaria

                    // Control de no socios: su acceso vence al finalizar el mismo día
                    if (ultimoVenc.HasValue && ultimoVenc.Value.Date == DateTime.Today)
                    {
                        lblInfoEstado.Text = "Estado: HABILITADO (Pase diario de hoy vigente)";
                        lblInfoEstado.ForeColor = Color.FromArgb(15, 110, 40);
                    }
                    else
                    {
                        lblInfoEstado.Text = "Estado: INHABILITADO (Pase diario pendiente)";
                        lblInfoEstado.ForeColor = Color.FromArgb(170, 20, 20);
                    }
                }

                lblInfoCliente.Text = "Cliente: " + nombreCompletoActual;
                lblInfoCategoria.Text = "Categoría: " + categoriaActual;

                ActualizarMontoSegunSeleccion();

                clienteEncontrado = true;
                btnPagar.Enabled = true;

                // Verificamos si posee un comprobante anterior para permitir reemisin o consulta
                DataTable dtUltimoPago = capaDatos.ObtenerUltimoPagoCliente(dniActual);
                if (dtUltimoPago != null && dtUltimoPago.Rows.Count > 0)
                {
                    DataRow filaPago = dtUltimoPago.Rows[0];
                    docComprobante.SocioNombre = nombreCompletoActual;
                    docComprobante.DniCliente = dniActual.ToString();
                    docComprobante.Categoria = categoriaActual;
                    docComprobante.TipoCuota = filaPago["tipoCuota"].ToString();
                    docComprobante.FormaPago = filaPago.Table.Columns.Contains("formaPago") && filaPago["formaPago"] != DBNull.Value ? filaPago["formaPago"].ToString() : "Registrado";
                    docComprobante.MontoAbonado = Convert.ToDecimal(filaPago["montoAbonado"]);
                    docComprobante.FechaVencimiento = Convert.ToDateTime(filaPago["fechaDeVencimiento"]);
                    btnComprobante.Enabled = true;
                }
                else
                {
                    btnComprobante.Enabled = false;
                }            }
            else
            {
                MessageBox.Show("Cliente no registrado en el sistema.", "AVISO DEL SISTEMA",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarInfoCliente();
            }
        }

        private void rdbMensual_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMensual.Checked)
            {
                txtMonto.Text = "5000";
            }
            RecalcularDetalleCuotas();
        }

        private void rdbDiaria_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDiaria.Checked)
            {
                txtMonto.Text = "1500";
            }
            RecalcularDetalleCuotas();
        }

        private void rdbFormaPago_CheckedChanged(object sender, EventArgs e)
        {
            RecalcularDetalleCuotas();
        }

        private void cmbCuotasTarjeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecalcularDetalleCuotas();
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            RecalcularDetalleCuotas();
        }

        private void ActualizarMontoSegunSeleccion()
        {
            decimal montoBase = rdbMensual.Checked ? 5000m : 1500m;
            txtMonto.Text = montoBase.ToString("0");
            RecalcularDetalleCuotas();
        }

        // Recalcula en tiempo real el descuento del 10% en efectivo o la division en cuotas con tarjeta
        private void RecalcularDetalleCuotas()
        {
            if (!decimal.TryParse(txtMonto.Text.Trim(), out decimal montoActual) || montoActual <= 0)
            {
                lblDetalleCuotas.Text = "";
                return;
            }

            lblMontoTitulo.Text = "Monto a Pagar: $";

            if (rdbEfectivo.Checked)
            {
                lblCuotas.Visible = false;
                cmbCuotasTarjeta.Visible = false;

                decimal totalConDescuento = montoActual * 0.90m;
                lblDetalleCuotas.Text = "(10% desc. efvo: $" + totalConDescuento.ToString("0.##") + ")";
                lblDetalleCuotas.ForeColor = Color.FromArgb(80, 215, 160);
            }
            else
            {
                lblCuotas.Visible = true;
                cmbCuotasTarjeta.Visible = true;

                int cuotas = 1;
                if (cmbCuotasTarjeta.SelectedIndex == 1) cuotas = 3;
                else if (cmbCuotasTarjeta.SelectedIndex == 2) cuotas = 6;

                if (cuotas > 1)
                {
                    decimal valorCuota = montoActual / cuotas;
                    lblDetalleCuotas.Text = "(" + cuotas + " cuotas de $" + valorCuota.ToString("N2") + ")";
                    lblDetalleCuotas.ForeColor = Color.FromArgb(90, 200, 250);
                }
                else
                {
                    lblDetalleCuotas.Text = "(1 pago sin recargo)";
                    lblDetalleCuotas.ForeColor = Color.FromArgb(200, 210, 225);
                }
            }
        }

        // Registra el cobro en MySQL mediante el Stored Procedure 'RegistrarCobroCuota', habilita al cliente y emite comprobante
        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (!clienteEncontrado)
            {
                MessageBox.Show("Debe buscar primero un cliente válido.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtMonto.Text.Trim(), out decimal montoBase) || montoBase <= 0)
            {
                MessageBox.Show("Ingrese un monto válido.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipoCuota = rdbMensual.Checked ? "Mensual" : "Diaria";
            string formaPago = "Efectivo";

            if (rdbTarjeta.Checked)
            {
                int cuotas = 1;
                if (cmbCuotasTarjeta.SelectedIndex == 1) cuotas = 3;
                else if (cmbCuotasTarjeta.SelectedIndex == 2) cuotas = 6;

                if (cuotas > 1)
                {
                    decimal valorCuota = montoBase / cuotas;
                    formaPago = "Tarjeta (" + cuotas + " cuotas de $" + valorCuota.ToString("N2") + ")";
                }
                else
                {
                    formaPago = "Tarjeta (1 pago)";
                }
            }

            // Para el Stored Procedure de MySQL se envía el tipo básico "Efectivo" o "Tarjeta"
            string formaPagoSP = rdbEfectivo.Checked ? "Efectivo" : "Tarjeta";

            // Registramos el pago en MySQL mediante el procedimiento almacenado
            string rta = capaDatos.RegistrarCobro(dniActual, montoBase, tipoCuota, formaPagoSP, out DateTime proximoVenc, out decimal montoFinal);

            if (rta == "OK")
            {
                // Asignamos los datos al documento de salida
                docComprobante.SocioNombre = nombreCompletoActual;
                docComprobante.DniCliente = dniActual.ToString();
                docComprobante.Categoria = categoriaActual;
                docComprobante.TipoCuota = tipoCuota;
                docComprobante.FormaPago = formaPago;
                docComprobante.MontoAbonado = montoFinal;
                docComprobante.FechaVencimiento = proximoVenc;

                lblInfoEstado.Text = "Estado: HABILITADO (Vence: " + proximoVenc.ToShortDateString() + ")";
                lblInfoEstado.ForeColor = Color.DarkGreen;

                btnComprobante.Enabled = true;
                btnPagar.Enabled = false;

                string mensaje = "¡Pago registrado y cliente HABILITADO con éxito!\n\n" +
                                 "• Nuevo Vencimiento: " + proximoVenc.ToShortDateString() + "\n" +
                                 "• Total Abonado: $" + montoFinal.ToString("N2") + " (" + formaPago + ")\n\n" +
                                 "¿Desea abrir e imprimir el comprobante de pago ahora?";

                DialogResult res = MessageBox.Show(mensaje, "PAGO REGISTRADO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    docComprobante.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Error al registrar cobro: " + rta, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Abre la constancia de pago oficial para reimpresion o entrega al cliente
        private void btnComprobante_Click(object sender, EventArgs e)
        {
            docComprobante.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarInfoCliente()
        {
            dniActual = 0;
            nombreCompletoActual = "";
            categoriaActual = "";
            clienteEncontrado = false;
            lblInfoCliente.Text = "Cliente: -";
            lblInfoCategoria.Text = "Categoría: -";
            lblInfoEstado.Text = "Estado: -";
            lblInfoEstado.ForeColor = Color.Black;
            btnPagar.Enabled = false;
            btnComprobante.Enabled = false;
        }
    }
}
