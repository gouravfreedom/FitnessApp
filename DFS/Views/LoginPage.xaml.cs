using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media;

namespace DFS
{
    public partial class LoginPage : ContentPage
    {
        UserProfileViewModel userProfileViewModel;
        public LoginPage(String _selectedView)
        {
            InitializeComponent();

            BindingContext = userProfileViewModel = new UserProfileViewModel();
            userProfileViewModel.SelectedView = _selectedView;



        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(App.access_code != null)
            {
                userProfileViewModel.FacebookData();
            }


            MessagingCenter.Subscribe<UserProfileViewModel, String>(this, "LoginSuccess", async (sender, message) =>
            {
                MessagingCenter.Unsubscribe<UserProfileViewModel>(this, "LoginSuccess");
                MessagingCenter.Unsubscribe<UserProfileViewModel>(this, "LoginFailure");
                if (message == "NAV")
                {
                    await DisplayAlert("Alert", "No user exist. Please sign up.", "OK");

                }
                else
                {
                    Application.Current.MainPage =  new RootPage(userProfileViewModel.SelectedView);
                }
            });

            MessagingCenter.Subscribe<UserProfileViewModel, String>(this, "LoginFailure", async (sender, message) =>
            {

                await DisplayAlert("Alert", message, "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<UserProfileViewModel, String>(this, "LoginSuccess");
            MessagingCenter.Unsubscribe<UserProfileViewModel, String>(this, "LoginFailure");
        }

        async void Handle_Facebook(object sender, System.EventArgs e)
        {
            await this.Navigation.PushAsync(new Views.FacebookProfileCsPage());
        }

        async void Handle_SignUpClickedAsync(object sender, System.EventArgs e)
        {
            await this.Navigation.PushAsync(new Views.SignUp(userProfileViewModel.SelectedView));
        }
    }



}
