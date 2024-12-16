using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class ExternalCardApiService : ExternalApiService<Card>
    {
        public readonly static string ResourceUri = "v1/cards";
        public ExternalCardApiService(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
        {
            Endpoint = ResourceUri;
        }
    }
}
