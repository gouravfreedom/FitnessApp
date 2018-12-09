using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DFS.Views
{
    public partial class CalenderPage : ContentPage
    {
        ViewModels.CalenderViewModel calenderViewModel;
        DateTime selectedDate;
        public CalenderPage()
        {
            InitializeComponent();

            BindingContext = calenderViewModel = new ViewModels.CalenderViewModel();

            calendar.MinDate = DateTime.Now;

            MessagingCenter.Subscribe<ViewModels.CalenderViewModel, DateTime>(this, "DateSelected", (sender,_selectedDate) =>
            {
                //await this.Navigation.PushAsync(new TimeSelectionPopup());
                TimeView.IsVisible = true;
                OpaqueView.IsVisible = true;

                selectedDate = _selectedDate;

            });

        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            // don't do anything if we just de-selected the row.
            if (e.SelectedItem == null) return;

            // Deselect the item.
            if (sender is ListView lv) lv.SelectedItem = null;

        }

        async void Handle_Calender(object sender, System.EventArgs e)
        {
            TimeView.IsVisible = false;
            OpaqueView.IsVisible = false;

            await DisplayAlert("Alert", "Please pay for " + (calenderViewModel.EndIndex - calenderViewModel.StartingIndex) + " hours.", "Ok");

            Models.SetTimeSlotsRequestModel setTimeSlots = new Models.SetTimeSlotsRequestModel();
            setTimeSlots.emailID = "hkjfhgkj";
            setTimeSlots.addByEmailID = "sdhkhjgf";

            List<Models.SetTimeSlotsRequestModel.TimeSlot> timeSlots = new List<Models.SetTimeSlotsRequestModel.TimeSlot>();

            Models.SetTimeSlotsRequestModel.TimeSlot timeSlot = new Models.SetTimeSlotsRequestModel.TimeSlot();
            timeSlot.day = selectedDate.Day + "";
            timeSlot.month = selectedDate.Month + "";
            timeSlot.year = selectedDate.Year + "";
            timeSlot.startTime = calenderViewModel.ListViewData[calenderViewModel.StartingIndex].LabelName;
            timeSlot.endTime = calenderViewModel.ListViewData[calenderViewModel.EndIndex].LabelName;
            timeSlot.remarks = "sjhdf";

            timeSlots.Add(timeSlot);

            setTimeSlots.timeSlot = timeSlots;

            calenderViewModel.RefreshData();

            calenderViewModel.IsServiceInProgress = true;

            string message = await App.TodoManager.SetTimeSlot(setTimeSlots);

            calenderViewModel.IsServiceInProgress = false;
        }

        void Hide_Calender(object sender, System.EventArgs e)
        {
            TimeView.IsVisible = false;
            OpaqueView.IsVisible = false;
        }
    }
}
