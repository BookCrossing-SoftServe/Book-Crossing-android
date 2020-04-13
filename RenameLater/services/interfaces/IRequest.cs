using System.Threading.Tasks;
using RestApiClient.models.response;

namespace RestApiClient.services.interfaces
{
    public interface IRequest
    {
        Task CreateRequestAsync(int bookId,LoggedUser credentials);
    }
}
