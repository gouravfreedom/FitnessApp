using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace DFS.ViewModels
{
    public class CalenderViewModel : INotifyPropertyChanged
    {

        private bool _isSubmitVisible;
        public bool IsSubmitVisible
        {
            get
            {
                return _isSubmitVisible;
            }
            set
            {
                _isSubmitVisible = value;
                RaisePropertyChanged(nameof(IsSubmitVisible));
            }
        }

        private bool _isServiceInProgress;
        public bool IsServiceInProgress
        {
            get
            {
                return _isServiceInProgress;
            }
            set
            {
                _isServiceInProgress = value;
                RaisePropertyChanged(nameof(IsServiceInProgress));
            }
        }

        private int _startingIndex;
        public int StartingIndex
        {
            get
            {
                return _startingIndex;
            }
            set
            {
                _startingIndex = value;
                RaisePropertyChanged(nameof(StartingIndex));
            }
        }

        private int _endIndex;
        public int EndIndex
        {
            get
            {
                return _endIndex;
            }
            set
            {
                _endIndex = value;
                RaisePropertyChanged(nameof(EndIndex));
            }
        }

        private ObservableCollection<Models.CalenerListModal> _listViewData;
        public ObservableCollection<Models.CalenerListModal> ListViewData
        {
            get
            {
                return _listViewData;
            }
            set
            {
                _listViewData = value;

                RaisePropertyChanged(nameof(ListViewData));
            }
        }

        private ObservableCollection<XamForms.Controls.SpecialDate> attendances;
        public ObservableCollection<XamForms.Controls.SpecialDate> Attendances
        {
            get { return attendances; }
            set { attendances = value; RaisePropertyChanged(nameof(Attendances)); }
        }

        private Models.CalenerListModal _recentlySelectedItem;
        public Models.CalenerListModal RecentlySelectedItem
        {
            get
            {
                return _recentlySelectedItem;
            }
            set
            {
                _recentlySelectedItem = value;

                if (_recentlySelectedItem == null) return;

                int index = ListViewData.IndexOf(_recentlySelectedItem);

                UpdateListState(index);

                RaisePropertyChanged(nameof(RecentlySelectedItem));
            }
        }

        private void UpdateListState(int index)
        {
            if (StartingIndex == 0 && EndIndex == 0 && index == 0)
            {
                StartingIndex = index;
                ListViewData[index] = new Models.CalenerListModal(ListViewData[index].LabelName, Color.Lime);
                return;
            }
            else if (StartingIndex == 0 && EndIndex == 0 && index != 0)
            {

                if (ListViewData[StartingIndex].ListItemColor != Color.Lime)
                {
                    StartingIndex = index;
                    ListViewData[index] = new Models.CalenerListModal(ListViewData[index].LabelName, Color.Lime);
                    return;
                }

            }

            if (StartingIndex < index)
            {
                EndIndex = index;

                for (var tempIndex = 0; tempIndex < ListViewData.Count; tempIndex++)
                {
                    if (tempIndex >= StartingIndex && tempIndex <= EndIndex)
                    {
                        ListViewData[tempIndex] = new Models.CalenerListModal(ListViewData[tempIndex].LabelName, Color.Lime);
                    }
                    else
                    {
                        ListViewData[tempIndex] = new Models.CalenerListModal(ListViewData[tempIndex].LabelName, Color.White);
                    }
                }

            }
            else
            {
                StartingIndex = index;
                EndIndex = 0;

                for (var tempIndex = 0; tempIndex < ListViewData.Count; tempIndex++)
                {
                    if (tempIndex == StartingIndex)
                    {
                        ListViewData[tempIndex] = new Models.CalenerListModal(ListViewData[tempIndex].LabelName, Color.Lime);
                    }
                    else
                    {
                        ListViewData[tempIndex] = new Models.CalenerListModal(ListViewData[tempIndex].LabelName, Color.White);
                    }
                }
            }

        }

        public CalenderViewModel()
        {
            RefreshData();

            _isServiceInProgress = false;

            if(App.SelectedView == "Trainer")
            {
                IsSubmitVisible = false;
            }
            else
            {
                IsSubmitVisible = true;
            }
        }

        public void RefreshData()
        {
            StartingIndex = 0;
            EndIndex = 0;

            ListViewData = new ObservableCollection<Models.CalenerListModal>();

            ListViewData.Add(new Models.CalenerListModal("9:00 AM", Color.White));
            ListViewData.Add(new Models.CalenerListModal("10:00 AM", Color.White));
            ListViewData.Add(new Models.CalenerListModal("11:00 AM", Color.White));
            ListViewData.Add(new Models.CalenerListModal("12:00 AM", Color.White));
            ListViewData.Add(new Models.CalenerListModal("1:00 PM", Color.White));
            ListViewData.Add(new Models.CalenerListModal("2:00 PM", Color.White));
            ListViewData.Add(new Models.CalenerListModal("3:00 PM", Color.White));
            ListViewData.Add(new Models.CalenerListModal("4:00 PM", Color.White));
            ListViewData.Add(new Models.CalenerListModal("5:00 PM", Color.White));
        }

        public ICommand DateChosen
        {
            get
            {
                return new Command((obj) => {
                    System.Diagnostics.Debug.WriteLine(obj as DateTime?);

                    DateTime dateTime = (DateTime)obj;

                    MessagingCenter.Send<CalenderViewModel, DateTime>(this, "DateSelected", dateTime);
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
