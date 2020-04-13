using System;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestApiClient.models;
using RestApiClient.models.response;
using RestApiClient.services.interfaces;

namespace RestApiClient.services.implementations
{
    public class Authenticate : IAuthenticate
    {
        private readonly HttpClient _httpClient;
        
        public async Task<LoggedUser> VerifyCredentialsAsync(LoginModel loginModel)
        {
            var credentialsEncoded = JsonConvert.SerializeObject(loginModel);

            var httpContent = new StringContent(credentialsEncoded, Encoding.UTF8, "application/json");

           


            var httpResponse = await _httpClient.PostAsync(
                    String.Concat(ServerConfiguration.Url, ServerConfiguration.Login),
                    httpContent);

            var loggedUser = JsonConvert.DeserializeObject<LoggedUser>(await httpResponse.Content.ReadAsStringAsync());

            if (loggedUser == null)
            {
                throw new InvalidCredentialException();
            }
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + loggedUser.Token);
            return loggedUser;


        }




        public Authenticate(HttpClient httpClient)
        {
            this._httpClient = httpClient;
         
        }
    }
}
