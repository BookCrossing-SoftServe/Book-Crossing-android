using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RenameLater.models;

namespace RenameLater
{
    public class HttpRequests
    {
        public HttpClient HttpClient;

        public HttpRequests()
        {
            HttpClient = new HttpClient();
        }

        public async Task<string> GetToken(LoginModel loginModel)
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
                var def = new { token = "" };
                var responseString = await response.Content.ReadAsStringAsync();
                var tokenMsg = JsonConvert.DeserializeAnonymousType(responseString, def);
                return tokenMsg.token;
            }
            catch (Exception e)
            {
                return string.Empty;
            }


        }
    }
}
