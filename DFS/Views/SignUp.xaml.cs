using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DFS.Views
{
    public partial class SignUp : ContentPage
    {
        String SelectedView;
        public SignUp(String _selectedView)
        {
            SelectedView = _selectedView;
            InitializeComponent();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            //await DisplayAlert("Success", "Sign up successful", "OK");

            await this.Navigation.PushAsync(new UserInformationPage());

        }
    }
}
