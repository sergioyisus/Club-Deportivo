using System;

namespace Club_Deportivo.Entidades
{
    // Representa un registro de pago de cuota o pase diario en el sistema
    public class E_Cuota
    {
        // Clave primaria del comprobante de pago
        public int IdCuota { get; set; }

        // Cliente asociado al pago
        public int IdCliente { get; set; }

        // Monto efectivamente cobrado (con descuento si pago en efectivo)
        public decimal MontoAbonado { get; set; }

        // Fecha en que se efectuo el cobro
        public DateTime FechaDePago { get; set; }

        // Fecha hasta la cual tiene vigencia el acceso (30 dias para socios, 1 dia para pase diario)
        public DateTime FechaDeVencimiento { get; set; }

        // Modalidad: "Mensual" para socios o "Diaria" para no socios
        public string TipoCuota { get; set; }
    }
}
