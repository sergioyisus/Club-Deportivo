using System;

namespace Club_Deportivo.Entidades
{
    // Representa a los usuarios del sistema (operadores, administrativos y administradores)
    public class E_Usuario
    {
        // Codigo identificador del usuario
        public int CodUsu { get; set; }

        // Nombre de usuario para iniciar sesion
        public string NombreUsu { get; set; }

        // Contraseña de acceso
        public string PassUsu { get; set; }

        // Rol asignado (ej: 120 para Administrador, 121 para Empleado)
        public int RolUsu { get; set; }

        // Estado del usuario en el sistema (true = habilitado, false = dado de baja)
        public bool Activo { get; set; }
    }
}
