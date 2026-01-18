using Services.BLL.Services;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Services.Facade
{
    public static class LanguageService
    {
        /// <summary>
        /// Idiomas disponibles en el sistema
        /// </summary>
        public static readonly Dictionary<string, string> IdiomasDisponibles = new Dictionary<string, string>
        {
            { "es-MX", "Español" },
            { "en-US", "English" }
        };

        /// <summary>
        /// Obtiene el código del idioma actual
        /// </summary>
        public static string IdiomaActual => Thread.CurrentThread.CurrentUICulture.Name;

        /// <summary>
        /// Traduce una clave al idioma actual
        /// </summary>
        public static string Translate(string key)
        {
            return LanguageBLL.Translate(key);
        }

        /// <summary>
        /// Cambia el idioma del sistema
        /// </summary>
        /// <param name="codigoIdioma">Código del idioma (ej: es-MX, en-US)</param>
        public static void CambiarIdioma(string codigoIdioma)
        {
            var culture = new CultureInfo(codigoIdioma);
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }
    }
}
