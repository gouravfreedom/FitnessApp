using System;
namespace DFS.Models
{
    public class LoginRequestModel
    {
        public LoginRequestModel()
        {
        }

        public LoginRequestModel(string _signUpMetod, string _email, string _profile, string _password)
        {
            signUpMetod = _signUpMetod;
            email = _email;
            profile = _profile;
            password = _password;
        }

        public string signUpMetod { get; set; }

        public string email { get; set; }

        public string profile { get; set; }

        public string password { get; set; }
    }
}
