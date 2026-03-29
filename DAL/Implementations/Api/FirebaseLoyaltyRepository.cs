using Domain;
using Services.DAL.Tools.Helpers;
using System;
using System.Threading.Tasks;

namespace DAL.Implementations.Api
{
    public class FirebaseLoyaltyRepository : BaseExternalApiClient, Contracts.ILoyaltyRepository
    {
        public FirebaseLoyaltyRepository() 
            : base(ConfiguracionApp.Current.configuracionLocal.Loyalty_ApiEndpoint)
        {
        }

        public int ObtenerPuntos(string nroDocumento)
        {
            try
            {
                if(string.IsNullOrEmpty(nroDocumento)) return 0;

                var endpoint = ObtenerURLClientes(nroDocumento);

                var result = Task.Run(() => GetAsync<FirebasePuntosRes>(endpoint)).GetAwaiter().GetResult();
                return result?.Puntos ?? 0;
            }
            catch (Exception)
            {
                // Manejar error silencioso de red o Firebase
                // Idealmente enviaríamos el error al LoggerSystem pero para no ensuciar la response de BLL retornamos 0 puntos.
                return 0;
            }
        }

        public async Task SumarPuntosAsync(string nroDocumento, int puntos)
        {
            if (string.IsNullOrEmpty(nroDocumento) || puntos <= 0) return;
            
            int actuales = ObtenerPuntos(nroDocumento);
            await ActualizarPuntosAsync(nroDocumento, actuales + puntos);
        }

        public async Task RestarPuntosAsync(string nroDocumento, int puntos)
        {
            if (string.IsNullOrEmpty(nroDocumento) || puntos <= 0) return;
            
            int actuales = ObtenerPuntos(nroDocumento);
            int nuevosPuntos = actuales - puntos;
            if (nuevosPuntos < 0) nuevosPuntos = 0;

            await ActualizarPuntosAsync(nroDocumento, nuevosPuntos);
        }

        private async Task ActualizarPuntosAsync(string nroDocumento, int nuevosPuntos)
        {
            var endpoint = ObtenerURLClientes(nroDocumento);
            if (string.IsNullOrEmpty(endpoint)) return;

            // Aplicamos PATCH sólo a la propiedad Puntos del cliente web
            await PatchAsync(endpoint, new { Puntos = nuevosPuntos });
        }

        private string ObtenerURLClientes(string nroDocumento)
        {
            if (string.IsNullOrEmpty(nroDocumento)) return "";

            var endpoint = $"/clientes_web/{nroDocumento}.json";

            var accessKey = ConfiguracionApp.Current.configuracionLocal.Loyalty_ApiAccessKey;
            if (!string.IsNullOrEmpty(accessKey))
            {
                endpoint += $"?auth={accessKey}";
            }

            return endpoint;
        }

        /// <summary>
        /// DTO interno para mapear la respuesta de Firebase.
        /// Asume que Firebase devuelve un nodo como {"Puntos": 150} o {"puntos": 150}
        /// Newtonsoft es case-insensitive por defecto con las propiedades JSON.
        /// </summary>
        private class FirebasePuntosRes
        {
            public int Puntos { get; set; }
        }
    }
}
