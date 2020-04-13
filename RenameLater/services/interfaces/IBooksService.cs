using System.Collections.Generic;
using System.Threading.Tasks;
using RestApiClient.models;

namespace RestApiClient.services.interfaces
{
    public interface IBooksService
    {
        Task<List<BookModel>> GetAllBooksAsync();
    }
}
