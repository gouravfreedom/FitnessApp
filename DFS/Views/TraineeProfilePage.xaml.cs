using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DFS.Views
{
    public partial class TraineeProfilePage : ContentPage
    {
        RootPage root;
        public TraineeProfilePage(RootPage root)
        {
            InitializeComponent();

            this.root = root;

            BindingContext = new ViewModels.TraineeProfileViewModel();
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            //this.Navigation.PushAsync(new UserInformationPage(new ViewModels.SignupViewModel()));
            App.Current.MainPage = new UserInformationPage(new ViewModels.SignupViewModel());
        }

        void Handle_TraineMe(object sender, System.EventArgs e)
        {
            this.root.NavigateAsync((int)MenuType.CoachList);
        }
    }
}
