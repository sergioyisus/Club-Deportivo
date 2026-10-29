using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Club_Deportivo
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Comprobación e inicialización transparente de la base de datos MySQL
            ClubDeportivo.Datos.Conexion.InicializarBaseDeDatos();

            Application.Run(new frmLogin());
        }
    }
}
