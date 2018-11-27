using Newtonsoft.Json;

namespace DFS.Models
{
    public class FacebookProfile
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("picture")]
        public Picture Picture { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Picture
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

}
