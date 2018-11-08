using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DFS.Views
{
    public partial class SelectionPage : ContentPage
    {
        public SelectionPage()
        {
            InitializeComponent();
        }

        async void Handle_TraineeAsync(object sender, System.EventArgs e)
        {
            TraineeLabel.TextColor = Color.FromHex(Application.Current.Resources["BlackColor"].ToString());
            TraineeFrame.BackgroundColor = Color.FromRgba(0.55f, 0.80f, 0.04f, 1.0f);
            App.SelectedView = "Trainee";
            await this.Navigation.PushAsync(new LoginPage("Trainee"));
        }

        async void Handle_TrainerAsync(object sender, System.EventArgs e)
        {
            TrainerLabel.TextColor = Color.FromHex(Application.Current.Resources["BlackColor"].ToString());
            TrainerFrame.BackgroundColor = Color.FromRgba(0.55f, 0.80f, 0.04f, 1.0f);
            App.SelectedView = "Trainer";
            await this.Navigation.PushAsync(new LoginPage("Trainer"));
        }

    }
}
