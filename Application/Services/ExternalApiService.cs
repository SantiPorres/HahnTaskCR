using Domain.Common;
using Domain.Interfaces;

namespace Application.Services
{
    public abstract class ExternalApiService<T> : IExternalApiService<T> where T : AuditableBaseEntity
    {
        protected HttpClient _httpClient;
        protected string? _endpoint;
        public ExternalApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<T>> GetDataAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_endpoint);
                response.EnsureSuccessStatusCode();
                return (IEnumerable<T>)response.Content;
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
