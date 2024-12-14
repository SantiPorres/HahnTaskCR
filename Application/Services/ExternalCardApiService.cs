using Domain.Entities;

namespace Application.Services
{
    public class ExternalCardApiService : ExternalApiService<Card>
    {
        public static string ResourceUri = "cards";
        public ExternalCardApiService(HttpClient httpClient) : base(httpClient)
        {
            _endpoint = ResourceUri;
        }
    }
}
