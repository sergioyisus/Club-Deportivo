using System;
using MySql.Data.MySqlClient;

namespace ClubDeportivo.Datos
{
        // Gestiona la conexion con la base de datos MySQL (utilizando patron Singleton)
    // e inicializa de forma autonoma las tablas y procedimientos al iniciar la aplicacion.
    public class Conexion
    {
        private string baseDatos;
        private string servidor;
        private string puerto;
        private string usuario;
        private string clave;
        private static Conexion con = null;

        private Conexion()
        {
            this.baseDatos = "Proyecto";
            this.servidor = "localhost";
            this.puerto = "3306";
            this.usuario = "root";
            this.clave = "";
        }

                // Retorna un nuevo objeto MySqlConnection configurado con los parametros de localhost
        public MySqlConnection CrearConexion()
        {
            MySqlConnection cadena = new MySqlConnection();
            try
            {
                cadena.ConnectionString = "datasource=" + this.servidor +
                                          ";port=" + this.puerto +
                                          ";username=" + this.usuario +
                                          ";password=" + this.clave +
                                          ";Database=" + this.baseDatos;
            }
            catch (Exception ex)
            {
                cadena = null;
                throw ex;
            }
            return cadena;
        }

        // Inicialización y autocomprobación de la base de datos al arrancar
        public static void InicializarBaseDeDatos()
        {
            try
            {
                // Nos conectamos al servidor MySQL sin especificar base de datos inicial
                string strServidor = "datasource=localhost;port=3306;username=root;password=;AllowUserVariables=True;";
                using (MySqlConnection conn = new MySqlConnection(strServidor))
                {
                    conn.Open();

                    // 1. Aseguramos la existencia de la base de datos 'proyecto'
                    using (MySqlCommand cmdCreate = new MySqlCommand("CREATE DATABASE IF NOT EXISTS `proyecto` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;", conn))
                    {
                        cmdCreate.ExecuteNonQuery();
                    }

                    // 2. Seleccionamos la base de datos para garantizar que las tablas críticas existan
                    conn.ChangeDatabase("proyecto");

                    string ddlScript = @"
                        CREATE TABLE IF NOT EXISTS roles (
                            RolUsu INT PRIMARY KEY,
                            nomRol VARCHAR(30) NOT NULL
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

                        INSERT IGNORE INTO roles (RolUsu, nomRol) VALUES (120, 'Administrador'), (121, 'Empleado');

                        CREATE TABLE IF NOT EXISTS usuario (
                            CodUsu INT AUTO_INCREMENT PRIMARY KEY,
                            nombreUsu VARCHAR(20) NOT NULL,
                            passUsu VARCHAR(15) NOT NULL,
                            RolUsu INT NOT NULL,
                            Activo TINYINT(1) DEFAULT 1,
                            FOREIGN KEY (RolUsu) REFERENCES roles(RolUsu)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

                        INSERT IGNORE INTO usuario (CodUsu, nombreUsu, passUsu, RolUsu, Activo) 
                        VALUES (1, 'admin', '123456', 120, 1);

                        CREATE TABLE IF NOT EXISTS carnets (
                            IdCarnet INT AUTO_INCREMENT PRIMARY KEY,
                            nroCarnet INT NOT NULL,
                            fechaEmision DATE NOT NULL
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

                        CREATE TABLE IF NOT EXISTS clientes (
                            IdCliente INT AUTO_INCREMENT PRIMARY KEY,
                            Dni INT NOT NULL UNIQUE,
                            Nombre VARCHAR(50) NOT NULL,
                            Apellido VARCHAR(50) NOT NULL,
                            estadoHabilitado TINYINT(1) DEFAULT 0,
                            IdCarnet INT NULL,
                            telefono VARCHAR(20) NULL,
                            email VARCHAR(100) NULL,
                            FOREIGN KEY (IdCarnet) REFERENCES carnets(IdCarnet) ON DELETE SET NULL
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

                        CREATE TABLE IF NOT EXISTS cuotas (
                            IdCuota INT AUTO_INCREMENT PRIMARY KEY,
                            IdCliente INT NOT NULL,
                            montoAbonado DECIMAL(10,2) NOT NULL,
                            fechaDePago DATE NOT NULL,
                            fechaDeVencimiento DATE NOT NULL,
                            tipoCuota VARCHAR(20) NOT NULL,
                            formaPago VARCHAR(50) NULL,
                            FOREIGN KEY (IdCliente) REFERENCES clientes(IdCliente) ON DELETE CASCADE
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

                        CREATE TABLE IF NOT EXISTS registro_accesos (
                            idAcceso INT AUTO_INCREMENT PRIMARY KEY,
                            idCliente INT NOT NULL,
                            dni INT NOT NULL,
                            fechaHora DATETIME NOT NULL,
                            resultado VARCHAR(20) NOT NULL,
                            motivo VARCHAR(255) NULL,
                            autorizadoPor VARCHAR(50) NULL,
                            FOREIGN KEY (idCliente) REFERENCES clientes(IdCliente) ON DELETE CASCADE
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                    ";

                    using (MySqlCommand cmdDDL = new MySqlCommand(ddlScript, conn))
                    {
                        cmdDDL.ExecuteNonQuery();
                    }

                    try
                    {
                        using (MySqlCommand cmdDrop = new MySqlCommand("DROP PROCEDURE IF EXISTS `ActualizarEstadosVencidos`;", conn))
                        {
                            cmdDrop.ExecuteNonQuery();
                        }
                        string sqlProc = @"CREATE PROCEDURE `ActualizarEstadosVencidos`()
BEGIN
    
    UPDATE clientes c
    SET c.estadoHabilitado = 0
    WHERE c.IdCarnet IS NOT NULL
      AND (
        SELECT COALESCE(MAX(cu.fechaDeVencimiento), '1900-01-01')
        FROM cuotas cu
        WHERE cu.IdCliente = c.IdCliente AND cu.tipoCuota = 'Mensual'
      ) < CURDATE();

    
    UPDATE clientes c
    SET c.estadoHabilitado = 0
    WHERE c.IdCarnet IS NULL
      AND (
        SELECT COALESCE(MAX(cu.fechaDePago), '1900-01-01')
        FROM cuotas cu
        WHERE cu.IdCliente = c.IdCliente AND cu.tipoCuota = 'Diaria'
      ) < CURDATE();
END";
                        using (MySqlCommand cmdProc = new MySqlCommand(sqlProc, conn))
                        {
                            cmdProc.ExecuteNonQuery();
                        }
                    }
                    catch { }

                    try
                    {
                        using (MySqlCommand cmdDrop = new MySqlCommand("DROP PROCEDURE IF EXISTS `GuardarAptoFisico`;", conn))
                        {
                            cmdDrop.ExecuteNonQuery();
                        }
                        string sqlProc = @"CREATE PROCEDURE `GuardarAptoFisico`(
    IN p_dni INT,
    IN p_fecha_venc DATE,
    IN p_estado VARCHAR(20),
    OUT rta VARCHAR(100)
)
BEGIN
    DECLARE v_idCliente INT DEFAULT NULL;
    DECLARE v_vigentes INT DEFAULT 0;

    
    SELECT IdCliente INTO v_idCliente FROM clientes WHERE Dni = p_dni;

    IF v_idCliente IS NULL THEN
        SET rta = 'ERROR: El cliente con ese DNI no se encuentra registrado en el sistema.';
    ELSE
        
        CREATE TABLE IF NOT EXISTS apto_fisico (
            idApto INT AUTO_INCREMENT PRIMARY KEY,
            idCliente INT NOT NULL,
            fechaPresentacion DATE NOT NULL,
            fechaVencimiento DATE NOT NULL,
            estadoApto VARCHAR(20) NOT NULL,
            FOREIGN KEY (idCliente) REFERENCES clientes(IdCliente) ON DELETE CASCADE
        );

        
        SELECT COUNT(*) INTO v_vigentes 
        FROM apto_fisico 
        WHERE idCliente = v_idCliente 
          AND estadoApto = 'Vigente' 
          AND fechaVencimiento >= CURDATE();

        IF v_vigentes > 0 AND p_estado = 'Vigente' THEN
            
            UPDATE apto_fisico 
            SET fechaPresentacion = CURDATE(), 
                fechaVencimiento = p_fecha_venc, 
                estadoApto = p_estado
            WHERE idCliente = v_idCliente 
              AND estadoApto = 'Vigente' 
              AND fechaVencimiento >= CURDATE()
            ORDER BY idApto DESC LIMIT 1;
            
            SET rta = 'ACTUALIZADO';
        ELSE
            
            INSERT INTO apto_fisico (idCliente, fechaPresentacion, fechaVencimiento, estadoApto)
            VALUES (v_idCliente, CURDATE(), p_fecha_venc, p_estado);

            SET rta = 'OK';
        END IF;
    END IF;
END";
                        using (MySqlCommand cmdProc = new MySqlCommand(sqlProc, conn))
                        {
                            cmdProc.ExecuteNonQuery();
                        }
                    }
                    catch { }

                    try
                    {
                        using (MySqlCommand cmdDrop = new MySqlCommand("DROP PROCEDURE IF EXISTS `NuevoCliente`;", conn))
                        {
                            cmdDrop.ExecuteNonQuery();
                        }
                        string sqlProc = @"CREATE PROCEDURE `NuevoCliente`(IN `p_dni` INT, IN `p_nom` VARCHAR(50), IN `p_ape` VARCHAR(50), OUT `rta` INT)
BEGIN
    DECLARE existe INT DEFAULT 0;
    
    
    SET existe = (SELECT COUNT(*) FROM clientes WHERE Dni = p_dni);
    
    IF existe = 0 THEN
        
        INSERT INTO clientes (Dni, Nombre, Apellido, estadoHabilitado, IdCarnet)
        VALUES (p_dni, p_nom, p_ape, false, NULL);
        
        SET rta = LAST_INSERT_ID(); 
    ELSE
        SET rta = 0; 
    END IF;
END";
                        using (MySqlCommand cmdProc = new MySqlCommand(sqlProc, conn))
                        {
                            cmdProc.ExecuteNonQuery();
                        }
                    }
                    catch { }

                    try
                    {
                        using (MySqlCommand cmdDrop = new MySqlCommand("DROP PROCEDURE IF EXISTS `RegistrarCobroCuota`;", conn))
                        {
                            cmdDrop.ExecuteNonQuery();
                        }
                        string sqlProc = @"CREATE PROCEDURE `RegistrarCobroCuota`(IN `p_dni` INT, IN `p_monto` DECIMAL(10,2), IN `p_tipo` VARCHAR(20), IN `p_forma_pago` VARCHAR(20), OUT `rta` VARCHAR(100), OUT `p_vencimiento` DATE)
BEGIN
    DECLARE v_idCliente INT DEFAULT NULL;
    DECLARE v_idCarnet INT DEFAULT NULL;
    DECLARE v_ultimo_venc DATE DEFAULT NULL;
    DECLARE v_vencimiento DATE;
    DECLARE v_monto_cobrado DECIMAL(10,2);
    
    
    SELECT IdCliente, IdCarnet INTO v_idCliente, v_idCarnet 
    FROM clientes 
    WHERE Dni = p_dni 
    LIMIT 1;
    
    IF v_idCliente IS NULL THEN
        SET rta = 'ERROR: El cliente no se encuentra registrado en el sistema.';
        SET p_vencimiento = NULL;
    ELSE
        
        IF v_idCarnet IS NOT NULL AND p_tipo = 'Diaria' THEN
            SET rta = 'ERROR: Los socios abonan Ãºnicamente cuota mensual.';
            SET p_vencimiento = NULL;
        ELSEIF v_idCarnet IS NULL AND p_tipo = 'Mensual' THEN
            SET rta = 'ERROR: Los no socios abonan Ãºnicamente cuota diaria (pase por el dÃ­a).';
            SET p_vencimiento = NULL;
        ELSE
            
            IF p_forma_pago = 'Efectivo' THEN
                SET v_monto_cobrado = p_monto * 0.90;
            ELSE
                SET v_monto_cobrado = p_monto;
            END IF;
            
            
            IF p_tipo = 'Mensual' THEN
                
                SELECT MAX(fechaDeVencimiento) INTO v_ultimo_venc 
                FROM cuotas 
                WHERE IdCliente = v_idCliente AND tipoCuota = 'Mensual';
                
                
                IF v_ultimo_venc IS NOT NULL THEN
                    IF v_ultimo_venc >= DATE_SUB(CURDATE(), INTERVAL 30 DAY) THEN
                        SET v_vencimiento = DATE_ADD(v_ultimo_venc, INTERVAL 30 DAY);
                    ELSE
                        
                        SET v_vencimiento = DATE_ADD(CURDATE(), INTERVAL 30 DAY);
                    END IF;
                ELSE
                    
                    SET v_vencimiento = DATE_ADD(CURDATE(), INTERVAL 30 DAY);
                END IF;
            ELSE
                
                SET v_vencimiento = CURDATE();
            END IF;
            
            
            INSERT INTO cuotas (IdCliente, montoAbonado, fechaDePago, fechaDeVencimiento, tipoCuota)
            VALUES (v_idCliente, v_monto_cobrado, CURDATE(), v_vencimiento, p_tipo);
            
            
            UPDATE clientes 
            SET estadoHabilitado = 1 
            WHERE IdCliente = v_idCliente;
            
            SET p_vencimiento = v_vencimiento;
            SET rta = 'OK';
        END IF;
    END IF;
END";
                        using (MySqlCommand cmdProc = new MySqlCommand(sqlProc, conn))
                        {
                            cmdProc.ExecuteNonQuery();
                        }
                    }
                    catch { }

                    try
                    {
                        using (MySqlCommand cmdDrop = new MySqlCommand("DROP PROCEDURE IF EXISTS `ValidarLogin`;", conn))
                        {
                            cmdDrop.ExecuteNonQuery();
                        }
                        string sqlProc = @"CREATE PROCEDURE `ValidarLogin`(IN `p_usu` VARCHAR(50), IN `p_pass` VARCHAR(50))
BEGIN
    SELECT RolUsu FROM usuario 
    WHERE nombreUsu = p_usu AND passUsu = p_pass;
END";
                        using (MySqlCommand cmdProc = new MySqlCommand(sqlProc, conn))
                        {
                            cmdProc.ExecuteNonQuery();
                        }
                    }
                    catch { }

                    try
                    {
                        using (MySqlCommand cmdDrop = new MySqlCommand("DROP PROCEDURE IF EXISTS `VerificarAptoIngreso`;", conn))
                        {
                            cmdDrop.ExecuteNonQuery();
                        }
                        string sqlProc = @"CREATE PROCEDURE `VerificarAptoIngreso`(IN `p_dni` INT, OUT `p_estado_out` VARCHAR(50))
BEGIN
    DECLARE v_idCliente INT DEFAULT NULL;
    DECLARE v_estado VARCHAR(20) DEFAULT NULL;

    SELECT IdCliente INTO v_idCliente FROM clientes WHERE Dni = p_dni;

    IF v_idCliente IS NULL THEN
        SET p_estado_out = 'No Registrado';
    ELSE
        SELECT estadoApto INTO v_estado 
        FROM apto_fisico 
        WHERE idCliente = v_idCliente 
        ORDER BY idApto DESC LIMIT 1;

        IF v_estado IS NULL THEN
            SET p_estado_out = 'No Registrado';
        ELSE
            SET p_estado_out = v_estado;
        END IF;
    END IF;
END";
                        using (MySqlCommand cmdProc = new MySqlCommand(sqlProc, conn))
                        {
                            cmdProc.ExecuteNonQuery();
                        }
                    }
                    catch { }

                    try
                    {
                        using (MySqlCommand cmdDrop = new MySqlCommand("DROP PROCEDURE IF EXISTS `VincularCarnet`;", conn))
                        {
                            cmdDrop.ExecuteNonQuery();
                        }
                        string sqlProc = @"CREATE PROCEDURE `VincularCarnet`(IN `p_dni` INT, OUT `rta` VARCHAR(100))
BEGIN
    DECLARE v_idCliente INT DEFAULT NULL;
    DECLARE v_idCarnet INT DEFAULT NULL;
    
    
    SELECT IdCliente, IdCarnet INTO v_idCliente, v_idCarnet 
    FROM clientes WHERE Dni = p_dni;
    
    
    IF v_idCliente IS NULL THEN
        SET rta = 'ERROR: El cliente no existe. Guarde los datos primero.';
    ELSEIF v_idCarnet IS NOT NULL THEN
        SET rta = 'ERROR: Este cliente ya tiene un carnet asociado.';
    ELSE
        
        INSERT INTO carnets (nroCarnet, fechaEmision) 
        VALUES (p_dni + 1000, CURDATE());
        
        
        SET v_idCarnet = LAST_INSERT_ID();
        
        
        UPDATE clientes 
        SET IdCarnet = v_idCarnet, estadoHabilitado = true 
        WHERE IdCliente = v_idCliente;
        
        SET rta = CONCAT('OK|', CAST(p_dni + 1000 AS CHAR));
    END IF;
END";
                        using (MySqlCommand cmdProc = new MySqlCommand(sqlProc, conn))
                        {
                            cmdProc.ExecuteNonQuery();
                        }
                    }
                    catch { }
                }
            }
            catch
            {
                // Si el servidor MySQL no estuviese activo o estuviese en otro puerto, se manejará en los formularios
            }
        }

        // Para evaluar la instancia de la conectividad
                // Patron Singleton: garantiza una unica instancia compartida de la clase Conexion
        public static Conexion getInstancia()
        {
            if (con == null) // Quiere decir que la conexión esta cerrada, por lo tanto se crea una nueva instancia de la clase Conexion
            {
                con = new Conexion(); // Se crea una nueva instancia de la clase Conexion
            }
            return con;
        }

        internal static MySqlConnection ObtenerConexion()
        {
            throw new NotImplementedException();
        }
    }
}
