using System;
using Newtonsoft.Json;

namespace DFS.Models
{
    public class FacebookAccessTokenModel
    {
        public FacebookAccessTokenModel()
        {
        }

        [JsonProperty("access_token")]
        public String AccessToken { get; set; }

        [JsonProperty("token_type")]
        public String TokenType { get; set; }

        [JsonProperty("expires_in")]
        public String ExpiresIn { get; set; }
    }
}
