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

        #region Prop

        private string _selectedView;
        public string SelectedView
        {
            get
            {
                return _selectedView;
            }
            set
            {
                _selectedView = value;

                RaisePropertyChanged(nameof(SelectedView));
            }
        }

        private string _username;
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

        private Boolean _isRememberMe;
        public Boolean IsRememberMe
        {
            get { return _isRememberMe; }
            set
            {
                _isRememberMe = value;
                RaisePropertyChanged(nameof(IsRememberMe));
            }
        }

        private Boolean _isServiceInProgress;
        public Boolean IsServiceInProgress
        {
            get { return _isServiceInProgress; }
            set
            {
                _isServiceInProgress = value;
                RaisePropertyChanged(nameof(IsServiceInProgress));
            }
        }

        #endregion

        public ICommand SignUpCommand { get; private set; }        	
    	public ICommand LoginCommand { get; private set; }
    	

    	public UserProfileViewModel()
    	{
            
            LoginCommand = new Command(() => OnLogin());
            SignUpCommand = new Command(() => OnSignUp());

    	}

    	
        public void DisplayAlert(string title, string message)
        {
    	    string[] values = { title, message };
            MessagingCenter.Send<UserProfileViewModel, string[]>(this, "LoginFailure", values);

        }

        public void OnSignUp(){
            MessagingCenter.Send<UserProfileViewModel>(this, "SignUp");
        }


        public async void FacebookData()
        {


            IsServiceInProgress = true;

           
            var message = await App.TodoManager.GetFacebookInfo();

            if (message == "Success")
            {
                Username = App.FacebookProfile.Id;
                UserPassword = "fb@trainme";
                OnLogin();
            }
            else
            {
                MessagingCenter.Send<UserProfileViewModel, string>(this, "LoginFailure", message);
            }

            IsServiceInProgress = false;




        }


        public async void OnLogin() {

            if (Username == null || UserPassword == null || Username == "" || UserPassword == ""){
                MessagingCenter.Send<UserProfileViewModel, string>(this, "LoginFailure", "Please provide Username/Password");
            }
            else
            {
                IsServiceInProgress = true;
                
                Models.LoginRequestModel loginRequestModel = new Models.LoginRequestModel("App", Username, SelectedView, UserPassword);
                var message = await App.TodoManager.Login(loginRequestModel);

                if(message == "Success"){

                    var data = App.LoginResponse;

                    if(data.Profile == null || data.Profile == ""){
                        MessagingCenter.Send<UserProfileViewModel, String>(this, "LoginSuccess", "NAV");
                    }
                    else{
                        MessagingCenter.Send<UserProfileViewModel, String>(this, "LoginSuccess", "AV");
                    }

                }
                else{
                    MessagingCenter.Send<UserProfileViewModel, string>(this, "LoginFailure", message);
                }

                IsServiceInProgress = false;

            }


        }
          	

    	public event PropertyChangedEventHandler PropertyChanged = delegate { };

    	protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
    	{
    		PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
