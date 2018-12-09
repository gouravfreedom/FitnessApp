using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFS
{
	public interface IRestService
	{
	
        Task<String> SignUpAsync(Models.TraineeSignupModel signupModel);

        Task<String> LoginAsync(Models.LoginRequestModel loginRequestModel);

        Task<Models.TrainerListModel> FetchTrainerList();

        Models.LoginResponse.SyncLoginResponse LoginResponse(String SelectedInput);

        Task<string> GetFacebookInfo();

        Task<string> SetCalenderEvent(Models.SetTimeSlotsRequestModel setTimeSlots);


    }
}
