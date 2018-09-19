using System;
using System.Threading.Tasks;
using DFS.Models;

namespace DFS.Service
{
    public class DatabaseService : IRestService
    {
        public DatabaseService()
        {
        }

        public Task<string> LoginAsync(LoginRequestModel loginRequestModel)
        {
            throw new NotImplementedException();
        }

        public Task<string> SignUpAsync(TraineeSignupModel signupModel)
        {
            throw new NotImplementedException();
        }
    }
}
