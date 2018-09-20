using System;
namespace DFS.Service
{
    public class DatabaseManager
    {
        IRestService restService;

        public DatabaseManager(IRestService service)
        {
            restService = service;
        }

        public Models.LoginResponse.SyncLoginResponse SyncLoginResponse(string SelectedInput)
        {
            return restService.LoginResponse(SelectedInput);
        }
    }
}
