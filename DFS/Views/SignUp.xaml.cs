using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DFS.Views
{
    public partial class SignUp : ContentPage
    {
        ViewModels.SignupViewModel signupViewModel;
        public SignUp(String _selectedView)
        {
            InitializeComponent();

            BindingContext = signupViewModel = new ViewModels.SignupViewModel();

            signupViewModel.SelectedView = _selectedView;

        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            if (signupViewModel.EmailAddress == null || signupViewModel.Password == null || signupViewModel.ConfirmPassword == null)
            {
                await DisplayAlert("Alert", "Please enter Username/Password.", "OK");
            }
            else if (signupViewModel.Password != signupViewModel.ConfirmPassword)
            {
                await DisplayAlert("Alert", "Please enter Username/Password.", "OK");
            }
            else
            {
                await this.Navigation.PushAsync(new UserInformationPage(signupViewModel));
            }
        }
    }
}
