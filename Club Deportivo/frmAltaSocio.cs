using Club_Deportivo.Entidades;
using Club_Deportivo.Datos;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Club_Deportivo
{
    public partial class frmAltaSocio : Form
    {
        private bool esSocioActual = false;
        private string nroCarnetActual = "";
        private Cliente datosCliente = new Cliente();

        public frmAltaSocio()
        {
            InitializeComponent();
            FormStyler.ApplyPinkStyle(this);
        }

        private void frmAltaSocio_Load(object sender, EventArgs e)
        {
            lblCategoriaInfo.Text = "Categoría: [Ingrese el DNI y presione 'BUSCAR FICHA' o complete para registrar nuevo cliente]";
        }

        // Búsqueda de cliente por DNI para ver/editar su ficha y verificar si es Socio o No Socio
        private void btnBuscarDni_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Por favor, ingrese un número de DNI para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDni.Text.Trim(), out int dni))
            {
                MessageBox.Show("El DNI debe ser numérico.", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = datosCliente.BuscarClientePorDni(dni);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow fila = dt.Rows[0];
                txtNombre.Text = fila["Nombre"].ToString();
                txtApellido.Text = fila["Apellido"].ToString();
                txtTelefono.Text = fila["telefono"] != DBNull.Value ? fila["telefono"].ToString() : "";
                txtEmail.Text = fila["email"] != DBNull.Value ? fila["email"].ToString() : "";

                bool esSocio = fila["IdCarnet"] != DBNull.Value;
                if (esSocio)
                {
                    esSocioActual = true;
                    nroCarnetActual = fila["nroCarnet"].ToString();
                    lblCategoriaInfo.Text = "Categoría: SOCIO REGISTRADO (Carnet Nº: " + nroCarnetActual + ") - Cuota mensual";
                    lblCategoriaInfo.ForeColor = Color.FromArgb(15, 80, 35);
                    pnlCategoria.BackColor = System.Drawing.Color.FromArgb(195, 230, 215);
                    btnEmitir.Text = "VER / IMPRIMIR CARNET";
                    btnEmitir.Enabled = true;
                }
                else
                {
                    esSocioActual = false;
                    nroCarnetActual = "";
                    lblCategoriaInfo.Text = "Categoría: NO SOCIO (Cliente activo con Pase Diario) - Puede emitir carnet para asociarlo";
                    lblCategoriaInfo.ForeColor = Color.FromArgb(20, 50, 110);
                    pnlCategoria.BackColor = System.Drawing.Color.FromArgb(205, 225, 245);
                    btnEmitir.Text = "EMITIR CARNET";
                    btnEmitir.Enabled = true;
                }

                MessageBox.Show("Ficha cargada con éxito. Puede modificar los datos o emitir su carnet.", "Ficha Encontrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                esSocioActual = false;
                nroCarnetActual = "";
                btnEmitir.Text = "EMITIR CARNET";
                btnEmitir.Enabled = true;
                lblCategoriaInfo.Text = "Categoría: NUEVO CLIENTE (No registrado en la base de datos)";
                lblCategoriaInfo.ForeColor = Color.FromArgb(20, 30, 45);
                pnlCategoria.BackColor = System.Drawing.Color.FromArgb(200, 210, 222);
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtTelefono.Text = "";
                txtEmail.Text = "";
                btnEmitir.Enabled = true;
                MessageBox.Show("El DNI " + dni + " no se encuentra registrado. Complete los datos para darlo de alta.", "Cliente Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Botón 1: GUARDAR NUEVO CLIENTE
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Debe completar al menos DNI, Nombre y Apellido.", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDni.Text.Trim(), out int dni))
            {
                MessageBox.Show("El DNI debe contener únicamente números.", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            E_Cliente cliente = new E_Cliente();
            cliente.Dni = dni;
            cliente.Nombre = txtNombre.Text.Trim();
            cliente.Apellido = txtApellido.Text.Trim();
            cliente.Telefono = txtTelefono.Text.Trim();
            cliente.Email = txtEmail.Text.Trim();

            string respuesta = datosCliente.Nuevo_Cliente(cliente);

            if (int.TryParse(respuesta, out int codigo))
            {
                if (codigo == 0)
                {
                    MessageBox.Show("El cliente ya se encuentra registrado con este DNI.", "DNI Existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    lblCategoriaInfo.Text = "Categoría: NO SOCIO (Registrado con éxito - N° Cliente: " + respuesta + ")";
                    pnlCategoria.BackColor = System.Drawing.Color.FromArgb(235, 225, 185);
                    
                    DialogResult resApto = MessageBox.Show(
                        "¡Cliente guardado con éxito (ID: " + respuesta + ")!\n\n" +
                        "Todo cliente (socio o no socio) requiere Apto Físico vigente para realizar actividades deportivas.\n\n" +
                        "¿Desea registrar su certificado médico ahora?",
                        "Registro Exitoso - Apto Físico",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (resApto == DialogResult.Yes)
                    {
                        E_Cliente clienteApto = new E_Cliente();
                        clienteApto.Dni = cliente.Dni;
                        clienteApto.Nombre = cliente.Nombre;
                        clienteApto.Apellido = cliente.Apellido;

                        frmAptoFisico pantallaApto = new frmAptoFisico(clienteApto);
                        pantallaApto.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("Error al registrar cliente: " + respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón MODIFICAR DATOS DEL CLIENTE
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Para modificar debe ingresar DNI, Nombre y Apellido.", "Datos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDni.Text.Trim(), out int dni))
            {
                MessageBox.Show("El DNI debe contener solo números.", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            E_Cliente cliente = new E_Cliente();
            cliente.Dni = dni;
            cliente.Nombre = txtNombre.Text.Trim();
            cliente.Apellido = txtApellido.Text.Trim();
            cliente.Telefono = txtTelefono.Text.Trim();
            cliente.Email = txtEmail.Text.Trim();

            string resultado = datosCliente.Modificar_Cliente(cliente);
            if (resultado == "OK")
            {
                MessageBox.Show("Los datos del cliente fueron actualizados correctamente.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar: " + resultado, "Error de Actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón 2: EMITIR EL CARNET CON VALIDACIÓN DE APTO FÍSICO
        private void btnEmitir_Click(object sender, EventArgs e)
        {
            if (esSocioActual && !string.IsNullOrEmpty(nroCarnetActual))
            {
                frmImprimirCarnet carnetExistente = new frmImprimirCarnet(txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtDni.Text.Trim(), nroCarnetActual);
                carnetExistente.ShowDialog();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Debe ingresar el DNI del cliente para emitir el carnet.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!int.TryParse(txtDni.Text.Trim(), out int dniCliente))
            {
                MessageBox.Show("El DNI debe ser numérico.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Regla de Negocio: Validar estado del Apto Físico
            string estadoApto = datosCliente.ValidarIngresoSocio(dniCliente);

            if (estadoApto != "Vigente")
            {
                DialogResult dialog = MessageBox.Show(
                    "EMISIÓN BLOQUEADA: El cliente tiene el apto físico en estado: '" + estadoApto + "'.\n\n¿Desea registrar el apto físico ahora?",
                    "Restricción Médica Obligatoria",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (dialog == DialogResult.Yes)
                {
                    E_Cliente clienteApto = new E_Cliente();
                    clienteApto.Dni = dniCliente;
                    clienteApto.Nombre = txtNombre.Text.Trim();
                    clienteApto.Apellido = txtApellido.Text.Trim();

                    frmAptoFisico pantallaApto = new frmAptoFisico(clienteApto);
                    pantallaApto.ShowDialog();
                }
                return;
            }

            // Si el apto está vigente, procedemos a vincular carnet
            string respuesta = datosCliente.AsociarCarnet(dniCliente);

            if (respuesta.StartsWith("OK|"))
            {
                string[] partes = respuesta.Split('|');
                string nroCarnetGenerado = partes[1];

                esSocioActual = true;
                nroCarnetActual = nroCarnetGenerado;
                lblCategoriaInfo.Text = "Categoría: SOCIO REGISTRADO (Carnet Nº: " + nroCarnetGenerado + ")";
                pnlCategoria.BackColor = System.Drawing.Color.FromArgb(180, 220, 245);
                btnEmitir.Text = "VER / IMPRIMIR CARNET";
                btnEmitir.Enabled = true;

                frmImprimirCarnet ventanitaCarnet = new frmImprimirCarnet(txtNombre.Text, txtApellido.Text, txtDni.Text, nroCarnetGenerado);
                ventanitaCarnet.ShowDialog();
            }
            else
            {
                MessageBox.Show(respuesta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblHeaderTitulo_Click(object sender, EventArgs e)
        {

        }

        private void lblDni_Click(object sender, EventArgs e)
        {

        }
    }
}