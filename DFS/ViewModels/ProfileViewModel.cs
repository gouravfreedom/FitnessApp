using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace DFS.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        private Boolean _isReviewsVisible;
        public Boolean IsReviewsVisible
        {
            get
            {
                return _isReviewsVisible;
            }
            set
            {
                _isReviewsVisible = value;
                RaisePropertyChanged(nameof(IsReviewsVisible));
            }
        }

        private Boolean _isServiceVisible;
        public Boolean IsServiceVisible
        {
            get
            {
                return _isServiceVisible;
            }
            set
            {
                _isServiceVisible = value;
                RaisePropertyChanged(nameof(IsServiceVisible));
            }
        }

        private Boolean _isProfileVisible;
        public Boolean IsProfileVisible
        {
            get
            {
                return _isProfileVisible;
            }
            set
            {
                _isProfileVisible = value;
                RaisePropertyChanged(nameof(IsProfileVisible));
            }
        }


        private Color _profileColor;
        public Color ProfileColor
        {
            get
            {
                return _profileColor;
            }
            set
            {
                _profileColor = value;
                RaisePropertyChanged(nameof(ProfileColor));
            }
        }

        private Color _serviceColor;
        public Color ServiceColor
        {
            get
            {
                return _serviceColor;
            }
            set
            {
                _serviceColor = value;
                RaisePropertyChanged(nameof(ServiceColor));
            }
        }

        private Color _reviewColor;
        public Color ReviewColor
        {
            get
            {
                return _reviewColor;
            }
            set
            {
                _reviewColor = value;
                RaisePropertyChanged(nameof(ReviewColor));
            }
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                RaisePropertyChanged(nameof(SelectedIndex));
            }
        }

        private ObservableCollection<String> _serviceListData;
        public ObservableCollection<String> ServiceListData
        {
            get { return _serviceListData; }
            set
            {
                _serviceListData = value;
                RaisePropertyChanged(nameof(ServiceListData));
            }
        }

        public ICommand ServiceCommand { get; set; }
        public ICommand ReviewCommand { get; set; }
        public ICommand ProfileCommand { get; set; }

        public ProfileViewModel()
        {
            _serviceListData = new ObservableCollection<string>();
            _serviceListData.Add("Data");
            _serviceListData.Add("Data");
            _serviceListData.Add("Data");
            _serviceListData.Add("Data");

            _selectedIndex = 0;

            _isProfileVisible = true;
            _isReviewsVisible = false;
            _isServiceVisible = false;

            _profileColor = Color.Green;
            _reviewColor = Color.White;
            _serviceColor = Color.White;

            ServiceCommand = new Command(() => HandleServiceSelection());
            ReviewCommand = new Command(() => HandleReviewSelection());
            ProfileCommand = new Command(() => HandleProfileSelection());
        }

        public void HandleSwipe()
        {
            if(SelectedIndex == 0)
            {
                HandleProfileSelection();
            }else if(SelectedIndex == 1)
            {
                HandleServiceSelection();
            }else
            {
                HandleReviewSelection();
            }
        }

        public void HandleServiceSelection()
        {
            SelectedIndex = 1;
            IsServiceVisible = true;
            IsReviewsVisible = false;
            IsProfileVisible = false;

            ServiceColor = Color.Green;
            ReviewColor = Color.White;
            ProfileColor = Color.White;
        }

        public void HandleReviewSelection()
        {
            SelectedIndex = 2;
            IsServiceVisible = false;
            IsReviewsVisible = true;
            IsProfileVisible = false;

            ServiceColor = Color.White;
            ReviewColor = Color.Green;
            ProfileColor = Color.White;
        }

        public void HandleProfileSelection()
        {
            SelectedIndex = 0;
            IsServiceVisible = false;
            IsReviewsVisible = false;
            IsProfileVisible = true;

            ServiceColor = Color.White;
            ReviewColor = Color.White;
            ProfileColor = Color.Green;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
