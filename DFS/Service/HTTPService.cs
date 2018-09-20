using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DFS.Models;
using Newtonsoft.Json;
using SQLite;
using Xamarin.Forms;

namespace DFS
{
    public class HTTPService : IRestService
	{
		HttpClient client;
        SQLiteConnection db;

        public HTTPService()
		{			
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;

            // DatabaseIntegration
            var databasePath = DependencyService.Get<IPlatformPath>().GetPlatformPath("Fitness.db");
            db = new SQLiteConnection(databasePath);

            db.CreateTable<LoginResponse.SyncLoginResponse>();

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
                    return "Success";

                }else
                {
                    return "Failure";
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
                return "Failure";
            }

        }

        public async Task<string> LoginAsync(LoginRequestModel loginRequestModel)
        {
            var uri = new Uri("http://192.163.244.92:4080/FitnessApp/manageservices/v1/members/validateMember");

            try
            {
                var json = JsonConvert.SerializeObject(loginRequestModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);

                db.Query<LoginResponse.SyncLoginResponse>("DELETE FROM SYNC_LOGIN");

                if (response.IsSuccessStatusCode)
                {
                    var responseJson = response.Content.ReadAsStringAsync().Result;
                    LoginResponse responseItem = JsonConvert.DeserializeObject<Models.LoginResponse>(responseJson);

                    LoginResponse.SyncLoginResponse syncLoginResponse;

                    foreach(var item in responseItem.member){

                        syncLoginResponse = new LoginResponse.SyncLoginResponse();

                        syncLoginResponse.Status = item.Status;
                        syncLoginResponse.Profile = item.Profile;
                        syncLoginResponse.SignUpMetod = item.SignUpMetod;
                        syncLoginResponse.Password = item.Password;
                        syncLoginResponse.Email = item.Email;
                        syncLoginResponse.Name = item.basicInfo.Name;
                        syncLoginResponse.Gender = item.basicInfo.Gender;
                        syncLoginResponse.Country = item.basicInfo.Country;
                        syncLoginResponse.State = item.basicInfo.State;
                        syncLoginResponse.Address = item.basicInfo.Address;
                        syncLoginResponse.ImageUrl = item.basicInfo.ImageUrl;
                        syncLoginResponse.PhoneNumber = item.basicInfo.PhoneNumber;
                        syncLoginResponse.InstaGramId = item.basicInfo.InstaGramId;
                        syncLoginResponse.Latitude = item.basicInfo.Latitude;
                        syncLoginResponse.Longitude = item.basicInfo.Longitude;
                        syncLoginResponse.DeletionFlag = item.basicInfo.DeletionFlag;
                        syncLoginResponse.Speciality = item.professionalInfo.Speciality;
                        syncLoginResponse.Experience = item.professionalInfo.Experience;
                        syncLoginResponse.Accolades = item.professionalInfo.Accolades;

                        db.Insert(syncLoginResponse);
                    }

                    return "Success";

                }
                else
                {
                    return "Failure";
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
                return "Failure";
            }

        }

        public LoginResponse.SyncLoginResponse LoginResponse(string SelectedInput)
        {
            throw new NotImplementedException();
        }
    }
}
