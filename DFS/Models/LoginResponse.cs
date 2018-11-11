using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using SQLite;

namespace DFS.Models
{
    public class LoginResponse
    {
        [JsonProperty("Member")]
        public List<Member> member { get; set; }

        public class Member 
        {
            [JsonProperty("status")]
            public String Status { get; set; }

            [JsonProperty("profile")]
            public String Profile { get; set; }

            [JsonProperty("signUpMetod")]
            public String SignUpMetod { get; set; }

            [JsonProperty("password")]
            public String Password { get; set; }

            [JsonProperty("email")]
            public String Email { get; set; }

            [JsonProperty("basicInfo")]
            public BasicInfo basicInfo { get; set; }

            [JsonProperty("professionalInfo")]
            public ProfessionalInfo professionalInfo { get; set; }
        }

        public class BasicInfo
        {
            [JsonProperty("id")]
            public int ID { get; set; }

            [JsonProperty("name")]
            public String Name { get; set; }

            [JsonProperty("gender")]
            public String Gender { get; set; }

            [JsonProperty("country")]
            public String Country { get; set; }

            [JsonProperty("state")]
            public String State { get; set; }

            [JsonProperty("address")]
            public String Address { get; set; }

            [JsonProperty("imageUrl")]
            public String ImageUrl { get; set; }

            [JsonProperty("phoneNumber")]
            public String PhoneNumber { get; set; }

            [JsonProperty("instaGramId")]
            public String InstaGramId { get; set; }

            [JsonProperty("latitude")]
            public String Latitude { get; set; }

            [JsonProperty("longitude")]
            public String Longitude { get; set; }

            [JsonProperty("deletionFlag")]
            public String DeletionFlag { get; set; }
        }

        public class ProfessionalInfo
        {
            [JsonProperty("speciality")]
            public String Speciality { get; set; }

            [JsonProperty("experience")]
            public String Experience { get; set; }

            [JsonProperty("accolades")]
            public String Accolades { get; set; }

            [JsonProperty("certifications")]
            public List<Certifications> certifications { get; set; }

            [JsonProperty("services")]
            public ObservableCollection<Services> services { get; set; }
        }


        public class Certifications
        {
            [JsonProperty("certification")]
            public String Certification { get; set; }

        }

        public class Services
        {
            [JsonProperty("serviceName")]
            public String ServiceName { get; set; }

            [JsonProperty("charges")]
            public String Charges { get; set; }

            [JsonProperty("chargingPeriod")]
            public String ChargingPeriod { get; set; }

        }

        [Table("SYNC_LOGIN")]
        public class SyncLoginResponse
        {
            [AutoIncrement, PrimaryKey]
            public int ID { get; set; }
            public String Status { get; set; }
            public String Profile { get; set; }
            public String SignUpMetod { get; set; }
            public String Password { get; set; }
            public String Email { get; set; }
            public String Name { get; set; }
            public String Gender { get; set; }
            public String Country { get; set; }
            public String State { get; set; }
            public String Address { get; set; }
            public String ImageUrl { get; set; }
            public String PhoneNumber { get; set; }
            public String InstaGramId { get; set; }
            public String Latitude { get; set; }
            public String Longitude { get; set; }
            public String DeletionFlag { get; set; }
            public String Speciality { get; set; }
            public String Experience { get; set; }
            public String Accolades { get; set; }
            public String Certification { get; set; }
        }


    }
}
