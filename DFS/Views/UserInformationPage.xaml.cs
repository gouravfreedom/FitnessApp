using System;
using System.Collections.Generic;
using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace DFS.Views
{
    public partial class UserInformationPage : ContentPage
    {
        ViewModels.SignupViewModel signupViewModel;
        public UserInformationPage(ViewModels.SignupViewModel _signUpViewModel)
        {
            InitializeComponent();

            BindingContext = signupViewModel = _signUpViewModel;

            if(signupViewModel.SelectedView == "Trainer")
            {
                signupViewModel.IsTrainerView = true; 
            }

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<ViewModels.SignupViewModel>(this, "SignUpSuccess", async (sender) =>
            {
                await this.Navigation.PushAsync(new RootPage(signupViewModel.SelectedView));
            });

            MessagingCenter.Subscribe<ViewModels.SignupViewModel, String>(this, "SignUpFailure", async (sender, message) =>
            {
                await DisplayAlert("Alert", message, "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<ViewModels.SignupViewModel>(this, "SignUpSuccess");
            MessagingCenter.Unsubscribe<ViewModels.SignupViewModel, String>(this, "SignUpFailure");
        }

        async void Handle_PictureTapped(object sender, System.EventArgs e)
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Photos))
                    {
                        //await DisplayAlert("Need location", "Gunna need that location", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Photos);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Photos))
                        status = results[Permission.Photos];
                }

                if (status == PermissionStatus.Granted)
                {
                    var file = await CrossMedia.Current.PickPhotoAsync(
                    new Plugin.Media.Abstractions.PickMediaOptions
                    {
                        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

                    });

                    if (file == null)
                    {
                        return;
                    }
                    else
                    {
                        signupViewModel.UserIcon = file.Path;

                        using(var fs = file.GetStream())
                        {
                            var imageData = new byte[fs.Length];
                            fs.Read(imageData, 0, (int)fs.Length);
                            signupViewModel.User64String = Convert.ToBase64String(imageData);

                        }


                    }
                }
                else if (status != PermissionStatus.Unknown)
                {

                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to get location: " + ex);
            }


        }
    }
}
