using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DFS.Views
{
    public partial class TrainerProfilePage : ContentPage
    {
        double xTransition;
        ViewModels.ProfileViewModel profileViewModel;
        public TrainerProfilePage()
        {
            InitializeComponent();

            BindingContext = profileViewModel = new ViewModels.ProfileViewModel();

            
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            // don't do anything if we just de-selected the row.
            if (e.SelectedItem == null) return;



            // Deselect the item.
            if (sender is ListView lv)
            {
                Models.LoginResponse.Services service = (Models.LoginResponse.Services)e.SelectedItem;
                profileViewModel.ServiceDesc = service.ChargingPeriod;
                ServiceLabel.IsVisible = true;
                lv.SelectedItem = null;
            }
        }

        void Handle_PanUpdated(object sender, Xamarin.Forms.PanUpdatedEventArgs e)
        {
            if (e.StatusType == GestureStatus.Completed)
            {
                if (xTransition > 50)
                {
                    if(profileViewModel.SelectedIndex != 0)
                    {
                        profileViewModel.SelectedIndex -= 1;
                        profileViewModel.HandleSwipe();
                    }

                }
                else if (xTransition < -50)
                {
                    if (profileViewModel.SelectedIndex < 2)
                    {
                        profileViewModel.SelectedIndex += 1;
                        profileViewModel.HandleSwipe();
                    }

                }

            }
            else
            {
                xTransition = e.TotalX;
            }
        }
    }
}
