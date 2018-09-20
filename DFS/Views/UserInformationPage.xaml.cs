using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DFS.Views
{
    public partial class UserInformationPage : ContentPage
    {
        public UserInformationPage(ViewModels.SignupViewModel signUpViewModel)
        {
            InitializeComponent();

            BindingContext = signUpViewModel;

            MessagingCenter.Subscribe<ViewModels.SignupViewModel>(this, "SignUpSuccess", async (sender) =>
            {
                await this.Navigation.PushAsync(new RootPage());
            });

            MessagingCenter.Subscribe<ViewModels.SignupViewModel>(this, "SignUpFailure", async (sender) =>
            {
                await DisplayAlert("Alert", "Internal Issue. Please Try Again.", "Ok");
            });


        }
    }
}
