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

        const string urlClientes = "/clientes_web";

        public int ObtenerPuntos(string nroDocumento)
        {
            try
            {
                if(string.IsNullOrEmpty(nroDocumento)) return 0;

                // Base path de consulta, ejemplo: /loyalty/puntos/{nroDocumento}.json
                var endpoint = $"{urlClientes}/{nroDocumento}.json";

                var accessKey = ConfiguracionApp.Current.configuracionLocal.Loyalty_ApiAccessKey;
                if (!string.IsNullOrEmpty(accessKey))
                {
                    endpoint += $"?auth={accessKey}";
                }

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
            // Para futuras implementaciones usando el método PostAsync heredado
            await Task.CompletedTask;
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
