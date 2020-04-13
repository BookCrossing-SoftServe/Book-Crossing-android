using System.Threading.Tasks;
using RestApiClient.models;
using RestApiClient.models.response;

namespace RestApiClient.services.interfaces
{
    public interface IAuthenticate
    { 
        Task<LoggedUser> VerifyCredentialsAsync(LoginModel loginModel);
    }
}
