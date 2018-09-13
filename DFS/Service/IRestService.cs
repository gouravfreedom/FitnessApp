using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFS
{
	public interface IRestService
	{
		Task<List<TodoItem>> RefreshDataAsync ();

        Task<TodoItem> SaveTodoItemAsync (TodoItem item, bool isNewItem);

        Task<String> SignUpAsync(Models.TraineeSignupModel signupModel);
        		
	}
}
