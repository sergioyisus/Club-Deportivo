using Club_Deportivo.Datos;
using Club_Deportivo.Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Club_Deportivo
{
    // Formulario de gestion y registro de apto fisico para socios y no socios
    public partial class frmAptoFisico : Form
    {
        private E_Cliente clienteActual;
        private Cliente datosCliente = new Cliente();

        public frmAptoFisico(E_Cliente cliente)
        {
            InitializeComponent();
            this.clienteActual = cliente;
            FormStyler.ApplyPinkStyle(this);
        }

        // Inicializa los selectores y recupera el estado medico previo del cliente
        private void frmAptoFisico_Load(object sender, EventArgs e)
        {
            // Opciones de estado medico
            cmbEstadoApto.Items.Clear();
            cmbEstadoApto.Items.Add("Vigente");
            cmbEstadoApto.Items.Add("Vencido");
            cmbEstadoApto.SelectedIndex = 0;

            // Fechas sugeridas: presentado hoy y vencimiento a 1 año
            dtpPresentacion.Value = DateTime.Today;
            dtpVencimiento.Value = DateTime.Today.AddYears(1);

            // Consultamos los datos del cliente para mostrar su categoria y nombre
            try
            {
                DataTable dt = datosCliente.BuscarClientePorDni(clienteActual.Dni);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];
                    string nombre = Convert.ToString(fila["Nombre"]);
                    string apellido = Convert.ToString(fila["Apellido"]);
                    bool esSocio = fila["IdCarnet"] != DBNull.Value;
                    string cat = esSocio ? "SOCIO" : "NO SOCIO";

                    this.lblSocio.Text = $"Cliente: {apellido}, {nombre} (DNI {clienteActual.Dni}) [{cat}]";
                }
                else
                {
                    this.lblSocio.Text = $"Cliente DNI: {clienteActual.Dni} (Sin ficha detallada)";
                }

                // Cargamos el estado medico que figura en la base de datos actualmente
                string estadoBD = datosCliente.ValidarIngresoSocio(clienteActual.Dni);
                if (!string.IsNullOrEmpty(estadoBD))
                {
                    for (int i = 0; i < cmbEstadoApto.Items.Count; i++)
                    {
                        if (string.Equals(cmbEstadoApto.Items[i].ToString(), estadoBD, StringComparison.OrdinalIgnoreCase))
                        {
                            cmbEstadoApto.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            catch
            {
                this.lblSocio.Text = $"Gestionando Apto del Cliente DNI: {clienteActual.Dni}";
            }
        }

        // Guarda el apto fisico validando fechas y evitando duplicar registros vigentes
        private void btnGuardarApto_Click(object sender, EventArgs e)
        {
            if (cmbEstadoApto.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione el estado del apto físico.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaPres = dtpPresentacion.Value;
            DateTime fechaVenc = dtpVencimiento.Value;
            string estado = cmbEstadoApto.SelectedItem.ToString();

            // Validacion de consistencia: la fecha de vencimiento debe ser posterior a la de presentacion
            if (fechaVenc <= fechaPres)
            {
                MessageBox.Show("La fecha de vencimiento no puede ser menor o igual a la fecha de presentación médica.", "Error de Fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Invocamos el procedimiento almacenado que actualiza la ficha existente sin duplicar
            string resultado = datosCliente.RegistrarAptoFisico(clienteActual.Dni, fechaVenc, estado);

            if (resultado == "OK" || resultado == "1" || resultado == "ACTUALIZADO")
            {
                string mensaje = resultado == "ACTUALIZADO"
                    ? "El cliente ya contaba con un apto vigente. La certificación médica fue ACTUALIZADA y extendida con éxito sin generar registros duplicados."
                    : "¡El apto físico se registró e impactó con éxito en la base de datos!";

                MessageBox.Show(mensaje, "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudieron guardar los cambios: " + resultado, "Error de Persistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
