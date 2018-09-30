using System;
using System.Collections.Generic;
using Plugin.Media;
using Xamarin.Forms;

namespace DFS.Views
{
    public partial class UserInformationPage : ContentPage
    {
        public UserInformationPage(ViewModels.SignupViewModel signUpViewModel)
        {
            InitializeComponent();

            BindingContext = signUpViewModel;

            if(signUpViewModel.SelectedView == "Trainer")
            {
                signUpViewModel.IsTrainerView = true; 
            }

            MessagingCenter.Subscribe<ViewModels.SignupViewModel>(this, "SignUpSuccess", async (sender) =>
            {
                await this.Navigation.PushAsync(new RootPage(signUpViewModel.SelectedView));
            });

            MessagingCenter.Subscribe<ViewModels.SignupViewModel>(this, "SignUpFailure", async (sender) =>
            {
                await DisplayAlert("Alert", "Internal Issue. Please Try Again.", "Ok");
            });


        }

        async void Handle_PictureTapped(object sender, System.EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });

            if (file == null)
            {
                // MessagingCenter.Send<InspectionListViewModel, String>(this, "AlertDisplay", "No File Available. Please try again.");
                return;
            }
            else
            {
                //UserIcon = ImageSource.FromStream(() =>
                //{
                //    var stream = file.GetStream();
                //    file.Dispose();
                //    return stream;
                //});
            }
        }
    }
}
