using System.Collections.Generic;
using Newtonsoft.Json;

namespace RestApiClient.models
{
    public class BookModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("available")]
        public bool Available { get; set; }

        [JsonProperty("authors")]
        public List<AuthorModel> Authors { get; set; }

        [JsonProperty("genres")]
        public List<GenreModel> Genres { get; set; }

    }
}
