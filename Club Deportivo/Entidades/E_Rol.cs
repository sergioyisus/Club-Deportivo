using System;

namespace Club_Deportivo.Entidades
{
    // Representa los roles y niveles de acceso de los usuarios en el sistema (ej: Administrador, Empleado)
    public class E_Rol
    {
        // Codigo identificador unico del rol (clave primaria en tabla roles)
        public int RolUsu { get; set; }

        // Nombre descriptivo del rol asignado para control de permisos
        public string NomRol { get; set; }
    }
}
