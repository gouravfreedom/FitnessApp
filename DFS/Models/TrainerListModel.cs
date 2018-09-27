using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace DFS.Models
{
    public class TrainerListModel
    {
        public TrainerListModel()
        {
        }

        [JsonProperty("Trainee")]
        public ObservableCollection<Trainee> trainee { get; set; }

        public class Trainee
        {
            [JsonProperty("email")]
            public String Email { get; set; }

            [JsonProperty("name")]
            public String Name { get; set; }

            [JsonProperty("address")]
            public String Address { get; set; }

            [JsonProperty("imageUrL")]
            public String ImageUrL { get; set; }

            [JsonProperty("sportsInterest")]
            public String SportsInterest { get; set; }

            [JsonProperty("status")]
            public String Status { get; set; }

            [JsonProperty("country")]
            public String Country { get; set; }

            [JsonProperty("state")]
            public String State { get; set; }
        }
    }
}
