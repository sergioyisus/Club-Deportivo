using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace ClubDeportivo.Datos
{
    // Capa de acceso a datos para la autenticacion de usuarios en el sistema
    public class Usuarios
    {
        // Valida las credenciales de ingreso (usuario y contrasena) mediante el Stored Procedure 'ValidarLogin'
        public DataTable Log_Usu(string usuario, string pass)
        {
            MySqlDataReader resultado;
            DataTable tabla = new DataTable();
            MySqlConnection sqlCon = new MySqlConnection();

            try
            {
                // Obtenemos la conexion configurada
                sqlCon = Conexion.getInstancia().CrearConexion();
                
                // Preparamos el llamado al procedimiento almacenado
                MySqlCommand comando = new MySqlCommand("ValidarLogin", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                // Pasamos los parametros recibidos desde la pantalla de login
                comando.Parameters.Add("p_usu", MySqlDbType.VarChar).Value = usuario;
                comando.Parameters.Add("p_pass", MySqlDbType.VarChar).Value = pass;

                sqlCon.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado); // Cargamos la respuesta (RolUsu del usuario)
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Cerramos la conexion para liberar recursos en el servidor MySQL
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
        }
    }
}
