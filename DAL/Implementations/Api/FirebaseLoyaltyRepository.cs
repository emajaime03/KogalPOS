using DAL.Contracts;
using Domain;
using Newtonsoft.Json;
using Services.DAL.Tools.Helpers;
using System;
using System.Threading.Tasks;

namespace DAL.Implementations.Api
{
    public class FirebaseLoyaltyRepository : BaseExternalApiClient, ILoyaltyRepository
    {
        public FirebaseLoyaltyRepository()
            : base(ConfiguracionApp.Current.configuracionLocal.Loyalty_ApiEndpoint)
        {
        }

        // 1. LECTURA (GET)
        public async Task<int> ObtenerPuntosAsync(string idFirebaseCliente)
        {
            try
            {
                if (string.IsNullOrEmpty(idFirebaseCliente)) return 0;

                var endpoint = ConstruirEndpoint($"clientes_web/{idFirebaseCliente}");
                var result = await GetAsync<FirebasePuntosRes>(endpoint);

                return result?.Puntos ?? 0;
            }
            catch (Exception)
            {
                // Manejo silencioso. Idealmente: LoggerSystem.LogError(ex);
                return 0;
            }
        }

        // 2. MUTACIÓN ATÓMICA (PATCH)
        public async Task<bool> UpdatePuntosBalanceAsync(string idFirebaseCliente, int deltaPuntos)
        {
            try
            {
                if (string.IsNullOrEmpty(idFirebaseCliente)) return false;

                var endpoint = ConstruirEndpoint($"clientes_web/{idFirebaseCliente}");

                var payload = new
                {
                    puntos = new FirebaseIncrementValue(deltaPuntos)
                };

                // Utilizamos el PatchAsync de tu clase base (ver nota abajo si no existe)
                await PatchAsync<dynamic>(endpoint, payload);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // 3. SINCRONIZACIÓN DE PREMIOS (PUT)
        public async Task SyncPremioAsync(Guid idPremio, decimal puntosRequeridos, string descripcion)
        {
            if (idPremio == Guid.Empty) return;

            var endpoint = ConstruirEndpoint($"premios/{idPremio}");
            var payload = new
            {
                Id = idPremio.ToString(),
                PuntosRequeridos = puntosRequeridos,
                Descripcion = descripcion
            };

            await PutAsync(endpoint, payload);
        }

        // 4. ELIMINACIÓN LÓGICA/FÍSICA (DELETE)
        public async Task EliminarPremioAsync(Guid idPremio)
        {
            if (idPremio == Guid.Empty) return;

            var endpoint = ConstruirEndpoint($"premios/{idPremio}");
            await DeleteAsync(endpoint);
        }

        #region "Helpers Internos y DTOs"

        /// <summary>
        /// Centraliza la construcción de la URL asegurando que siempre se agregue .json 
        /// y el token de autenticación si está configurado.
        /// </summary>
        private string ConstruirEndpoint(string path)
        {
            var endpoint = $"/{path}.json";
            var accessKey = ConfiguracionApp.Current.configuracionLocal.Loyalty_ApiAccessKey;

            if (!string.IsNullOrEmpty(accessKey))
            {
                endpoint += $"?auth={accessKey}";
            }

            return endpoint;
        }

        private class FirebasePuntosRes
        {
            public int Puntos { get; set; }
        }

        /// <summary>
        /// DTO estructurado específicamente para el operador .sv de Firebase.
        /// En C# no podés nombrar una variable ".sv", por eso usamos JsonProperty.
        /// </summary>
        private class FirebaseIncrementValue
        {
            [JsonProperty(".sv")]
            public IncrementDetail Sv { get; set; }

            public FirebaseIncrementValue(int delta)
            {
                Sv = new IncrementDetail { Increment = delta };
            }
        }

        private class IncrementDetail
        {
            [JsonProperty("increment")]
            public int Increment { get; set; }
        }

        #endregion
    }
}