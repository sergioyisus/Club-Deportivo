using System;
using System.Drawing;
using System.Windows.Forms;

namespace Club_Deportivo
{
    /// <summary>
    /// Helper para estandarizar la estética institucional de todos los formularios del sistema.
    /// Aplica colores sobrios acordes al prototipo de Windows Forms y asegura el centrado en pantalla.
    /// </summary>
    public static class FormStyler
    {
        // Paleta institucional inspirada en los bocetos del sistema
        public static readonly Color ColorFondoOscuro = Color.FromArgb(18, 20, 24);   // Fondo oscuro de los bocetos (#121418)
        public static readonly Color ColorHeader = Color.FromArgb(218, 226, 236);      // Franja superior (#DAE2EC)
        public static readonly Color ColorHeaderTexto = Color.FromArgb(20, 30, 45);    // Texto encabezado
        public static readonly Color ColorCaja = Color.FromArgb(200, 210, 222);        // Cuadros/inputs/paneles (#C8D2DE)
        public static readonly Color ColorTextoOscuro = Color.FromArgb(30, 35, 42);    // Texto en campos
        public static readonly Color ColorBotonAzul = Color.FromArgb(100, 155, 255);    // Botón azul ingresar/confirmar (#649BFF)
        public static readonly Color ColorBotonVerde = Color.FromArgb(140, 210, 180);   // Botón verde pagar/habilitar (#8CD2B4)
        public static readonly Color ColorBotonRojo = Color.FromArgb(255, 190, 190);    // Botón salir (#FFBEBE)
        public static readonly Color ColorBotonGris = Color.FromArgb(195, 205, 215);    // Botones menú/cancelar/buscar (#C3CDD7)
        public static readonly Color ColorEtiqueta = Color.FromArgb(240, 245, 250);     // Blanco nítido y legible sobre fondo oscuro (#F0F5FA)

        /// <summary>
        /// Aplica la estética visual institucional a cualquier formulario del sistema.
        /// </summary>
        public static void ApplyPinkStyle(Form f)
        {
            ApplyEstiloInstitucional(f);
        }

        public static void ApplyEstiloInstitucional(Form f)
        {
            if (f == null) return;

            f.BackColor = ColorFondoOscuro;
            f.ForeColor = Color.White;
            f.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.FormBorderStyle = FormBorderStyle.FixedSingle;
            f.MaximizeBox = false;

            EstilizarControles(f.Controls, false);
        }

        /// <summary>
        /// Recorre recursivamente los controles para aplicar la tipografía y colores estándar.
        /// </summary>
        public static void EstilizarControles(Control.ControlCollection controls, bool dentroDePanelClaro = false)
        {
            foreach (Control c in controls)
            {
                if (c is TextBox txt)
                {
                    txt.BackColor = ColorCaja;
                    txt.ForeColor = ColorTextoOscuro;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                }
                else if (c is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    btn.Cursor = Cursors.Hand;

                    string texto = btn.Text.Trim().ToUpper();
                    if (texto.Contains("INGRESAR") || texto.Contains("MODIFICAR"))
                    {
                        btn.BackColor = ColorBotonAzul;
                        btn.ForeColor = Color.FromArgb(15, 25, 45);
                    }
                    else if (texto.Contains("PAGO") || texto.Contains("HABILITAR") || texto.Contains("GUARDAR") || texto.Contains("IMPRIMIR"))
                    {
                        btn.BackColor = ColorBotonVerde;
                        btn.ForeColor = Color.FromArgb(15, 35, 25);
                    }
                    else if (texto.Contains("SALIR") || texto.Contains("CANCELAR") || texto.Contains("CERRAR") || texto.Contains("VOLVER"))
                    {
                        btn.BackColor = texto.Contains("SALIR") ? ColorBotonRojo : ColorBotonGris;
                        btn.ForeColor = Color.FromArgb(30, 35, 45);
                    }
                    else
                    {
                        btn.BackColor = ColorBotonGris;
                        btn.ForeColor = Color.FromArgb(20, 30, 45);
                    }
                }
                else if (c is Label lbl)
                {
                    if (lbl.Parent != null && (lbl.Parent.Name == "pnlHeader" || lbl.Parent.BackColor == ColorHeader))
                    {
                        lbl.ForeColor = ColorHeaderTexto;
                        lbl.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    }
                    else if (dentroDePanelClaro)
                    {
                        // Si está dentro de una caja clara (pnlInfo, pnlCategoria, carnet)
                        string txtL = lbl.Text.ToUpper();
                        if (txtL.Contains("INHABILITADO") || txtL.Contains("DENEGADO") || txtL.Contains("VENCIDO"))
                        {
                            lbl.ForeColor = Color.FromArgb(190, 30, 30); // Rojo nítido
                        }
                        else if (txtL.Contains("HABILITADO") || txtL.Contains("VIGENTE"))
                        {
                            lbl.ForeColor = Color.FromArgb(20, 120, 50); // Verde nítido
                        }
                        else
                        {
                            lbl.ForeColor = Color.FromArgb(20, 25, 35); // Texto oscuro nítido
                        }
                    }
                    else
                    {
                        // Etiquetas directas sobre el fondo oscuro
                        lbl.ForeColor = ColorEtiqueta;
                        lbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                    }
                }
                else if (c is RadioButton rdb)
                {
                    rdb.ForeColor = ColorEtiqueta;
                    rdb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                }
                else if (c is CheckBox chk)
                {
                    chk.ForeColor = ColorEtiqueta;
                    chk.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                }
                else if (c is Panel pnl)
                {
                    bool esClaro = pnl.BackColor == ColorCaja || pnl.BackColor == ColorHeader || pnl.Name.StartsWith("pnlInfo") || pnl.Name.StartsWith("pnlCategoria");
                    EstilizarControles(pnl.Controls, esClaro);
                }
                else if (c is GroupBox grp)
                {
                    grp.ForeColor = ColorEtiqueta;
                    EstilizarControles(grp.Controls, false);
                }
            }
        }
    }
}
