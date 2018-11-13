using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DFS
{
        public partial class MenuPage : ContentPage
        {
        	RootPage root;
        	List<HomeMenuItem> menuItems;

        public MenuPage()
        {
            InitializeComponent();

        }
        public MenuPage(RootPage root)
        {

            this.root = root;
            InitializeComponent();

            BindingContext = new BaseViewModel
            {
                Title = "Hanselman.Forms",
                Subtitle = "Hanselman.Forms",
                Icon = "slideout.png"
            };

            Models.LoginResponse.SyncLoginResponse syncLoginResponse = App.DatabaseManager.SyncLoginResponse(App.SelectedView);
            //ProfileImage.Source = syncLoginResponse.ImageUrl;
            ProfileName.Text = syncLoginResponse.Name;

            if (App.SelectedView == "Trainer")
            {
                ListViewMenu.ItemsSource = menuItems = new List<HomeMenuItem>
                {
                    new HomeMenuItem { Title = "Profile", MenuType = MenuType.TrainerProfile, Icon ="about.png" },
                    new HomeMenuItem { Title = "Settings", MenuType = MenuType.TrainerProfile, Icon ="about.png" },
                    new HomeMenuItem { Title = "Notifications", MenuType = MenuType.TrainerProfile, Icon ="about.png" },
                    new HomeMenuItem { Title = "Legal", MenuType = MenuType.TrainerProfile, Icon ="about.png" },
                    new HomeMenuItem { Title = "Connect", MenuType = MenuType.TrainerProfile, Icon ="about.png" },
                    new HomeMenuItem { Title = "Events", MenuType = MenuType.TrainerProfile, Icon ="about.png" },
                    new HomeMenuItem { Title = "Logout", MenuType = MenuType.Logout, Icon ="about.png" }

                };

            }
            else
            {
                ListViewMenu.ItemsSource = menuItems = new List<HomeMenuItem>
                {
                    new HomeMenuItem { Title = "Find Trainer", MenuType = MenuType.CoachList, Icon ="about.png" },
                    new HomeMenuItem { Title = "Profile", MenuType = MenuType.TraineeProfile, Icon ="about.png" },
                    new HomeMenuItem { Title = "Settings", MenuType = MenuType.CoachList, Icon ="about.png" },
                    new HomeMenuItem { Title = "Notifications", MenuType = MenuType.CoachList, Icon ="about.png" },
                    new HomeMenuItem { Title = "Previous transaction", MenuType = MenuType.CoachList, Icon ="about.png" },
                    new HomeMenuItem { Title = "Legal", MenuType = MenuType.CoachList, Icon ="about.png" },
                    new HomeMenuItem { Title = "Connect", MenuType = MenuType.CoachList, Icon ="about.png" },
                    new HomeMenuItem { Title = "Events", MenuType = MenuType.CoachList, Icon ="about.png" },
                    new HomeMenuItem { Title = "Logout", MenuType = MenuType.Logout, Icon ="about.png" }

                };

            }

            ListViewMenu.ItemSelected +=  (sender, e) =>
            {
                if (ListViewMenu.SelectedItem == null)
                    return;

                this.root.NavigateAsync((int)((HomeMenuItem)e.SelectedItem).MenuType);
                ((ListView)sender).SelectedItem = null;
            };
        }
    }
}
