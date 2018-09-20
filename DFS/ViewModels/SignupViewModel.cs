using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace DFS.ViewModels
{
    public class SignupViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<String> _titleList { get; set; }

        public ObservableCollection<String> TitleList
        {
            get
            {
                return _titleList;
            }
            set {
                _titleList = value;

                RaisePropertyChanged(nameof(TitleList));
            }
        }

        private int _titleIndex { get; set; }

        public int TitleIndex
        {
            get
            {
                return _titleIndex;
            }
            set
            {
                _titleIndex = value;

                RaisePropertyChanged(nameof(TitleIndex));
            }
        }

        private ObservableCollection<String> _genderList { get; set; }

        public ObservableCollection<String> GenderList
        {
            get
            {
                return _genderList;
            }
            set
            {
                _genderList = value;

                RaisePropertyChanged(nameof(GenderList));
            }
        }

        private int _genderIndex { get; set; }

        public int GenderIndex
        {
            get
            {
                return _genderIndex;
            }
            set
            {
                _genderIndex = value;

                RaisePropertyChanged(nameof(GenderIndex));
            }
        }

        private String _selectedView { get; set; }

        public String SelectedView
        {
            get
            {
                return _selectedView;
            }
            set
            {
                _selectedView = value;

                RaisePropertyChanged(nameof(SelectedView));
            }
        }

        private String _emailAddress { get; set; }

        public String EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                _emailAddress = value;

                RaisePropertyChanged(nameof(EmailAddress));
            }
        }

        private String _password { get; set; }

        public String Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;

                RaisePropertyChanged(nameof(Password));
            }
        }

        private String _name { get; set; }

        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;

                RaisePropertyChanged(nameof(Name));
            }
        }

        private DateTime _dateOfBirth { get; set; }

        public DateTime DateOfBirth 
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value;
                RaisePropertyChanged(nameof(DateOfBirth));
            }
        }

        private int _telephoneNumber { get; set; }

        public int TelephoneNumber
        {
            get
            {
                return _telephoneNumber;
            }
            set
            {
                _telephoneNumber = value;

                RaisePropertyChanged(nameof(TelephoneNumber));
            }
        }

        private float _height { get; set; }

        public float Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;

                RaisePropertyChanged(nameof(Height));
            }
        }

        private float _weight { get; set; }

        public float Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;

                RaisePropertyChanged(nameof(Weight));
            }
        }

        private ObservableCollection<String> _sportsList { get; set; }

        public ObservableCollection<String> SportsList
        {
            get
            {
                return _sportsList;
            }
            set
            {
                _sportsList = value;

                RaisePropertyChanged(nameof(SportsList));
            }
        }

        private int _sportsIndex { get; set; }

        public int SportsIndex
        {
            get
            {
                return _sportsIndex;
            }
            set
            {
                _sportsIndex = value;

                RaisePropertyChanged(nameof(SportsIndex));
            }
        }

        private String _medicalInfo { get; set; }

        public String MedicalInfo
        {
            get
            {
                return _medicalInfo;
            }
            set
            {
                _medicalInfo = value;

                RaisePropertyChanged(nameof(MedicalInfo));
            }
        }

        private Boolean _isServiceInProgress;
        public Boolean IsServiceInProgress
        {
            get { return _isServiceInProgress; }
            set
            {
                _isServiceInProgress = value;
                RaisePropertyChanged(nameof(IsServiceInProgress));
            }
        }

        public ICommand SaveCommand { get; set; }

        public SignupViewModel()
        {
            _titleList = new ObservableCollection<String>();
            _titleList.Add("Mr.");
            _titleList.Add("Mrs.");
            _titleList.Add("Miss");

            _genderList = new ObservableCollection<String>();
            _genderList.Add("Male");
            _genderList.Add("Female");

            _sportsList = new ObservableCollection<String>();
            _sportsList.Add("Cricket");
            _sportsList.Add("Baseball");
            _sportsList.Add("Football");
            _sportsList.Add("Tennis");
            _sportsList.Add("Table Tennis");
            _sportsList.Add("Basketball");
            _sportsList.Add("Swimming");
            _sportsList.Add("Athletics");
            _sportsList.Add("Others");


            // Intialize commands
            SaveCommand = new Command(() => SaveClicked());

            _isServiceInProgress = false;

        }

        private async void SaveClicked(){

            IsServiceInProgress = true;

            Models.TraineeSignupModel signupModel = new Models.TraineeSignupModel();

            signupModel.email = EmailAddress;
            signupModel.password = Password;
            signupModel.profile = SelectedView;
            signupModel.signUpMetod = "App";
            signupModel.imagePayload = "NA";


            Models.TraineeSignupModel.BasicInfo basicInfo = new Models.TraineeSignupModel.BasicInfo();
            basicInfo.address = "dfdsf";
            basicInfo.anyMedicalCondition = MedicalInfo;
            basicInfo.country = "sdfjkdf";
            basicInfo.dateOfBirth = DateOfBirth.ToString();
            basicInfo.gender = GenderList[GenderIndex];
            basicInfo.height = Height + "";
            basicInfo.id = 1;
            basicInfo.imageUrl = "NA";
            basicInfo.instaGramId = "sdfjk";
            basicInfo.latitude = "56.9673483";
            basicInfo.longitude = "-87.3794";
            basicInfo.mobileNumber = TelephoneNumber + "";
            basicInfo.name = Name;
            basicInfo.phoneNumber = TelephoneNumber + "";
            basicInfo.sportsInterest = "fjkjdf";
            basicInfo.state = "sdfjkj";
            basicInfo.title = TitleList[TitleIndex];
            basicInfo.valueAdded = "dsfjk";
            basicInfo.weight = Weight + "";

            signupModel.basicInfo = basicInfo;


            var message = await App.TodoManager.SignUp(signupModel);

            if(message == "Success")
            {
                MessagingCenter.Send<SignupViewModel>(this, "SignUpSuccess");
            }
            else{
                MessagingCenter.Send<SignupViewModel>(this, "SignUpFailure");
            }

            IsServiceInProgress = false;

        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
