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
            await this.Navigation.PushAsync(new UserInformationPage(signupViewModel));

        }
    }
}
