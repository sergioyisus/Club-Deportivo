using System;

using System.Data;

using MySql.Data.MySqlClient;

using Club_Deportivo.Entidades;

using ClubDeportivo.Datos;

namespace Club_Deportivo.Datos
{
    internal class Cliente
    {
        // Registra un nuevo cliente (inicialmente No Socio) llamando al Stored Procedure 'NuevoCliente'
        public string Nuevo_Cliente(E_Cliente cliente)
        {
            string salida;
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                // Usamos el procedimiento almacenado base de la cátedra para insertar

                MySqlCommand comando = new MySqlCommand("NuevoCliente", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("p_dni", MySqlDbType.Int32).Value = cliente.Dni;
                comando.Parameters.Add("p_nom", MySqlDbType.VarChar).Value = cliente.Nombre;
                comando.Parameters.Add("p_ape", MySqlDbType.VarChar).Value = cliente.Apellido;
                MySqlParameter ParCodigo = new MySqlParameter();
                ParCodigo.ParameterName = "rta";
                ParCodigo.MySqlDbType = MySqlDbType.Int32;
                ParCodigo.Direction = ParameterDirection.Output;
                comando.Parameters.Add(ParCodigo);
                sqlCon.Open();
                comando.ExecuteNonQuery();

                salida = Convert.ToString(ParCodigo.Value);

                // Si se insertó con éxito y se ingresaron datos de contacto, los actualizamos en la ficha

                if (int.TryParse(salida, out int nuevoId) && nuevoId > 0)
                {
                    try
                    {
                        string qUpdate = "UPDATE clientes SET telefono = @tel, email = @mail WHERE IdCliente = @id";
                        MySqlCommand cmdUpdate = new MySqlCommand(qUpdate, sqlCon);
                        cmdUpdate.Parameters.AddWithValue("@tel", (object)cliente.Telefono ?? DBNull.Value);

                        cmdUpdate.Parameters.AddWithValue("@mail", (object)cliente.Email ?? DBNull.Value);

                        cmdUpdate.Parameters.AddWithValue("@id", nuevoId);

                        cmdUpdate.ExecuteNonQuery();
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                salida = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            return salida;
        }
        // Actualiza los datos de contacto y personales de un cliente existente
        public string Modificar_Cliente(E_Cliente cliente)
        {
            string salida = "OK";
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                string query = "UPDATE clientes SET Nombre = @nom, Apellido = @ape, telefono = @tel, email = @mail WHERE Dni = @dni";
                MySqlCommand comando = new MySqlCommand(query, sqlCon);
                comando.Parameters.AddWithValue("@nom", cliente.Nombre);
                comando.Parameters.AddWithValue("@ape", cliente.Apellido);
                comando.Parameters.AddWithValue("@tel", (object)cliente.Telefono ?? DBNull.Value);
                comando.Parameters.AddWithValue("@mail", (object)cliente.Email ?? DBNull.Value);
                comando.Parameters.AddWithValue("@dni", cliente.Dni);
                sqlCon.Open();
                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas == 0)
                {
                    salida = "No se encontró ningún cliente con el DNI indicado.";
                }
            }
            catch (Exception ex)
            {
                salida = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return salida;
        }
        // Asocia un carnet correlativo oficial a un cliente para convertirlo en Socio mediante 'VincularCarnet'
        public string AsociarCarnet(int dni)
        {
            string salida;
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                MySqlCommand comando = new MySqlCommand("VincularCarnet", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                // Le pasamos el DNI

                comando.Parameters.Add("p_dni", MySqlDbType.Int32).Value = dni;
                // Preparamos para recibir la respuesta (rta)

                MySqlParameter ParCodigo = new MySqlParameter();
                ParCodigo.ParameterName = "rta";
                ParCodigo.MySqlDbType = MySqlDbType.VarChar;
                ParCodigo.Size = 100;
                ParCodigo.Direction = ParameterDirection.Output;
                comando.Parameters.Add(ParCodigo);
                sqlCon.Open();
                comando.ExecuteNonQuery();

                salida = Convert.ToString(ParCodigo.Value);
            }
            catch (Exception ex)
            {
                salida = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return salida;
        }
        // Guarda o actualiza el certificado medico de apto fisico invocando 'GuardarAptoFisico'
        public string RegistrarAptoFisico(int dni, DateTime fechaVencimiento, string estado)
        {
            string salida;
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                MySqlCommand comando = new MySqlCommand("GuardarAptoFisico", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("p_dni", MySqlDbType.Int32).Value = dni;
                comando.Parameters.Add("p_fecha_venc", MySqlDbType.Date).Value = fechaVencimiento;
                comando.Parameters.Add("p_estado", MySqlDbType.VarChar).Value = estado; // "Vigente" o "Vencido"
                MySqlParameter ParCodigo = new MySqlParameter();
                ParCodigo.ParameterName = "rta";
                ParCodigo.MySqlDbType = MySqlDbType.VarChar;
                ParCodigo.Size = 100;
                ParCodigo.Direction = ParameterDirection.Output;
                comando.Parameters.Add(ParCodigo);
                sqlCon.Open();
                comando.ExecuteNonQuery();

                salida = Convert.ToString(ParCodigo.Value); // Devuelve "OK" o mensaje del SP
            }
            catch (Exception ex)
            {
                salida = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return salida;
        }
        // Consulta el estado medico actual del cliente (Vigente / Vencido / No Registrado) mediante 'VerificarAptoIngreso'
        public string ValidarIngresoSocio(int dni)
        {
            string estadoApto = "No Registrado";
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                // Procedimiento que consulte el estado del apto según el DNI

                MySqlCommand comando = new MySqlCommand("VerificarAptoIngreso", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("p_dni", MySqlDbType.Int32).Value = dni;
                MySqlParameter ParEstado = new MySqlParameter();
                ParEstado.ParameterName = "p_estado_out"; // El procedimiento devuelve "Vigente" o "Vencido"
                ParEstado.MySqlDbType = MySqlDbType.VarChar;
                ParEstado.Size = 50;
                ParEstado.Direction = ParameterDirection.Output;
                comando.Parameters.Add(ParEstado);
                sqlCon.Open();
                comando.ExecuteNonQuery();

                estadoApto = Convert.ToString(ParEstado.Value);
            }
            catch (Exception)
            {
                estadoApto = "Error de Conexión";
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return estadoApto;
        }
        // Busca la ficha completa del cliente por su DNI (incluyendo datos de carnet y ultimo vencimiento)
        public DataTable BuscarClientePorDni(int dni)
        {
            DataTable tabla = new DataTable();

            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                // Intentamos sincronizar estados vencidos automáticamente si el procedimiento existe

                try
                {
                    MySqlCommand cmdSync = new MySqlCommand("ActualizarEstadosVencidos", sqlCon);
                    cmdSync.CommandType = CommandType.StoredProcedure;

                    sqlCon.Open();
                    cmdSync.ExecuteNonQuery();

                    sqlCon.Close();
                }
                catch { }

                string query = "SELECT c.IdCliente, c.Dni, c.Nombre, c.Apellido, c.estadoHabilitado, c.IdCarnet, car.nroCarnet, c.telefono, c.email, " +
                               "(SELECT MAX(cu.fechaDeVencimiento) FROM cuotas cu WHERE cu.IdCliente = c.IdCliente) AS ultimoVencimiento " +

                               "FROM clientes c LEFT JOIN carnets car ON c.IdCarnet = car.IdCarnet WHERE c.Dni = " + dni;

                MySqlCommand comando = new MySqlCommand(query, sqlCon);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                adapter.Fill(tabla);
            }
            catch (Exception) { }

            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return tabla;
        }
        // Registra el cobro de cuota mensual o pase diario aplicando descuentos segun la forma de pago mediante 'RegistrarCobroCuota'
        public string RegistrarCobro(int dni, decimal monto, string tipo, string formaPago, out DateTime fechaVencimiento, out decimal montoFinal)
        {
            string salida = "";
            fechaVencimiento = DateTime.Today;

            montoFinal = formaPago == "Efectivo" ? (monto * 0.90m) : monto;

            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                MySqlCommand comando = new MySqlCommand("RegistrarCobroCuota", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("p_dni", MySqlDbType.Int32).Value = dni;
                comando.Parameters.Add("p_monto", MySqlDbType.Decimal).Value = monto;
                comando.Parameters.Add("p_tipo", MySqlDbType.VarChar).Value = tipo;
                comando.Parameters.Add("p_forma_pago", MySqlDbType.VarChar).Value = formaPago;
                MySqlParameter parRta = new MySqlParameter("rta", MySqlDbType.VarChar, 100);
                parRta.Direction = ParameterDirection.Output;

                comando.Parameters.Add(parRta);
                MySqlParameter parVenc = new MySqlParameter("p_vencimiento", MySqlDbType.Date);
                parVenc.Direction = ParameterDirection.Output;

                comando.Parameters.Add(parVenc);
                sqlCon.Open();
                comando.ExecuteNonQuery();

                salida = Convert.ToString(parRta.Value);

                if (salida == "OK" && parVenc.Value != DBNull.Value)
                {
                    fechaVencimiento = Convert.ToDateTime(parVenc.Value);
                }
            }
            catch (Exception ex)
            {
                salida = "ERROR: " + ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return salida;
        }
        /// <summary>

        /// Obtiene el reporte de cuotas según el filtro dinámico seleccionado:

        /// 1. Vencen Hoy (fechaDeVencimiento = CURDATE())

        /// 2. Vencidas / Morosos (fechaDeVencimiento < CURDATE())

        /// 3. Vigentes / Al Día (fechaDeVencimiento > CURDATE())

        /// 4. Todas las Cuotas (historial completo)

        /// </summary>

        public DataTable ObtenerReporteCuotas(string filtro, string categoria = "Todos")
        {
            DataTable tabla = new DataTable();
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                try
                {
                    MySqlCommand cmdSync = new MySqlCommand("ActualizarEstadosVencidos", sqlCon);
                    cmdSync.CommandType = CommandType.StoredProcedure;
                    sqlCon.Open();
                    cmdSync.ExecuteNonQuery();
                    sqlCon.Close();
                }
                catch { }

                string whereClausula = "";
                switch (filtro)
                {
                    case "Vencen Hoy":
                        whereClausula = "WHERE cu.fechaDeVencimiento = CURDATE() ";
                        break;
                    case "Vencidas / Morosos":
                        whereClausula = "WHERE cu.fechaDeVencimiento < CURDATE() ";
                        break;
                    case "Vigentes / Al Día":
                        whereClausula = "WHERE cu.fechaDeVencimiento > CURDATE() ";
                        break;
                    case "Todas":
                    default:
                        whereClausula = "";
                        break;
                }
                // Filtro por categora: Socios vs No Socios
                if (categoria == "Socios")
                {
                    whereClausula += string.IsNullOrEmpty(whereClausula) ? "WHERE c.IdCarnet IS NOT NULL " : "AND c.IdCarnet IS NOT NULL ";
                }
                else if (categoria == "No Socios")
                {
                    whereClausula += string.IsNullOrEmpty(whereClausula) ? "WHERE c.IdCarnet IS NULL " : "AND c.IdCarnet IS NULL ";
                }
                string query = "SELECT DISTINCT c.Dni, CONCAT(c.Apellido, ', ', c.Nombre) AS ApellidoYNombre, " +
                               "CASE WHEN c.IdCarnet IS NOT NULL THEN 'Socio' ELSE 'No Socio' END AS Categoria, " +
                               "DATE_FORMAT(cu.fechaDeVencimiento, '%d/%m/%Y') AS Vencimiento " +
                               "FROM cuotas cu " +
                               "INNER JOIN clientes c ON cu.IdCliente = c.IdCliente " +
                               whereClausula +
                               "ORDER BY cu.fechaDeVencimiento DESC, c.Apellido, c.Nombre";

                MySqlCommand comando = new MySqlCommand(query, sqlCon);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                adapter.Fill(tabla);
            }
            catch (Exception) { }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return tabla;
        }
        public DataTable ObtenerVencimientosDelDia()
        {
            return ObtenerReporteCuotas("Vencen Hoy");
        }
        /// <summary>

        /// Registra la auditoría histórica de cada intento de acceso (Habilitado, Denegado o Excepcional)

        /// cumpliendo con el control y trazabilidad de asistencia.

        /// </summary>

        public string RegistrarAcceso(int dni, string resultado, string motivo, string autorizadoPor)
        {
            string salida = "OK";
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                sqlCon.Open();
                // 1. Buscamos el IdCliente a partir del DNI

                int idCliente = 0;
                string queryId = "SELECT IdCliente FROM clientes WHERE Dni = @dni LIMIT 1;";
                using (MySqlCommand cmdId = new MySqlCommand(queryId, sqlCon))
                {
                    cmdId.Parameters.AddWithValue("@dni", dni);

                    object res = cmdId.ExecuteScalar();

                    if (res != null && res != DBNull.Value)
                    {
                        idCliente = Convert.ToInt32(res);
                    }
                }
                if (idCliente == 0)
                {
                    return "ERROR: Cliente no encontrado para auditoría de acceso.";
                }
                // 2. Nos aseguramos de que la tabla exista

                string createTable = @"CREATE TABLE IF NOT EXISTS registro_accesos (
                    idAcceso INT AUTO_INCREMENT PRIMARY KEY,

                    idCliente INT NOT NULL,

                    dni INT NOT NULL,

                    fechaHora DATETIME NOT NULL,

                    resultado VARCHAR(20) NOT NULL,

                    motivo VARCHAR(255) NULL,

                    autorizadoPor VARCHAR(50) NULL,

                    FOREIGN KEY (idCliente) REFERENCES clientes(IdCliente) ON DELETE CASCADE

                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";

                using (MySqlCommand cmdTable = new MySqlCommand(createTable, sqlCon))
                {
                    cmdTable.ExecuteNonQuery();
                }
                // 3. Insertamos el registro de acceso

                string insertQuery = @"INSERT INTO registro_accesos (idCliente, dni, fechaHora, resultado, motivo, autorizadoPor)
                                       VALUES (@idCliente, @dni, NOW(), @resultado, @motivo, @autorizadoPor);";

                using (MySqlCommand cmdInsert = new MySqlCommand(insertQuery, sqlCon))
                {
                    cmdInsert.Parameters.AddWithValue("@idCliente", idCliente);

                    cmdInsert.Parameters.AddWithValue("@dni", dni);

                    cmdInsert.Parameters.AddWithValue("@resultado", resultado);

                    cmdInsert.Parameters.AddWithValue("@motivo", string.IsNullOrEmpty(motivo) ? (object)DBNull.Value : motivo);

                    cmdInsert.Parameters.AddWithValue("@autorizadoPor", string.IsNullOrEmpty(autorizadoPor) ? (object)DBNull.Value : autorizadoPor);

                    cmdInsert.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                salida = "ERROR: " + ex.Message;
            }
            finally
            {
                if (sqlCon.State == System.Data.ConnectionState.Open) sqlCon.Close();
            }
            return salida;
        }
        // Recupera el registro del ultimo pago efectuado por el cliente para consulta o impresion de comprobante
        public DataTable ObtenerUltimoPagoCliente(int dni)
        {
            DataTable tabla = new DataTable();
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                string query = "SELECT cu.montoAbonado, cu.fechaDePago, cu.fechaDeVencimiento, cu.tipoCuota " +
                               "FROM cuotas cu INNER JOIN clientes c ON cu.IdCliente = c.IdCliente " +
                               "WHERE c.Dni = " + dni + " ORDER BY cu.IdCuota DESC LIMIT 1;";
                MySqlCommand comando = new MySqlCommand(query, sqlCon);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                adapter.Fill(tabla);
            }
            catch
            {
                // Si la tabla no posee registros o hubo error de lectura, retornamos tabla vacia sin interrumpir la operacion
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            return tabla;
        }
    }
}
