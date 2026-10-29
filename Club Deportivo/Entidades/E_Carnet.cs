using System;

namespace Club_Deportivo.Entidades
{
    // Representa la credencial oficial de un socio registrado
    public class E_Carnet
    {
        // Identificador interno del carnet en la base de datos
        public int IdCarnet { get; set; }

        // Numero visible de carnet asignado al socio (correlativo oficial)
        public int NroCarnet { get; set; }

        // Fecha en que se emitio la credencial
        public DateTime FechaEmision { get; set; }
    }
}
