using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DFS.Views
{
    public partial class UserInformationPage : ContentPage
    {
        public UserInformationPage()
        {
            InitializeComponent();

            BindingContext = new ViewModels.SignupViewModel();
        }
    }
}
