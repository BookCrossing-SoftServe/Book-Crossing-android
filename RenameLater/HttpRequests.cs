using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RenameLater.models;
using RenameLater.models.response;

namespace RenameLater
{
    public class HttpRequests
    {
        public HttpClient HttpClient;

        public HttpRequests()
        {
            HttpClient = new HttpClient();
        }

        public async Task<LoggedUser> GetToken(LoginModel loginModel)
        {
            var credentials = new
            {
                email = loginModel.Login,
                password = loginModel.Password
            };
            var jsonCredentials = JsonConvert.SerializeObject(credentials);
            var data = new StringContent(jsonCredentials, Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync(
                String.Concat(ServerConfiguration.Url, ServerConfiguration.Login),
                data
            );
            try
            {
                
                var responseString = await response.Content.ReadAsStringAsync();
                var loggedUser = JsonConvert.DeserializeObject<LoggedUser>(responseString);
                return loggedUser;
            }
            catch(JsonException)
            {
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
            

        }
    }
}
