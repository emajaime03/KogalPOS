using DevExpress.XtraEditors;
using System.Drawing;

namespace UI.Helpers
{
    /// <summary>
    /// Helper para aplicar estilos consistentes a los botones DevExpress.
    /// </summary>
    public static class ButtonStyleHelper
    {
        // Colores del tema (azul igual al ribbon de DevExpress)
        private static readonly Color ColorPrimario = Color.FromArgb(0, 114, 198);          // Azul DevExpress
        private static readonly Color ColorPrimarioHover = Color.FromArgb(0, 95, 170);      // Azul más oscuro
        private static readonly Color ColorSecundario = Color.FromArgb(108, 117, 125);      // Gris
        private static readonly Color ColorSecundarioHover = Color.FromArgb(90, 98, 104);   // Gris más oscuro
        private static readonly Color ColorExito = Color.FromArgb(40, 167, 69);             // Verde
        private static readonly Color ColorExitoHover = Color.FromArgb(33, 136, 56);        // Verde más oscuro
        private static readonly Color ColorPeligro = Color.FromArgb(220, 53, 69);           // Rojo
        private static readonly Color ColorPeligroHover = Color.FromArgb(200, 35, 51);      // Rojo más oscuro
        private static readonly Color ColorInfo = Color.FromArgb(23, 162, 184);             // Cyan
        private static readonly Color ColorInfoHover = Color.FromArgb(19, 132, 150);        // Cyan más oscuro
        private static readonly Color ColorClaro = Color.FromArgb(248, 249, 250);           // Casi blanco
        private static readonly Color ColorClaroHover = Color.FromArgb(233, 236, 239);      // Gris muy claro
        private static readonly Color ColorTextoClaro = Color.White;
        private static readonly Color ColorTextoOscuro = Color.FromArgb(33, 37, 41);

        // Colores sutiles para botones ABM (acordes a la estética de la app)
        private static readonly Color ColorAceptar = Color.FromArgb(0, 114, 198);           // Azul DevExpress
        private static readonly Color ColorCancelar = Color.FromArgb(180, 80, 80);          // Rojo suave

        /// <summary>
        /// Aplica estilo primario (azul oscuro) al botón
        /// </summary>
        public static void AplicarEstiloPrimario(SimpleButton btn)
        {
            AplicarEstiloBase(btn, ColorPrimario, ColorTextoClaro);
        }

        /// <summary>
        /// Aplica estilo secundario (gris) al botón
        /// </summary>
        public static void AplicarEstiloSecundario(SimpleButton btn)
        {
            AplicarEstiloBase(btn, ColorSecundario, ColorTextoClaro);
        }

        /// <summary>
        /// Aplica estilo de éxito (verde) al botón
        /// </summary>
        public static void AplicarEstiloExito(SimpleButton btn)
        {
            AplicarEstiloBase(btn, ColorExito, ColorTextoClaro);
        }

        /// <summary>
        /// Aplica estilo de peligro (rojo) al botón
        /// </summary>
        public static void AplicarEstiloPeligro(SimpleButton btn)
        {
            AplicarEstiloBase(btn, ColorPeligro, ColorTextoClaro);
        }

        /// <summary>
        /// Aplica estilo de información (cyan) al botón
        /// </summary>
        public static void AplicarEstiloInfo(SimpleButton btn)
        {
            AplicarEstiloBase(btn, ColorInfo, ColorTextoClaro);
        }

        /// <summary>
        /// Aplica estilo claro (casi blanco con borde) al botón
        /// </summary>
        public static void AplicarEstiloClaro(SimpleButton btn)
        {
            AplicarEstiloBase(btn, ColorClaro, ColorTextoOscuro);
            btn.Appearance.BorderColor = Color.FromArgb(200, 200, 200);
            btn.Appearance.Options.UseBorderColor = true;
        }

        /// <summary>
        /// Aplica estilo outline (solo borde, sin fondo) al botón
        /// </summary>
        public static void AplicarEstiloOutline(SimpleButton btn, Color colorBorde)
        {
            // Forzar que DevExpress respete los colores personalizados
            btn.LookAndFeel.UseDefaultLookAndFeel = false;
            btn.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;

            btn.Appearance.BackColor = Color.Transparent;
            btn.Appearance.ForeColor = colorBorde;
            btn.Appearance.BorderColor = colorBorde;
            btn.Appearance.Font = FontHelper.FuenteBoton;
            btn.Appearance.Options.UseBackColor = true;
            btn.Appearance.Options.UseForeColor = true;
            btn.Appearance.Options.UseBorderColor = true;
            btn.Appearance.Options.UseFont = true;

            // Hover effect
            btn.AppearanceHovered.BackColor = colorBorde;
            btn.AppearanceHovered.ForeColor = ColorTextoClaro;
            btn.AppearanceHovered.Options.UseBackColor = true;
            btn.AppearanceHovered.Options.UseForeColor = true;

            // Apariencia deshabilitado (gris neutro)
            btn.AppearanceDisabled.BackColor = Color.FromArgb(240, 240, 240);
            btn.AppearanceDisabled.ForeColor = Color.FromArgb(160, 160, 160);
            btn.AppearanceDisabled.BorderColor = Color.FromArgb(200, 200, 200);
            btn.AppearanceDisabled.Font = FontHelper.FuenteBoton;
            btn.AppearanceDisabled.Options.UseBackColor = true;
            btn.AppearanceDisabled.Options.UseForeColor = true;
            btn.AppearanceDisabled.Options.UseBorderColor = true;
            btn.AppearanceDisabled.Options.UseFont = true;
        }

