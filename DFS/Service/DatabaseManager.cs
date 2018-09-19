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
    }
}
