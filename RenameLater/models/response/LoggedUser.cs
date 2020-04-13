using System.ComponentModel;
using Newtonsoft.Json;

namespace RestApiClient.models.response
{
    public class LoggedUser
    {
        [JsonProperty(Required = Required.Always)]
        public string Token { get; set; }

        [DefaultValue(null)]
        public string Email { get; set; }

        [DefaultValue(null)]
        public string LastName { get; set; }

        [DefaultValue(null)]
        public string FirstName { get; set; }
    }
}
