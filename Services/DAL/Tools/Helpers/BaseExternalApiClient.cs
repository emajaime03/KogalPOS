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

        protected BaseExternalApiClient(string baseUrl)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        protected async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            
            if (!response.IsSuccessStatusCode)
            {
                // Podríamos lanzar una excepción personalizada aquí
                throw new Exception($"Error al comunicarse con la API: {response.StatusCode} - {response.ReasonPhrase}");
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        protected async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            var jsonRequest = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al comunicarse con la API: {response.StatusCode} - {response.ReasonPhrase}");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(jsonResponse);
        }
    }
}
