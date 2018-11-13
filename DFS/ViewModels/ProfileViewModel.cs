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
        private String _trainerName;
        public String TrainerName
        {
            get
            {
                return _trainerName;
            }
            set
            {
                _trainerName = value;
                RaisePropertyChanged(nameof(TrainerName));
            }
        }

        private String _serviceDesc;
        public String ServiceDesc
        {
            get
            {
                return _serviceDesc;
            }
            set
            {
                _serviceDesc = value;
                RaisePropertyChanged(nameof(ServiceDesc));
            }
        }

        private String _trainerSpeciality;
        public String TrainerSpeciality
        {
            get
            {
                return _trainerSpeciality;
            }
            set
            {
                _trainerSpeciality = value;
                RaisePropertyChanged(nameof(TrainerSpeciality));
            }
        }

        private String _trainingPlace;
        public String TrainingPlace
        {
            get
            {
                return _trainingPlace;
            }
            set
            {
                _trainingPlace = value;
                RaisePropertyChanged(nameof(TrainingPlace));
            }
        }

        private String _trainerExperience;
        public String TrainerExperience
        {
            get
            {
                return _trainerExperience;
            }
            set
            {
                _trainerExperience = value;
                RaisePropertyChanged(nameof(TrainerExperience));
            }
        }

        private String _trainerAccolades;
        public String TrainerAccolades
        {
            get
            {
                return _trainerAccolades;
            }
            set
            {
                _trainerAccolades = value;
                RaisePropertyChanged(nameof(TrainerAccolades));
            }
        }

        private String _trainerCert;
        public String TrainerCert
        {
            get
            {
                return _trainerCert;
            }
            set
            {
                _trainerCert = value;
                RaisePropertyChanged(nameof(TrainerCert));
            }
        }

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

        private ObservableCollection<Models.LoginResponse.Services> _serviceListData;
        public ObservableCollection<Models.LoginResponse.Services> ServiceListData
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
            ServiceListData = new ObservableCollection<Models.LoginResponse.Services>();

            //Models.LoginResponse.SyncLoginResponse syncLoginResponse = App.DatabaseManager.SyncLoginResponse(App.SelectedView);

            TrainerName = App.LoginResponse.basicInfo.Name;
            TrainerCert = App.LoginResponse.professionalInfo.certifications.ToString();
            TrainingPlace = App.LoginResponse.basicInfo.Address;
            TrainerAccolades = App.LoginResponse.professionalInfo.Accolades;
            TrainerExperience = App.LoginResponse.professionalInfo.Experience;
            TrainerSpeciality = App.LoginResponse.professionalInfo.Speciality;

            ServiceListData = App.LoginResponse.professionalInfo.services;
                

           

            _selectedIndex = 0;

            _isProfileVisible = true;
            _isReviewsVisible = false;
            _isServiceVisible = false;

            _profileColor = Color.LimeGreen;
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

            ServiceColor = Color.LimeGreen;
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
            ReviewColor = Color.LimeGreen;
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
            ProfileColor = Color.LimeGreen;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
