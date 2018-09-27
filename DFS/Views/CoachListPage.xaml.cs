using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DFS.Views
{
    public partial class CoachListPage : ContentPage
    {
        public CoachListPage()
        {
            InitializeComponent();

            BindingContext = new ViewModels.TrainerListViewModel();
        }

    }
}
