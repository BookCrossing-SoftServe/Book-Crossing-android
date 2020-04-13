using Newtonsoft.Json;

namespace RestApiClient.models
{
    public class GenreModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
