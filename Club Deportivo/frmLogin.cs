using System;
using System.Data;
using System.Windows.Forms;
using ClubDeportivo.Datos;

namespace Club_Deportivo
{
    // Formulario de inicio de sesion: autentica al operador contra la base de datos MySQL
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            FormStyler.ApplyPinkStyle(this); // Aplica la paleta visual institucional
        }

        // Evento del boton INGRESAR: valida las credenciales ingresadas
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Usuarios dato = new Usuarios();

            try
            {
                // Verificamos que no dejen los campos en blanco aplicando Trim()
                if (txtUsuario.Text.Trim() == string.Empty || txtPass.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Debe ingresar usuario y contraseña", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // Consultamos las credenciales mediante el procedimiento almacenado
                dt = dato.Log_Usu(txtUsuario.Text.Trim(), txtPass.Text.Trim());

                // Si se encontro el usuario con credenciales correctas, damos acceso
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("¡Bienvenido al sistema!", "Ingreso Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abrimos el menu principal y ocultamos el login
                    frmPrincipal menu = new frmPrincipal();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