        /// <summary>
        /// Aplica estilo outline primario
        /// </summary>
        public static void AplicarEstiloOutlinePrimario(SimpleButton btn)
        {
            AplicarEstiloOutline(btn, ColorPrimario);
        }

        /// <summary>
        /// Aplica estilo outline secundario
        /// </summary>
        public static void AplicarEstiloOutlineSecundario(SimpleButton btn)
        {
            AplicarEstiloOutline(btn, ColorSecundario);
        }

        /// <summary>
        /// Aplica un estilo base al botón con los colores especificados
        /// </summary>
        private static void AplicarEstiloBase(SimpleButton btn, Color colorFondo, Color colorTexto)
        {
            if (btn == null) return;

            // Forzar que DevExpress respete los colores personalizados
            btn.LookAndFeel.UseDefaultLookAndFeel = false;
            btn.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;

            // Apariencia normal
            btn.Appearance.BackColor = colorFondo;
            btn.Appearance.ForeColor = colorTexto;
            btn.Appearance.Font = FontHelper.FuenteBoton;
            btn.Appearance.Options.UseBackColor = true;
            btn.Appearance.Options.UseForeColor = true;
            btn.Appearance.Options.UseFont = true;

            // Calcular color hover (más oscuro)
            var colorHover = OscurecerColor(colorFondo, 15);
            btn.AppearanceHovered.BackColor = colorHover;
            btn.AppearanceHovered.ForeColor = colorTexto;
            btn.AppearanceHovered.Options.UseBackColor = true;
            btn.AppearanceHovered.Options.UseForeColor = true;

            // Apariencia presionado
            var colorPresionado = OscurecerColor(colorFondo, 25);
            btn.AppearancePressed.BackColor = colorPresionado;
            btn.AppearancePressed.ForeColor = colorTexto;
            btn.AppearancePressed.Options.UseBackColor = true;
            btn.AppearancePressed.Options.UseForeColor = true;

            // Apariencia deshabilitado (gris neutro)
            btn.AppearanceDisabled.BackColor = Color.FromArgb(200, 200, 200);
            btn.AppearanceDisabled.ForeColor = Color.FromArgb(130, 130, 130);
            btn.AppearanceDisabled.Font = FontHelper.FuenteBoton;
            btn.AppearanceDisabled.Options.UseBackColor = true;
            btn.AppearanceDisabled.Options.UseForeColor = true;
            btn.AppearanceDisabled.Options.UseFont = true;
        }

        /// <summary>
        /// Oscurece un color por un porcentaje dado
        /// </summary>
        private static Color OscurecerColor(Color color, int porcentaje)
        {
            float factor = 1 - (porcentaje / 100f);
            return Color.FromArgb(
                color.A,
                (int)(color.R * factor),
                (int)(color.G * factor),
                (int)(color.B * factor)
            );
        }

        /// <summary>
        /// Configura un conjunto de botones de acción típicos para una barra de herramientas
        /// </summary>
        public static void ConfigurarBarraHerramientas(
            SimpleButton btnNuevo = null,
            SimpleButton btnDetalle = null,
            SimpleButton btnRefresh = null,
            SimpleButton btnExport = null)
        {
            // Todos los botones de la barra con estilo uniforme (outline secundario)
            if (btnNuevo != null)
            {
                AplicarEstiloOutlineSecundario(btnNuevo);
            }

            if (btnDetalle != null)
            {
                AplicarEstiloOutlineSecundario(btnDetalle);
            }

            if (btnRefresh != null)
            {
                AplicarEstiloOutlineSecundario(btnRefresh);
            }

            if (btnExport != null)
            {
                AplicarEstiloOutlineSecundario(btnExport);
            }
        }

        /// <summary>
        /// Configura botones de acción de un formulario ABM (Aceptar, Cancelar, etc.)
        /// </summary>
        public static void ConfigurarBotonesABM(
            SimpleButton btnModificar = null,
            SimpleButton btnEliminar = null,
            SimpleButton btnRestaurar = null,
            SimpleButton btnAceptar = null,
            SimpleButton btnCancelar = null)
        {
            // Botones superiores con estilo outline secundario (igual que barra de herramientas)
            if (btnModificar != null)
            {
                AplicarEstiloOutlineSecundario(btnModificar);
            }

            if (btnEliminar != null)
            {
                AplicarEstiloOutlineSecundario(btnEliminar);
            }

            if (btnRestaurar != null)
            {
                AplicarEstiloOutlineSecundario(btnRestaurar);
            }

            // Botón Aceptar con fondo azul grisáceo (sutil, acorde a la estética)
            if (btnAceptar != null)
            {
                AplicarEstiloBase(btnAceptar, ColorAceptar, ColorTextoClaro);
            }

            // Botón Cancelar con fondo gris rojizo (sutil)
            if (btnCancelar != null)
            {
                AplicarEstiloBase(btnCancelar, ColorCancelar, ColorTextoClaro);
            }
        }
    }
}
