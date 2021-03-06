﻿using System;
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

        public Task<String> SignUp(Models.TraineeSignupModel signupModel){
            return restService.SignUpAsync(signupModel);
        }

        public Task<String> Login(Models.LoginRequestModel loginRequestModel)
        {
            return restService.LoginAsync(loginRequestModel);
        }

        public Task<Models.TrainerListModel> FetchTrainerList()
        {
            return restService.FetchTrainerList();
        }

        public Task<String> GetFacebookInfo()
        {
            return restService.GetFacebookInfo();
        }

        public Task<String> SetTimeSlot(Models.SetTimeSlotsRequestModel setTimeSlots)
        {
            return restService.SetCalenderEvent(setTimeSlots);
        }

    }
}
