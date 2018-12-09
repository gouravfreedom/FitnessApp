using System;
using Newtonsoft.Json;

namespace DFS.Models
{
    public class SetTimeSlotResponseModel
    {
        [JsonProperty("Status")]
        public Status status { get; set; }

        public class Status
        {
            [JsonProperty("status")]
            public string status { get; set; }

        }
    }
}
