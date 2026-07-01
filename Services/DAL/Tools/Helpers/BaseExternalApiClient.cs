using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Services.DAL.Tools.Helpers
{
    /// <summary>
    /// Helper base para llamadas genéricas a APIs externas (HTTP).
    /// </summary>
    public abstract class BaseExternalApiClient
    {
        protected readonly HttpClient _httpClient;

        // Timeout corto para no dejar la UI "colgada" si el endpoint/clave están mal
        // configurados o la nube no responde. Las llamadas capturan el error y siguen.
        private static readonly TimeSpan _timeout = TimeSpan.FromSeconds(10);

        protected BaseExternalApiClient(string baseUrl)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl),
                Timeout = _timeout
            };
        }

        // NOTA: todos los await usan ConfigureAwait(false) para NO capturar el
        // SynchronizationContext de la UI. Como estas llamadas se consumen de forma
        // sincrónica (.Result / .GetAwaiter().GetResult()) desde el hilo de UI,
        // sin esto se produce un deadlock que congela la aplicación.
        protected async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                // Podríamos lanzar una excepción personalizada aquí
                throw new Exception($"Error al comunicarse con la API: {response.StatusCode} - {response.ReasonPhrase}");
            }

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<T>(json);
        }

        protected async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            var jsonRequest = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al comunicarse con la API: {response.StatusCode} - {response.ReasonPhrase}");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<TResponse>(jsonResponse);
        }

        protected async Task PatchAsync<TRequest>(string endpoint, TRequest data)
        {
            var jsonRequest = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            // HttpRequestMessage para compatibilidad PATCH con .NET Framework
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), endpoint) { Content = content };
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al comunicarse con la API: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }

        protected async Task PutAsync<TRequest>(string endpoint, TRequest data)
        {
            var jsonRequest = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(endpoint, content).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al comunicarse con la API: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }

        protected async Task DeleteAsync(string endpoint)
        {
            var response = await _httpClient.DeleteAsync(endpoint).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al comunicarse con la API: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
    }
}
