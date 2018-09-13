using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFS
{
	public class TodoItemManager
	{
		IRestService restService;

		public TodoItemManager (IRestService service)
		{
			restService = service;
		}

		public Task<List<TodoItem>> GetTasksAsync ()
		{
			return restService.RefreshDataAsync ();	
		}

        public Task<TodoItem> SaveTaskAsync (TodoItem item, bool isNewItem = false)
		{
			return restService.SaveTodoItemAsync (item, isNewItem);
		}

        public Task<String> SignUp(Models.TraineeSignupModel signupModel){
            return restService.SignUpAsync(signupModel);
        }
        		
	}
}
