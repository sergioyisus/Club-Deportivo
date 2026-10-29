using System;

namespace Club_Deportivo.Entidades
{
    // Registra la auditoria de cada intento de ingreso en el punto de acceso al club
    public class E_RegistroAcceso
    {
        // Identificador unico del registro de acceso
        public int IdAcceso { get; set; }

        // Cliente que intenta ingresar
        public int IdCliente { get; set; }

        // DNI consultado en el molinete o recepcion
        public int Dni { get; set; }

        // Momento exacto del intento de ingreso
        public DateTime FechaHora { get; set; }

        // Resultado de la verificacion: "HABILITADO", "DENEGADO" o "EXCEPCIONAL"
        public string Resultado { get; set; }

        // Motivo del rechazo (ej: cuota vencida, sin apto) o autorizacion excepcional
        public string Motivo { get; set; }

        // Nombre del usuario administrativo o sistema que autorizo el ingreso
        public string AutorizadoPor { get; set; }
    }
}
