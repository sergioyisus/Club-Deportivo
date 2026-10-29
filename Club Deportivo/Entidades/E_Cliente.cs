using System;

namespace Club_Deportivo.Entidades
{
    // Representa a un cliente del club (sea socio o no socio)
    public class E_Cliente
    {
        // Identificador unico auto-incremental generado por la base de datos
        public int IdCliente { get; set; }

        // DNI del cliente (clave unica de identificacion para búsquedas y trámites)
        public int Dni { get; set; }

        // Datos personales básicos
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        // Indica si el cliente esta habilitado para ingresar a las instalaciones (cuota al dia)
        public bool EstadoHabilitado { get; set; }

        // Informacion de contacto
        public string Telefono { get; set; }
        public string Email { get; set; }

        // Metodo auxiliar para visualizar al cliente de forma clara en listados o mensajes
        public override string ToString()
        {
            return Nombre + " " + Apellido + " (DNI: " + Dni + ")";
        }
    }
}
