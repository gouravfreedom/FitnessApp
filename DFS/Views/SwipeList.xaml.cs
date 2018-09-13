using System;
using System.Collections.Generic;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace DFS.Views
{
    public partial class SwipeList : ContentPage
    {
        public SwipeList()
        {
            InitializeComponent();
        }

        #region Fields

        Image leftImage;
        Image rightImage;
        int itemIndex = -1;

        #endregion

        #region Private Methods

        private void SetFavorites()
        {
            if (itemIndex >= 0)
            {
                var item = viewModel.InboxInfo[itemIndex];
                item.IsFavorite = !item.IsFavorite;
            }
            this.listView.ResetSwipe();
        }

        private void Delete()
        {
            if (itemIndex >= 0)
                viewModel.InboxInfo.RemoveAt(itemIndex);
            this.listView.ResetSwipe();
        }

        #endregion

        #region CallBacks

        private void ListView_SwipeStarted(object sender, SwipeStartedEventArgs e)
        {
            itemIndex = -1;
        }

        private void ListView_Swiping(object sender, SwipingEventArgs e)
        {
            if (e.ItemIndex == 1 && e.SwipeOffSet > 70)
                e.Handled = true;
        }

        private void ListView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            itemIndex = e.ItemIndex;
        }

        private void leftImage_BindingContextChanged(object sender, EventArgs e)
        {
            if (leftImage == null)
            {
                leftImage = sender as Image;
                (leftImage.Parent as View).GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(SetFavorites) });
                leftImage.Source = ImageSource.FromResource("Swiping.Images.Favorites.png");
            }
        }

        private void rightImage_BindingContextChanged(object sender, EventArgs e)
        {
            if (rightImage == null)
            {
                rightImage = sender as Image;
                (rightImage.Parent as View).GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Delete) });
                rightImage.Source = "about.png";
            }
        }

        #endregion

    }
}
