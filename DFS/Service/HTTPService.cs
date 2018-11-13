using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DFS.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace DFS
{
    public class HTTPService : IRestService
	{
		HttpClient client;

        public HTTPService()
		{			
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;

        }

        public async Task<TrainerListModel> FetchTrainerList()
        {
            TrainerListModel trainerListModel = new TrainerListModel();

            if (CrossConnectivity.Current.IsConnected)
            {
                var uri = new Uri("http://104.238.81.169:4080/FitnessApp/manageservices/v1/members/trainerlist");

                try
                {
                    var content = new StringContent("{}", Encoding.UTF8, "application/json");

                    HttpResponseMessage response = null;

                    response = await client.PostAsync(uri, content);


                    if (response.IsSuccessStatusCode)
                    {
                        var responseJson = response.Content.ReadAsStringAsync().Result;
                        trainerListModel = JsonConvert.DeserializeObject<TrainerListModel>(responseJson);

                        return trainerListModel;
                    }
                    else
                    {
                        return trainerListModel;
                    }


                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"ERROR {0}", ex.Message);
                    return trainerListModel;
                }
            }
            else
            {
                return trainerListModel;
            }

        }


        public async Task<string> SignUpAsync(TraineeSignupModel signupModel)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var uri = new Uri("http://104.238.81.169:4080/FitnessApp/manageservices/v1/members/signup");

                try
                {
                    var json = JsonConvert.SerializeObject(signupModel);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = null;

                    response = await client.PostAsync(uri, content);


                    if (response.IsSuccessStatusCode)
                    {

                        LoginRequestModel loginRequestModel = new LoginRequestModel("App", signupModel.email, App.SelectedView, signupModel.email);
                        var message = await App.TodoManager.Login(loginRequestModel);

                        if (message == "Success")
                        {
                            return "Success";
                        }
                        else
                        {
                            return "Internal Server Error. Please try again.";
                        }

                    }
                    else
                    {
                        return "Internal Server Error. Please try again.";
                    }


                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"ERROR {0}", ex.Message);
                    return "Internal Server Error. Please try again.";
                }
            }
            else
            {
                return "Internet Connectivity error. Please try again.";
            }

        }

        public async Task<string> LoginAsync(LoginRequestModel loginRequestModel)
        {
            if (CrossConnectivity.Current.IsConnected)
            {

                var uri = new Uri("http://104.238.81.169:4080/FitnessApp/manageservices/v1/members/validateMember");

                try
                {
                    var json = JsonConvert.SerializeObject(loginRequestModel);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = null;

                    response = await client.PostAsync(uri, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseJson = response.Content.ReadAsStringAsync().Result;
                        LoginResponse responseItem = JsonConvert.DeserializeObject<Models.LoginResponse>(responseJson);

                        foreach (var item in responseItem.member)
                        {
                            if (item.Profile == App.SelectedView)
                            {
                                App.LoginResponse = item;
                            }
                        }

                        return "Success";

                    }
                    else
                    {
                        return "Internal Server Error. Please try again.";
                    }


                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"ERROR {0}", ex.Message);
                    return "Internal Server Error. Please try again.";
                }
            }else
            {
                return "Internet Connectivity error. Please try again.";
            }

        }
        /*
         * Not implementated methods
        */

        public LoginResponse.SyncLoginResponse LoginResponse(string SelectedInput)
        {
            throw new NotImplementedException();
        }


    }
}
