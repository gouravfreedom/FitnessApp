using System;
using System.Threading.Tasks;
using DFS.Models;
using Xamarin.Forms;

namespace DFS.Service
{
    public class DatabaseService : IRestService
    {
        public DatabaseService()
        {

        }

        public LoginResponse.SyncLoginResponse LoginResponse(string SelectedInput)
        {
            throw new NotImplementedException();
        }



        // Not Implemented
        public Task<string> LoginAsync(LoginRequestModel loginRequestModel)
        {
            throw new NotImplementedException();
        }

        public Task<string> SignUpAsync(TraineeSignupModel signupModel)
        {
            throw new NotImplementedException();
        }

        public Task<TrainerListModel> FetchTrainerList()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetFacebookInfo()
        {
            throw new NotImplementedException();
        }
    }
}
