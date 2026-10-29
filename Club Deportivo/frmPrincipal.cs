using Club_Deportivo.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Club_Deportivo
{
    public partial class frmPrincipal : Form
    {
        // Instancia de la capa de datos
        private Cliente capaDatos = new Cliente();
        private TextBox txtDniIngreso = new TextBox();

        public frmPrincipal()
        {
            InitializeComponent();
            FormStyler.ApplyPinkStyle(this);
        }
        /// <summary>
        /// Proceso de Control de Acceso al Gimnasio (CU06).
        /// Solicita el DNI del cliente, valida su categoría (Socio vs No Socio), comprueba
        /// vigencia médica (Apto Físico) y estado de cuota, permitiendo registrar excepciones.
        /// </summary>
        // Simula el punto de acceso (molinete/recepcion): evalua cuota al dia y apto medico vigente, auditando el resultado
        private void btnControlIngreso_Click(object sender, EventArgs e)
        {
            // 1. Solicitud de identificación en el punto de acceso
            string dniIngresado = PromptInput("Control de Acceso al Gimnasio", "Ingrese o escanee el número de DNI del cliente:");
            if (string.IsNullOrEmpty(dniIngresado)) return;

            if (!int.TryParse(dniIngresado.Trim(), out int dniConsultar))
            {
                MessageBox.Show("El DNI debe contener únicamente caracteres numéricos.", "Formato Inválido", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Consulta de datos del cliente en la base de datos
            DataTable dt = capaDatos.BuscarClientePorDni(dniConsultar);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("❌ INGRESO DENEGADO: El DNI " + dniConsultar + " no se encuentra registrado en el sistema.\n\n" +
                                "Debe dirigirse a Administración para realizar el registro inicial.",
                                "Control de Acceso - No Registrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow fila = dt.Rows[0];
            string nombreCompleto = fila["Nombre"] + " " + fila["Apellido"];
            bool esSocio = fila["IdCarnet"] != DBNull.Value;
            string categoriaVisual = esSocio ? "SOCIO (Carnet N°: " + fila["nroCarnet"] + ")" : "NO SOCIO (Pase Diario)";

            // 3. Verificación del estado del Apto Físico (Requisito médico)
            string estadoApto = capaDatos.ValidarIngresoSocio(dniConsultar);

            // 4. Verificación del estado de pago (Requisito administrativo)
            DateTime? ultimoVenc = (fila["ultimoVencimiento"] != DBNull.Value) ? (DateTime?)Convert.ToDateTime(fila["ultimoVencimiento"]) : null;

            bool cuotaAlDia = false;
            string detallePago = "";

            if (esSocio)
            {
                // Para Socios: la cuota mensual debe encontrarse al día
                if (ultimoVenc.HasValue)
                {
                    if (ultimoVenc.Value.Date >= DateTime.Today)
                    {
                        cuotaAlDia = true;
                        detallePago = "Cuota mensual al día (Vence: " + ultimoVenc.Value.ToShortDateString() + ")";
                    }
                    else
                    {
                        detallePago = "Cuota mensual VENCIDA desde el " + ultimoVenc.Value.ToShortDateString();
                    }
                }
                else
                {
                    detallePago = "Sin registros de cuota mensual abonada";
                }
            }
            else
            {
                // Para No Socios: el pase diario debe coincidir exactamente con la fecha de hoy
                if (ultimoVenc.HasValue && ultimoVenc.Value.Date == DateTime.Today)
                {
                    cuotaAlDia = true;
                    detallePago = "Pase diario abonado para el día de hoy";
                }
                else
                {
                    detallePago = "Pase diario no abonado para la fecha actual";
                }
            }

            // 5. Evaluación de acceso, persistencia de auditoría y emisión de veredicto
            if (estadoApto == "Vigente" && cuotaAlDia)
            {
                // Registro histórico en la base de datos (Auditoría)
                capaDatos.RegistrarAcceso(dniConsultar, "HABILITADO", "Apto físico vigente y cuota al día", "Sistema / Acceso Regular");

                MessageBox.Show("✅ ¡ACCESO PERMITIDO!\n\n" +
                                "• Cliente: " + nombreCompleto + " (DNI " + dniConsultar + ")\n" +
                                "• Categoría: " + categoriaVisual + "\n" +
                                "• Certificación Médica: VIGENTE\n" +
                                "• Estado Administrativo: " + detallePago + "\n\n" +
                                "Acceso habilitado al gimnasio e instalaciones. Movimiento auditado con éxito.",
                                "Control de Acceso - HABILITADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Detalle explícito de las causas de denegación
                string motivosRechazo = "";
                if (estadoApto != "Vigente")
                {
                    motivosRechazo += "• Restricción Médica: Apto físico " + (estadoApto == "Vencido" ? "VENCIDO" : "NO REGISTRADO") + ".\n";
                }
                if (!cuotaAlDia)
                {
                    motivosRechazo += "• Restricción Administrativa: " + detallePago + ".\n";
                }

                string mensajeDenegado = "⛔ ACCESO DENEGADO AL GIMNASIO\n\n" +
                                        "• Cliente: " + nombreCompleto + " (DNI " + dniConsultar + ")\n" +
                                        "• Condición: " + categoriaVisual + "\n\n" +
                                        "Causas del rechazo:\n" + motivosRechazo + "\n" +
                                        "¿Desea que el Administrativo autorice un ACCESO EXCEPCIONAL POR HOY?";

                DialogResult respuestaExcepcion = MessageBox.Show(mensajeDenegado, "Control de Acceso - DENEGADO",
                                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Gestión de la excepción administrativa
                if (respuestaExcepcion == DialogResult.Yes)
                {
                    string motivoAdmin = PromptInput("Autorización Excepcional", "Ingrese el motivo de la justificación administrativa (ej: Certificado médico en trámite / Promesa de pago):");
                    if (!string.IsNullOrEmpty(motivoAdmin.Trim()))
                    {
                        // Registro de la excepción en la base de datos (Auditoría)
                        capaDatos.RegistrarAcceso(dniConsultar, "EXCEPCIONAL", motivoAdmin.Trim(), "Administrativo en turno");

                        MessageBox.Show("⚠️ INGRESO AUTORIZADO POR EXCEPCIÓN ADMINISTRATIVA\n\n" +
                                        "• Cliente: " + nombreCompleto + " [" + categoriaVisual + "]\n" +
                                        "• Autorizado por: Administrativo en turno\n" +
                                        "• Motivo registrado: " + motivoAdmin.Trim() + "\n" +
                                        "• Validez: Exclusivamente por la jornada actual\n\n" +
                                        "La excepción quedó registrada en la base de datos de accesos.",
                                        "Excepción Aprobada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Si canceló o no puso motivo, se audita el rechazo definitivo
                        capaDatos.RegistrarAcceso(dniConsultar, "DENEGADO", motivosRechazo.Replace("\n", " "), "Sistema / Sin justificación");
                    }
                }
                else
                {
                    // Registro del rechazo en la base de datos (Auditoría)
                    capaDatos.RegistrarAcceso(dniConsultar, "DENEGADO", motivosRechazo.Replace("\n", " "), "Sistema");
                }
            }
        }

        // Opcion 4: Cierra la sesion del operador y regresa al login
        private void btn4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Opcion 1: Abre el modulo de Gestion de Clientes y Carnets
        private void btn1_Click(object sender, EventArgs e)
        {
            frmAltaSocio alta = new frmAltaSocio();
            alta.Show();
        }

        // Opcion 2: Abre el modulo de Cobro de Cuotas (mensuales o diarias)
        private void btn2_Click(object sender, EventArgs e)
        {
            frmCobroCuota cobro = new frmCobroCuota();
            cobro.Show();
        }

        // Opcion 3: Abre el Reporte de Vencimientos con doble filtro (categoria y fechas)
        private void btn3_Click(object sender, EventArgs e)
        {
            frmReporteVencimientos reporte = new frmReporteVencimientos();
            reporte.Show();
        }

        // Gestiona el certificado medico: si esta vigente ofrece verlo/actualizarlo; si esta vencido o no existe abre el alta
        private void btnGestionarAptoFisico_Click(object sender, EventArgs e)
        {
            // 1. Solicitamos el DNI del cliente
            string dniIngresado = PromptInput("Gestión de Apto Físico", "Ingrese el DNI del cliente para gestionar su apto físico:");
            if (string.IsNullOrEmpty(dniIngresado)) return;

            if (!int.TryParse(dniIngresado.Trim(), out int dniCliente))
            {
                MessageBox.Show("Por favor, ingrese un nmero de DNI valido.", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Verificamos si el cliente existe en el sistema
            DataTable dt = capaDatos.BuscarClientePorDni(dniCliente);
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("El DNI " + dniCliente + " no se encuentra registrado en el sistema.\n\nDebe registrar primero al cliente en Gestin de Clientes.", "Cliente No Registrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow fila = dt.Rows[0];
            string nombreCompleto = fila["Nombre"] + " " + fila["Apellido"];

            // 3. Evaluamos el estado del apto fsico
            string estadoApto = capaDatos.ValidarIngresoSocio(dniCliente);

            Club_Deportivo.Entidades.E_Cliente clienteAEditar = new Club_Deportivo.Entidades.E_Cliente();
            clienteAEditar.Dni = dniCliente;
            clienteAEditar.Nombre = Convert.ToString(fila["Nombre"]);
            clienteAEditar.Apellido = Convert.ToString(fila["Apellido"]);

            if (estadoApto == "Vigente")
            {
                DialogResult dialog = MessageBox.Show(
                    "El cliente " + nombreCompleto + " (DNI: " + dniCliente + ") posee Apto Fsico VIGENTE.\n\nDesea ver o modificar la ficha mdica?",
                    "Apto Fsico Vigente",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (dialog == DialogResult.Yes)
                {
                    frmAptoFisico frmApto = new frmAptoFisico(clienteAEditar);
                    frmApto.ShowDialog();
                }
            }
            else
            {
                // Si est Vencido o No Registrado, informamos y abrimos directamente el formulario para cargarlo
                string detalle = (estadoApto == "Vencido") ? "se encuentra VENCIDO" : "NO est registrado";
                MessageBox.Show("El Apto Fsico del cliente " + nombreCompleto + " " + detalle + ".\n\nA continuacin se abrir el formulario para su registro / renovacin.", "Apto Fsico Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                frmAptoFisico frmApto = new frmAptoFisico(clienteAEditar);
                frmApto.ShowDialog();
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        // Método auxiliar simple para pedir texto al usuario sin depender de Microsoft.VisualBasic
        private string PromptInput(string title, string prompt)
        {
            using (Form promptForm = new Form())
            {
                promptForm.Width = 460;
                promptForm.Height = 180;
                promptForm.Text = title;
                promptForm.BackColor = FormStyler.ColorFondoOscuro;
                promptForm.ForeColor = FormStyler.ColorEtiqueta;
                promptForm.StartPosition = FormStartPosition.CenterScreen;
                promptForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                promptForm.MaximizeBox = false;
                promptForm.MinimizeBox = false;
                promptForm.Font = new Font("Segoe UI", 9.5F);

                Label textLabel = new Label()
                {
                    Left = 20,
                    Top = 15,
                    Text = prompt,
                    Width = 405,
                    Height = 40,
                    ForeColor = FormStyler.ColorEtiqueta,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Regular)
                };

                TextBox inputBox = new TextBox()
                {
                    Left = 20,
                    Top = 60,
                    Width = 405,
                    BackColor = FormStyler.ColorCaja,
                    ForeColor = FormStyler.ColorTextoOscuro,
                    BorderStyle = BorderStyle.FixedSingle,
                    Font = new Font("Segoe UI", 10.5F)
                };

                Button confirmation = new Button()
                {
                    Text = "ACEPTAR",
                    Left = 220,
                    Width = 95,
                    Top = 95,
                    Height = 32,
                    BackColor = FormStyler.ColorBotonAzul,
                    ForeColor = Color.FromArgb(15, 25, 45),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    Cursor = Cursors.Hand,
                    DialogResult = DialogResult.OK
                };
                confirmation.FlatAppearance.BorderSize = 0;

                Button cancel = new Button()
                {
                    Text = "CANCELAR",
                    Left = 330,
                    Width = 95,
                    Top = 95,
                    Height = 32,
                    BackColor = FormStyler.ColorBotonGris,
                    ForeColor = Color.FromArgb(25, 35, 50),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    Cursor = Cursors.Hand,
                    DialogResult = DialogResult.Cancel
                };
                cancel.FlatAppearance.BorderSize = 0;

                confirmation.Click += (sender, e) => { promptForm.Close(); };
                cancel.Click += (sender, e) => { promptForm.Close(); };

                promptForm.Controls.Add(confirmation);
                promptForm.Controls.Add(cancel);
                promptForm.Controls.Add(textLabel);
                promptForm.Controls.Add(inputBox);
                promptForm.AcceptButton = confirmation;
                promptForm.CancelButton = cancel;

                var result = promptForm.ShowDialog();
                if (result == DialogResult.OK)
                    return inputBox.Text;
                else
                    return string.Empty;
            }
        }
    }
}
