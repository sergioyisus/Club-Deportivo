-- MariaDB dump 10.19  Distrib 10.4.32-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: proyecto
-- ------------------------------------------------------
-- Server version	10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `proyecto`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `proyecto` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE `proyecto`;

--
-- Table structure for table `apto_fisico`
--

DROP TABLE IF EXISTS `apto_fisico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `apto_fisico` (
  `idApto` int(11) NOT NULL AUTO_INCREMENT,
  `idCliente` int(11) NOT NULL,
  `fechaPresentacion` date NOT NULL,
  `fechaVencimiento` date NOT NULL,
  `estadoApto` varchar(20) NOT NULL,
  PRIMARY KEY (`idApto`),
  KEY `idCliente` (`idCliente`),
  CONSTRAINT `apto_fisico_ibfk_1` FOREIGN KEY (`idCliente`) REFERENCES `clientes` (`IdCliente`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `apto_fisico`
--

LOCK TABLES `apto_fisico` WRITE;
/*!40000 ALTER TABLE `apto_fisico` DISABLE KEYS */;
INSERT INTO `apto_fisico` VALUES (1,1,'2026-10-11','2026-10-11','Vigente'),(2,5,'2026-10-11','2026-10-11','Vigente'),(3,6,'2026-10-11','2026-10-11','Vigente'),(4,7,'2026-10-11','2026-10-11','Vigente'),(5,9,'2026-10-12','2026-10-12','Vigente'),(6,10,'2026-10-12','2026-10-12','Vigente'),(7,11,'2026-10-12','2026-10-12','Vigente'),(8,11,'2026-10-12','2026-10-12','Vigente'),(9,12,'2026-10-22','2027-10-22','Vencido'),(10,12,'2026-10-22','2027-10-22','Vencido'),(11,12,'2026-10-22','2027-10-22','Vigente');
/*!40000 ALTER TABLE `apto_fisico` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `carnets`
--

DROP TABLE IF EXISTS `carnets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `carnets` (
  `IdCarnet` int(11) NOT NULL AUTO_INCREMENT,
  `nroCarnet` int(11) NOT NULL,
  `fechaEmision` date NOT NULL,
  PRIMARY KEY (`IdCarnet`),
  UNIQUE KEY `nroCarnet` (`nroCarnet`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carnets`
--

LOCK TABLES `carnets` WRITE;
/*!40000 ALTER TABLE `carnets` DISABLE KEYS */;
INSERT INTO `carnets` VALUES (1,12346678,'2026-10-06'),(2,96238872,'2026-10-06'),(3,21669937,'2026-10-11'),(4,24808621,'2026-10-11'),(5,123445555,'2026-10-11'),(6,22668799,'2026-10-12'),(7,24808620,'2026-10-12'),(8,14326521,'2026-10-12'),(9,9993263,'2026-10-12'),(10,95729432,'2026-10-22');
/*!40000 ALTER TABLE `carnets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clientes` (
  `IdCliente` int(11) NOT NULL AUTO_INCREMENT,
  `Dni` int(11) NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `Apellido` varchar(50) NOT NULL,
  `estadoHabilitado` tinyint(1) DEFAULT 0,
  `IdCarnet` int(11) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`IdCliente`),
  UNIQUE KEY `Dni` (`Dni`),
  KEY `fk_cliente_carnet` (`IdCarnet`),
  CONSTRAINT `fk_cliente_carnet` FOREIGN KEY (`IdCarnet`) REFERENCES `carnets` (`IdCarnet`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES (1,96237872,'Sergio','Guerrero',0,2,NULL,NULL),(2,12345678,'Jesus','Vivas',0,1,NULL,NULL),(3,12312312,'Ariana','Grande',0,NULL,NULL,NULL),(4,21668937,'juan','fernandez',0,3,NULL,NULL),(5,24807620,'jesus','rivera',0,7,'',''),(6,24807621,'jesus','rivera',0,4,NULL,NULL),(7,123444555,'rosa','perez',0,5,NULL,NULL),(8,11223344,'david','gonzalez',0,NULL,NULL,NULL),(9,22667799,'carlos','perez',0,6,NULL,NULL),(10,14325521,'Maria','Gonzalez',0,8,NULL,NULL),(11,9992263,'Yorlet','Vivas',1,9,NULL,NULL),(12,95728432,'Mariano','Perez',0,10,'','');
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuotas`
--

DROP TABLE IF EXISTS `cuotas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cuotas` (
  `IdCuota` int(11) NOT NULL AUTO_INCREMENT,
  `IdCliente` int(11) NOT NULL,
  `montoAbonado` decimal(10,2) NOT NULL,
  `fechaDePago` date NOT NULL,
  `fechaDeVencimiento` date NOT NULL,
  `tipoCuota` varchar(20) NOT NULL,
  PRIMARY KEY (`IdCuota`),
  KEY `fk_cuota_cliente` (`IdCliente`),
  CONSTRAINT `fk_cuota_cliente` FOREIGN KEY (`IdCliente`) REFERENCES `clientes` (`IdCliente`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuotas`
--

LOCK TABLES `cuotas` WRITE;
/*!40000 ALTER TABLE `cuotas` DISABLE KEYS */;
INSERT INTO `cuotas` VALUES (1,11,4500.00,'2026-10-12','2026-11-11','Mensual');
/*!40000 ALTER TABLE `cuotas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `registro_accesos`
--

DROP TABLE IF EXISTS `registro_accesos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `registro_accesos` (
  `idAcceso` int(11) NOT NULL AUTO_INCREMENT,
  `idCliente` int(11) NOT NULL,
  `dni` int(11) NOT NULL,
  `fechaHora` datetime NOT NULL,
  `resultado` varchar(20) NOT NULL,
  `motivo` varchar(255) DEFAULT NULL,
  `autorizadoPor` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idAcceso`),
  KEY `idCliente` (`idCliente`),
  CONSTRAINT `registro_accesos_ibfk_1` FOREIGN KEY (`idCliente`) REFERENCES `clientes` (`IdCliente`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registro_accesos`
--

LOCK TABLES `registro_accesos` WRITE;
/*!40000 ALTER TABLE `registro_accesos` DISABLE KEYS */;
/*!40000 ALTER TABLE `registro_accesos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roles` (
  `RolUsu` int(11) NOT NULL,
  `nomRol` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`RolUsu`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (120,'Administrador'),(121,'Empleado');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `CodUsu` int(11) NOT NULL AUTO_INCREMENT,
  `nombreUsu` varchar(20) DEFAULT NULL,
  `passUsu` varchar(15) DEFAULT NULL,
  `RolUsu` int(11) DEFAULT NULL,
  `Activo` tinyint(1) DEFAULT 1,
  PRIMARY KEY (`CodUsu`),
  KEY `fk_usuario` (`RolUsu`),
  CONSTRAINT `fk_usuario` FOREIGN KEY (`RolUsu`) REFERENCES `roles` (`RolUsu`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'admin','123456',120,1);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'proyecto'
--
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ActualizarEstadosVencidos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`127.0.0.1` PROCEDURE `ActualizarEstadosVencidos`()
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
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GuardarAptoFisico` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = cp850 */ ;
/*!50003 SET character_set_results = cp850 */ ;
/*!50003 SET collation_connection  = cp850_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`::1` PROCEDURE `GuardarAptoFisico`(
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
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `NuevoCliente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`127.0.0.1` PROCEDURE `NuevoCliente`(IN `p_dni` INT, IN `p_nom` VARCHAR(50), IN `p_ape` VARCHAR(50), OUT `rta` INT)
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
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RegistrarCobroCuota` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`127.0.0.1` PROCEDURE `RegistrarCobroCuota`(IN `p_dni` INT, IN `p_monto` DECIMAL(10,2), IN `p_tipo` VARCHAR(20), IN `p_forma_pago` VARCHAR(20), OUT `rta` VARCHAR(100), OUT `p_vencimiento` DATE)
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
            SET rta = 'ERROR: Los socios abonan únicamente cuota mensual.';
            SET p_vencimiento = NULL;
        ELSEIF v_idCarnet IS NULL AND p_tipo = 'Mensual' THEN
            SET rta = 'ERROR: Los no socios abonan únicamente cuota diaria (pase por el día).';
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
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ValidarLogin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`127.0.0.1` PROCEDURE `ValidarLogin`(IN `p_usu` VARCHAR(50), IN `p_pass` VARCHAR(50))
BEGIN
    SELECT RolUsu FROM usuario 
    WHERE nombreUsu = p_usu AND passUsu = p_pass;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `VerificarAptoIngreso` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`127.0.0.1` PROCEDURE `VerificarAptoIngreso`(IN `p_dni` INT, OUT `p_estado_out` VARCHAR(50))
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
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `VincularCarnet` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`127.0.0.1` PROCEDURE `VincularCarnet`(IN `p_dni` INT, OUT `rta` VARCHAR(100))
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
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-10-24 20:03:33
