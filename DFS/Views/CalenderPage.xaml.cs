using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DFS.Views
{
    public partial class CalenderPage : ContentPage
    {
        public CalenderPage()
        {
            InitializeComponent();

            BindingContext = new ViewModels.CalenderViewModel();

            MessagingCenter.Subscribe<ViewModels.CalenderViewModel>(this, "DateSelected", (sender) =>
            {
                //await this.Navigation.PushAsync(new TimeSelectionPopup());
                TimeView.IsVisible = true;
                OpaqueView.IsVisible = true;
            });

        }

        void Handle_Calender(object sender, System.EventArgs e)
        {
            TimeView.IsVisible = false;
            OpaqueView.IsVisible = false;
        }
    }
}
