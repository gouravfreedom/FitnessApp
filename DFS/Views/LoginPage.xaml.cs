using System;
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
        String SelectedView;
        public LoginPage(String _selectedView)
        {
            InitializeComponent();
            SelectedView = _selectedView;

        }

        async void Handle_LogInClickedAsync(object sender, System.EventArgs e)
        {
            await this.Navigation.PushAsync(new Views.UserInformationPage());
        }           

        async void Handle_SignUpClickedAsync(object sender, System.EventArgs e)
        {
            await this.Navigation.PushAsync(new Views.SignUp(SelectedView));
        }
    }



}
