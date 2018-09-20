using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFS
{
	public interface IRestService
	{
	
        Task<String> SignUpAsync(Models.TraineeSignupModel signupModel);

        Task<String> LoginAsync(Models.LoginRequestModel loginRequestModel);

        Models.LoginResponse.SyncLoginResponse LoginResponse(String SelectedInput);
    }
}
