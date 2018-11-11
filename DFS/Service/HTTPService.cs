﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DFS.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
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
                        Debug.WriteLine("ContBCGNVGent" + response.Content.ReadAsStringAsync().Result);
                        Debug.WriteLine("Response" + response.ToString());
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
                var uri = new Uri("http://104.238.81.169:4080/FitnessApp/manageservices/v1/members/signup?wsdl");

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

                        LoginResponse.SyncLoginResponse syncLoginResponse = new LoginResponse.SyncLoginResponse();

                        syncLoginResponse.Status = "AV";
                        syncLoginResponse.Profile = App.SelectedView;
                        syncLoginResponse.SignUpMetod = "App";
                        syncLoginResponse.Password = "";
                        syncLoginResponse.Email = "";
                        syncLoginResponse.Name = signupModel.basicInfo.name;
                        syncLoginResponse.Gender = signupModel.basicInfo.gender;
                        syncLoginResponse.Country = signupModel.basicInfo.country;
                        syncLoginResponse.State = signupModel.basicInfo.state;
                        syncLoginResponse.Address = signupModel.basicInfo.address;
                        syncLoginResponse.ImageUrl = signupModel.basicInfo.imageUrl;
                        syncLoginResponse.PhoneNumber = signupModel.basicInfo.phoneNumber;
                        syncLoginResponse.InstaGramId = signupModel.basicInfo.instaGramId;
                        syncLoginResponse.Latitude = signupModel.basicInfo.latitude;
                        syncLoginResponse.Longitude = signupModel.basicInfo.longitude;
                        syncLoginResponse.Speciality = signupModel.professionalInfo.speciality;
                        syncLoginResponse.Experience = signupModel.professionalInfo.experience;
                        syncLoginResponse.Accolades = signupModel.professionalInfo.accolades;
                        syncLoginResponse.Certification = "";

                        foreach(var item in signupModel.professionalInfo.certifications)
                        {
                            syncLoginResponse.Certification += item.certification = " ";
                        }

                        db.Insert(syncLoginResponse);


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

                    db.Query<LoginResponse.SyncLoginResponse>("DELETE FROM SYNC_LOGIN");

                    if (response.IsSuccessStatusCode)
                    {
                        var responseJson = response.Content.ReadAsStringAsync().Result;
                        LoginResponse responseItem = JsonConvert.DeserializeObject<Models.LoginResponse>(responseJson);

                        App.LoginResponse = responseItem;

                        LoginResponse.SyncLoginResponse syncLoginResponse;

                        foreach (var item in responseItem.member)
                        {

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
                            syncLoginResponse.Certification = "";

                            foreach (var syncItem in item.professionalInfo.certifications)
                            {
                                syncLoginResponse.Certification += syncItem.Certification;
                            }
                            db.Insert(syncLoginResponse);
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
