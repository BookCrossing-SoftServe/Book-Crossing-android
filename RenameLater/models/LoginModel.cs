using Newtonsoft.Json;

namespace RestApiClient.models
{
    public class LoginModel
    {
        [JsonProperty("email")]
        public string Login { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        public LoginModel(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }
    }
}
