using Newtonsoft.Json;

namespace RestApiClient.models
{
    public class AuthorModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }
        
        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

    }
}
