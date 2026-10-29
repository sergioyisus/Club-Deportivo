using System;

namespace Club_Deportivo.Entidades
{
    // Representa el certificado medico presentado por el cliente para realizar actividad fisica
    public class E_AptoFisico
    {
        // Identificador del registro medico
        public int IdApto { get; set; }

        // Cliente al que pertenece el certificado
        public int IdCliente { get; set; }

        // Fecha en que el cliente entrego el certificado
        public DateTime FechaPresentacion { get; set; }

        // Fecha en que caduca el apto medico (generalmente a 1 año de presentado)
        public DateTime FechaVencimiento { get; set; }

        // Estado actual evaluado: "Vigente" o "Vencido"
        public string EstadoApto { get; set; }
    }
}
