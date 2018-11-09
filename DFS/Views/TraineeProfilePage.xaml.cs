using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DFS.Views
{
    public partial class TraineeProfilePage : ContentPage
    {
        public TraineeProfilePage()
        {
            InitializeComponent();

            BindingContext = new ViewModels.TraineeProfileViewModel();
        }
    }
}
