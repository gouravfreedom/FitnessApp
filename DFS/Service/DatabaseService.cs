using System;
using System.Threading.Tasks;
using DFS.Models;
using SQLite;
using Xamarin.Forms;

namespace DFS.Service
{
    public class DatabaseService : IRestService
    {
        SQLiteConnection db;

        public DatabaseService()
        {
            var databasePath = DependencyService.Get<IPlatformPath>().GetPlatformPath("Fitness.db");
            db = new SQLiteConnection(databasePath);
        }

        public LoginResponse.SyncLoginResponse LoginResponse(string SelectedInput)
        {
            LoginResponse.SyncLoginResponse response = new LoginResponse.SyncLoginResponse();

            var query = "SELECT * FROM SYNC_LOGIN WHERE Profile LIKE '" + SelectedInput + "';";

            var data = db.Query<LoginResponse.SyncLoginResponse>(query);

            if(data.Count > 0)
            {
                response = data[0];
            }

            return response;

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



    }
}
