using System.Drawing;

namespace UI.Helpers
{
    /// <summary>
    /// Helper centralizado para las fuentes de la aplicación.
    /// Proporciona fuentes consistentes para todos los controles.
    /// </summary>
    public static class FontHelper
    {
        // Familia de fuentes principal
        private const string FamiliaFuente = "Segoe UI";
        private const string FamiliaFuenteSemibold = "Segoe UI Semibold";

        // Tamaños de fuente
        private const float TamanoBase = 9F;           // Controles normales
        private const float TamanoTitulo = 14F;        // Títulos de sección
        private const float TamanoSubtitulo = 11F;     // Subtítulos
        private const float TamanoEncabezado = 10F;    // Headers de grillas
        private const float TamanoPequeno = 8F;        // Texto secundario (versión, etc.)

        #region Fuentes para controles generales

        /// <summary>
        /// Fuente base para controles normales (TextBox, ComboBox, Labels, Buttons)
        /// </summary>
        public static Font FuenteBase => new Font(FamiliaFuente, TamanoBase);

        /// <summary>
        /// Fuente base en negrita
        /// </summary>
        public static Font FuenteBaseNegrita => new Font(FamiliaFuente, TamanoBase, FontStyle.Bold);

        /// <summary>
        /// Fuente Semibold para controles destacados
        /// </summary>
        public static Font FuenteBaseSemibold => new Font(FamiliaFuenteSemibold, TamanoBase);

        #endregion

        #region Fuentes para títulos

        /// <summary>
        /// Fuente para títulos principales
        /// </summary>
        public static Font FuenteTitulo => new Font(FamiliaFuente, TamanoTitulo, FontStyle.Bold);

        /// <summary>
        /// Fuente para subtítulos
        /// </summary>
        public static Font FuenteSubtitulo => new Font(FamiliaFuente, TamanoSubtitulo);

        /// <summary>
        /// Fuente para subtítulos en Semibold
        /// </summary>
        public static Font FuenteSubtituloSemibold => new Font(FamiliaFuenteSemibold, TamanoSubtitulo);

        #endregion

        #region Fuentes para grillas

        /// <summary>
        /// Fuente para encabezados de grilla
        /// </summary>
        public static Font FuenteEncabezadoGrilla => new Font(FamiliaFuenteSemibold, TamanoEncabezado);

        /// <summary>
        /// Fuente para filas de grilla
        /// </summary>
        public static Font FuenteFilaGrilla => new Font(FamiliaFuente, TamanoBase);

        #endregion

        #region Fuentes especiales

        /// <summary>
        /// Fuente pequeña para información secundaria (versión, notas al pie)
        /// </summary>
        public static Font FuentePequena => new Font(FamiliaFuente, TamanoPequeno);

        /// <summary>
        /// Fuente para etiquetas de campos
        /// </summary>
        public static Font FuenteEtiqueta => new Font(FamiliaFuenteSemibold, TamanoBase);

        /// <summary>
        /// Fuente para botones importantes
        /// </summary>
        public static Font FuenteBoton => new Font(FamiliaFuenteSemibold, TamanoBase);

        #endregion
    }
}
