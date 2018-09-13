using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DFS.Models;
using Newtonsoft.Json;

namespace DFS
{
    public class HTTPService : IRestService
	{
		HttpClient client;

		public List<TodoItem> Items { get; private set; }

        public HTTPService()
		{			
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
			
		}

		public async Task<List<TodoItem>> RefreshDataAsync()
		{
			Items = new List<TodoItem>();
            		

			return Items;
		}

        public async Task<TodoItem> SaveTodoItemAsync(TodoItem item, bool isNewItem = false)
		{
			var uri = new Uri(string.Format("https://reqres.in/api/login", string.Empty));
            var user = new TodoItem();
			try
			{
				var json = JsonConvert.SerializeObject(item);
				var content = new StringContent(json, Encoding.UTF8, "application/json");

				HttpResponseMessage response = null;
				
			    response = await client.PostAsync(uri, content);
				

				if (response.IsSuccessStatusCode)
				{
                    Debug.WriteLine("ContBCGNVGent" + response.Content.ReadAsStringAsync().Result);
                    Debug.WriteLine("Response" + response.ToString());

                    user.email = "@klaven";
                     user.password = "cityslicka";

				}


			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"ERROR {0}", ex.Message);
			}
            return user;
		}

        public async Task<string> SignUpAsync(TraineeSignupModel signupModel)
        {
            var uri = new Uri("http://192.163.244.92:4080/FitnessApp/manageservices/v1/members/signup");

            try
            {
                var json = JsonConvert.SerializeObject(signupModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);


                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("ContBCGNVGent" + response.Content.ReadAsStringAsync().Result);
                    Debug.WriteLine("Response" + response.ToString());


                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
            return "Success";
        }
    }
}
