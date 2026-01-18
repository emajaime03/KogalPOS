using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace UI.Helpers
{
    /// <summary>
    /// Helper para aplicar estilos consistentes a las grillas DevExpress.
    /// Mejora la legibilidad y usabilidad de la interfaz.
    /// Usa FontHelper para mantener consistencia de fuentes.
    /// </summary>
    public static class GridStyleHelper
    {
        // Colores del tema
        private static readonly Color ColorHeaderBackground = Color.FromArgb(233, 236, 239);   // Gris claro
        private static readonly Color ColorHeaderForeground = Color.FromArgb(33, 37, 41);      // Gris muy oscuro
        private static readonly Color ColorRowEven = Color.FromArgb(250, 250, 252);            // Gris muy claro
        private static readonly Color ColorRowOdd = Color.White;
        private static readonly Color ColorRowSelected = Color.FromArgb(217, 237, 247);        // Azul claro
        private static readonly Color ColorRowSelectedForeground = Color.FromArgb(31, 64, 104); // Azul oscuro
        private static readonly Color ColorRowFocused = Color.FromArgb(189, 215, 238);         // Azul selección
        private static readonly Color ColorBorder = Color.FromArgb(200, 200, 200);
        private static readonly Color ColorText = Color.FromArgb(51, 51, 51);                  // Gris oscuro

        /// <summary>
        /// Aplica el estilo completo a un GridView
        /// </summary>
        public static void AplicarEstilo(GridView gridView)
        {
            if (gridView == null) return;

            AplicarEstiloHeader(gridView);
            AplicarEstiloFilas(gridView);
            AplicarEstiloSeleccion(gridView);
            AplicarOpcionesVisuales(gridView);
        }

        /// <summary>
        /// Aplica estilo al header de la grilla
        /// </summary>
        private static void AplicarEstiloHeader(GridView gridView)
        {
            // Header de columnas
            gridView.Appearance.HeaderPanel.BackColor = ColorHeaderBackground;
            gridView.Appearance.HeaderPanel.ForeColor = ColorHeaderForeground;
            gridView.Appearance.HeaderPanel.Font = FontHelper.FuenteEncabezadoGrilla;
            gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView.Appearance.HeaderPanel.Options.UseFont = true;
            gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            // Borde del header
            gridView.Appearance.HeaderPanel.BorderColor = ColorBorder;
            gridView.Appearance.HeaderPanel.Options.UseBorderColor = true;
        }

        /// <summary>
        /// Aplica estilo a las filas (alternado)
        /// </summary>
        private static void AplicarEstiloFilas(GridView gridView)
        {
            // Habilitar filas alternadas
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.EnableAppearanceOddRow = true;

            // Filas pares
            gridView.Appearance.EvenRow.BackColor = ColorRowEven;
            gridView.Appearance.EvenRow.ForeColor = ColorText;
            gridView.Appearance.EvenRow.Options.UseBackColor = true;
            gridView.Appearance.EvenRow.Options.UseForeColor = true;

            // Filas impares
            gridView.Appearance.OddRow.BackColor = ColorRowOdd;
            gridView.Appearance.OddRow.ForeColor = ColorText;
            gridView.Appearance.OddRow.Options.UseBackColor = true;
            gridView.Appearance.OddRow.Options.UseForeColor = true;

            // Estilo general de filas
            gridView.Appearance.Row.Font = FontHelper.FuenteFilaGrilla;
            gridView.Appearance.Row.Options.UseFont = true;

            // Líneas de la grilla
            gridView.Appearance.HorzLine.BackColor = ColorBorder;
            gridView.Appearance.VertLine.BackColor = ColorBorder;

            // Empty area
            gridView.Appearance.Empty.BackColor = Color.White;
            gridView.Appearance.Empty.Options.UseBackColor = true;
        }

        /// <summary>
        /// Aplica estilo a la selección de filas
        /// </summary>
        private static void AplicarEstiloSeleccion(GridView gridView)
        {
            // Fila enfocada
            gridView.Appearance.FocusedRow.BackColor = ColorRowFocused;
            gridView.Appearance.FocusedRow.ForeColor = ColorRowSelectedForeground;
            gridView.Appearance.FocusedRow.Font = FontHelper.FuenteFilaGrilla;
            gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            gridView.Appearance.FocusedRow.Options.UseFont = true;

            // Celda enfocada
            gridView.Appearance.FocusedCell.BackColor = ColorRowFocused;
            gridView.Appearance.FocusedCell.ForeColor = ColorRowSelectedForeground;
            gridView.Appearance.FocusedCell.Options.UseBackColor = true;
            gridView.Appearance.FocusedCell.Options.UseForeColor = true;

            // Filas seleccionadas (múltiple selección)
            gridView.Appearance.SelectedRow.BackColor = ColorRowSelected;
            gridView.Appearance.SelectedRow.ForeColor = ColorRowSelectedForeground;
            gridView.Appearance.SelectedRow.Options.UseBackColor = true;
            gridView.Appearance.SelectedRow.Options.UseForeColor = true;
        }

        /// <summary>
        /// Aplica opciones visuales adicionales
        /// </summary>
        private static void AplicarOpcionesVisuales(GridView gridView)
        {
            // Mostrar líneas horizontales y verticales
            gridView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;

            // Indicador de fila
            gridView.OptionsView.ShowIndicator = true;
            gridView.Appearance.RowSeparator.BackColor = ColorBorder;

            // Padding de celdas
            gridView.RowHeight = 26;

            // Auto-ajustar columnas al contenido
            gridView.BestFitColumns();
        }

        /// <summary>
        /// Aplica estilo de solo lectura (para visualización)
        /// </summary>
        public static void AplicarEstiloSoloLectura(GridView gridView)
        {
            if (gridView == null) return;

            AplicarEstilo(gridView);

            // Color más suave para indicar que no es editable
            gridView.Appearance.Row.BackColor = Color.FromArgb(248, 249, 250);
            gridView.Appearance.Row.ForeColor = ColorText;
            gridView.Appearance.Row.Options.UseBackColor = true;
            gridView.Appearance.Row.Options.UseForeColor = true;
        }

        /// <summary>
        /// Aplica estilo compacto para grillas secundarias
        /// </summary>
        public static void AplicarEstiloCompacto(GridView gridView)
        {
            if (gridView == null) return;

            AplicarEstilo(gridView);

            // Altura de fila más pequeña
            gridView.RowHeight = 24;

            // Fuente un poco más pequeña
            gridView.Appearance.Row.Font = FontHelper.FuentePequena;
            gridView.Appearance.Row.Options.UseFont = true;
        }
    }
}
