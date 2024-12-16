using System.Text.Json;
using Domain.Common;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public abstract class ExternalApiService<T> : IExternalApiService<T> where T : AuditableBaseEntity
    {
        private readonly HttpClient _httpClient;
        protected string? Endpoint;
        protected ExternalApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["Api:BaseAddress"] ?? "https://api.clashroyale.com/");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Bearer", configuration["Api:BearerToken"]); 
        }

        public async Task<string> GetDataAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(Endpoint);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
