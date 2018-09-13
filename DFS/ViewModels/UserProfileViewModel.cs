using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DFS
{
    public class UserProfileViewModel : INotifyPropertyChanged
    {
        
        #region UserEmail

        public string _username;

        public string Username
        {
        	get
        	{
        		return _username;
        	}
        	set
        	{
        		_username = value;

        		RaisePropertyChanged(nameof(Username));
        	}
        }

        private string _userPassword;
        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                _userPassword = value;
                RaisePropertyChanged(nameof(UserPassword));
            }
        }
        #endregion

        private int _passwordStrength = 1;
        public int PasswordStrength
        {
        	get { return _passwordStrength; }
        	set
        	{
        		_passwordStrength = value;
        		RaisePropertyChanged(nameof(PasswordStrength));
        	}
        }

       


        int JudgePasswordStrength(string userPassword)
        {
        	var result = PasswordAdvisor.CheckStrength(userPassword);
        	return (int)result; // 1-5
        }

    	
    	public ICommand SignUpCommand { get; private set; }        	
    	public ICommand LoginCommand { get; private set; }
    	

    	public UserProfileViewModel()
    	{
            
            LoginCommand = new Command(async _ => await OnLogin());
            SignUpCommand = new Command(async _ => await OnSignUp());


    	}

    	
        public void DisplayAlert(string title, string message)
        {
    	    string[] values = { title, message };
            MessagingCenter.Send<UserProfileViewModel, string[]>(this, "LoginFailure", values);

        }

        public async Task OnSignUp(){
            MessagingCenter.Send<UserProfileViewModel>(this, "SignUp");
        }

        public async Task OnLogin() {

            MessagingCenter.Send<UserProfileViewModel>(this, "LoginSuccess");
            /* Commented for development
            if (UserPassword != null && Username != null)
            {
                PasswordStrength = JudgePasswordStrength(UserPassword);

                if (PasswordStrength >= 4)
                {
                    if (Username == "Gourav" && UserPassword == "Gourav@123")
                    {
                        MessagingCenter.Send<UserProfileViewModel>(this, "LoginSuccess");
                    }
                    else
                    {
                        DisplayAlert("Invalid Credentials", "Please provide correct credentials.");
                    }
                }
                else
                {
                    DisplayAlert("Alert", "Password Strength is low. Please try again.");
                }
            }
            else
            {
                DisplayAlert("Alert", "Please enter Username/Password");
            }*/




        }
          	

    	public event PropertyChangedEventHandler PropertyChanged = delegate { };

    	protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
    	{
    		PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
