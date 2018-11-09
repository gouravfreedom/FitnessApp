﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Plugin.Geolocator;
using Plugin.Media;
using Rg.Plugins.Popup.Services;

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

            MessagingCenter.Subscribe<UserProfileViewModel, String>(this, "LoginSuccess", async (sender, message) =>
            {
                MessagingCenter.Unsubscribe<UserProfileViewModel>(this, "LoginSuccess");
                MessagingCenter.Unsubscribe<UserProfileViewModel>(this, "LoginFailure");
                if (message == "NAV")
                {
                    await DisplayAlert("Alert","No user exist. Please sign up.","OK");

                }
                else{
                    await this.Navigation.PushAsync(new RootPage(_selectedView));
                }
            });

            MessagingCenter.Subscribe<UserProfileViewModel, string>(this, "LoginFailure", async (sender, message) =>
            {

                await DisplayAlert("Alert", message, "Ok");
            });

        }

        async void Handle_Facebook(object sender, System.EventArgs e)
        {
            await this.Navigation.PushAsync(new FacebookLogin.Views.FacebookProfileCsPage());
        }

        async void Handle_SignUpClickedAsync(object sender, System.EventArgs e)
        {
            await this.Navigation.PushAsync(new Views.SignUp(userProfileViewModel.SelectedView));
        }
    }



}
