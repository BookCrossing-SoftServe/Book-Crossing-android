using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestApiClient.models.response;
using RestApiClient.services.interfaces;

namespace RestApiClient.services.implementations
{
    public class RequestService : IRequest
    {
        private readonly HttpClient _httpClient;

        public RequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateRequestAsync(int bookId,LoggedUser credentials)
        {
            var url = new StringBuilder();
            url.Append(ServerConfiguration.Url).Append(ServerConfiguration.Requests).Append("/").Append(bookId);
            var httpRequest = await _httpClient.PostAsync(url.ToString(),null);

        }
    }
}
