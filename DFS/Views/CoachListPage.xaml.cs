using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DFS.Views
{
    public partial class CoachListPage : ContentPage
    {
        ViewModels.TrainerListViewModel trainerListViewModel;
        public CoachListPage()
        {
            InitializeComponent();

            BindingContext = trainerListViewModel = new ViewModels.TrainerListViewModel();
        }

        async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }

            var trainee = e.SelectedItem as Models.TrainerListModel.Trainee;

            trainerListViewModel.IsServiceInProgress = true;
            String message = await App.TodoManager.Login(new Models.LoginRequestModel("App",trainee.Email,"Trainer","qwertyqazxcvbnm"));
            if (message == "Success")
            {
                await this.Navigation.PushAsync(new TrainerProfilePage());
            }
            trainerListViewModel.IsServiceInProgress = false;
        }
    }
}
