using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Plugin.Media;
using System.Collections.Generic;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace DFS.ViewModels
{
    public class SignupViewModel : INotifyPropertyChanged
    {
        private Plugin.Geolocator.Abstractions.Position position = new Plugin.Geolocator.Abstractions.Position();

        private Boolean _isTrainerView { get; set; }

        public Boolean IsTrainerView
        {
            get
            {
                return _isTrainerView;
            }
            set
            {
                _isTrainerView = value;

                RaisePropertyChanged(nameof(IsTrainerView));
            }
        }

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

        private String _confirmPassword { get; set; }

        public String ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;

                RaisePropertyChanged(nameof(ConfirmPassword));
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

        private String _telephoneNumber { get; set; }

        public String TelephoneNumber
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

        private String _height { get; set; }

        public String Height
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

        private String _weight { get; set; }

        public String Weight
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

        private ObservableCollection<String> _specialityList { get; set; }

        public ObservableCollection<String> SpecialityList
        {
            get
            {
                return _specialityList;
            }
            set
            {
                _specialityList = value;

                RaisePropertyChanged(nameof(SpecialityList));
            }
        }

        private int _specialityIndex { get; set; }

        public int SpecialityIndex
        {
            get
            {
                return _specialityIndex;
            }
            set
            {
                _specialityIndex = value;

                RaisePropertyChanged(nameof(SpecialityIndex));
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

        private String _userIcon { get; set; }

        public String UserIcon
        {
            get
            {
                return _userIcon;
            }
            set
            {
                _userIcon = value;

                RaisePropertyChanged(nameof(UserIcon));
            }
        }

        private String _user64String { get; set; }

        public String User64String
        {
            get
            {
                return _user64String;
            }
            set
            {
                _user64String = value;

                RaisePropertyChanged(nameof(User64String));
            }
        }

        private String _experience { get; set; }

        public String Experience
        {
            get
            {
                return _experience;
            }
            set
            {
                _experience = value;

                RaisePropertyChanged(nameof(Experience));
            }
        }

        private String _accolades { get; set; }

        public String Accolades
        {
            get
            {
                return _accolades;
            }
            set
            {
                _accolades = value;

                RaisePropertyChanged(nameof(Accolades));
            }
        }

        private String _certification { get; set; }

        public String Certification
        {
            get
            {
                return _certification;
            }
            set
            {
                _certification = value;

                RaisePropertyChanged(nameof(Certification));
            }
        }

        private String _services { get; set; }

        public String Services
        {
            get
            {
                return _services;
            }
            set
            {
                _services = value;

                RaisePropertyChanged(nameof(Services));
            }
        }

        private string _servicesPrice { get; set; }

        public string ServicesPrice
        {
            get
            {
                return _servicesPrice;
            }
            set
            {
                _servicesPrice = value;

                RaisePropertyChanged(nameof(ServicesPrice));
            }
        }

        private String _serviceInfo { get; set; }

        public String ServiceInfo
        {
            get
            {
                return _serviceInfo;
            }
            set
            {
                _serviceInfo = value;

                RaisePropertyChanged(nameof(ServiceInfo));
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
        public ICommand PictureCommand { get; set; }

         void SelectImage()
        {

        }

        public Task Initialization { get; private set; }

        public SignupViewModel()
        {
            if(App.SelectedView == "Trainee")
            {
                IsTrainerView = false;
            }

            TitleList = new ObservableCollection<String>();
            TitleList.Add("Mr.");
            TitleList.Add("Mrs.");
            TitleList.Add("Miss");

            GenderList = new ObservableCollection<String>();
            GenderList.Add("Male");
            GenderList.Add("Female");

            SportsList = new ObservableCollection<String>();
            SportsList.Add("Cricket");
            SportsList.Add("Baseball");
            SportsList.Add("Football");
            SportsList.Add("Tennis");
            SportsList.Add("Table Tennis");
            SportsList.Add("Basketball");
            SportsList.Add("Swimming");
            SportsList.Add("Athletics");
            SportsList.Add("Others");

            SpecialityList = new ObservableCollection<String>();
            SpecialityList.Add("Cricket");
            SpecialityList.Add("Baseball");
            SpecialityList.Add("Football");
            SpecialityList.Add("Tennis");
            SpecialityList.Add("Table Tennis");
            SpecialityList.Add("Basketball");
            SpecialityList.Add("Swimming");
            SpecialityList.Add("Athletics");
            SpecialityList.Add("Others");

            UserIcon = "defaultIcon.png";

            User64String = "NA";

            // Intialize commands
            SaveCommand = new Command(() => SaveClicked());
            PictureCommand = new Command(() => SelectImage());

            IsServiceInProgress = false;

            DateOfBirth = new DateTime(2000, 1, 1);

            Initialization = InitializeAsync();

        }

        private async void SaveClicked()
        {

            if(MedicalInfo == null || GenderIndex < 0 || Height == null || TelephoneNumber == null || SportsIndex < 0 || TitleIndex < 0 || Weight == null)
            {
                MessagingCenter.Send<SignupViewModel, String>(this, "SignUpFailure", "Please enter all manadatory fields.");
                return;
            }

            IsServiceInProgress = true;

            Models.TraineeSignupModel signupModel = new Models.TraineeSignupModel();

            signupModel.email = EmailAddress;
            signupModel.password = Password;
            signupModel.profile = SelectedView;
            signupModel.signUpMetod = (Password == "fb@trainme") ? "FB" : "App";
            signupModel.imagePayload = User64String;


            Models.TraineeSignupModel.BasicInfo basicInfo = new Models.TraineeSignupModel.BasicInfo();
            basicInfo.address = position.Accuracy + "";
            basicInfo.anyMedicalCondition = MedicalInfo;
            basicInfo.country = position.Altitude + "";
            basicInfo.dateOfBirth = DateOfBirth.ToString();
            basicInfo.gender = GenderList[GenderIndex];
            basicInfo.height = Height + "";
            basicInfo.id = 1;
            basicInfo.imageUrl = "NA";
            basicInfo.instaGramId = "NA";
            basicInfo.latitude = position.Latitude + "";
            basicInfo.longitude = position.Longitude + "";
            basicInfo.mobileNumber = TelephoneNumber + "";
            basicInfo.name = Name;
            basicInfo.phoneNumber = TelephoneNumber + "";
            basicInfo.sportsInterest = SportsList[SportsIndex];
            basicInfo.state = "NA";
            basicInfo.title = TitleList[TitleIndex];
            basicInfo.valueAdded = "NA";
            basicInfo.weight = Weight + "";

            Models.TraineeSignupModel.ProfessionalInfo professionalInfo = new Models.TraineeSignupModel.ProfessionalInfo();
            professionalInfo.speciality = SpecialityList[SpecialityIndex];
            professionalInfo.experience = Experience;
            professionalInfo.accolades = Accolades;

            // Add certificates
            List<Models.TraineeSignupModel.Certifications> certifications = new List<Models.TraineeSignupModel.Certifications>();
            Models.TraineeSignupModel.Certifications certification = new Models.TraineeSignupModel.Certifications();
            certification.certification = Certification;

            certifications.Add(certification);

            professionalInfo.certifications = certifications;

            // Add Services
            List<Models.TraineeSignupModel.Services> services = new List<Models.TraineeSignupModel.Services>();
            Models.TraineeSignupModel.Services service = new Models.TraineeSignupModel.Services();
            service.chargingPeriod = ServiceInfo;
            service.serviceName = Services;
            service.charges = Convert.ToDouble(ServicesPrice);

            services.Add(service);

            professionalInfo.services = services;


            // Creating the final object
            signupModel.basicInfo = basicInfo;
            signupModel.professionalInfo = professionalInfo;

            var message = await App.TodoManager.SignUp(signupModel);

            if (message == "Success")
            {
                MessagingCenter.Send<SignupViewModel>(this, "SignUpSuccess");
            }
            else
            {
                MessagingCenter.Send<SignupViewModel, String>(this, "SignUpFailure", "Internal Issue. Please Try Again.");
            }

            IsServiceInProgress = false;

        }

        private async Task InitializeAsync()
        {

            try
            {
                CheckUpdateProfile();

                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    GetCurrentPosition();

                }
                else if (status != PermissionStatus.Unknown)
                {

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to get location: " + ex);

            }


        }

        private void CheckUpdateProfile()
        {
            if (App.LoginResponse == null || App.LoginResponse.Email == "" || App.LoginResponse.Email == null)
            {
                // Do nothing if no data is available
            }
            else
            {
                Name = App.LoginResponse.basicInfo.Name;
                Height = App.LoginResponse.basicInfo.Height;
                Weight = App.LoginResponse.basicInfo.Weight;
                TelephoneNumber = App.LoginResponse.basicInfo.PhoneNumber;
                DateOfBirth = DateTime.Parse(App.LoginResponse.basicInfo.DateOfBirth);
                MedicalInfo = App.LoginResponse.basicInfo.AnyMedicalCondition;

                GenderIndex = GenderList.IndexOf( App.LoginResponse.basicInfo.Gender);
                TitleIndex = TitleList.IndexOf(App.LoginResponse.basicInfo.Title);

                if (App.SelectedView == "Trainer")
                {
                    SpecialityIndex = SpecialityList.IndexOf(App.LoginResponse.professionalInfo.Speciality);
                    Experience = App.LoginResponse.professionalInfo.Experience;
                    Accolades = App.LoginResponse.professionalInfo.Accolades;
                    Certification = App.LoginResponse.professionalInfo.certifications[0].Certification;
                    Services = App.LoginResponse.professionalInfo.services[0].ServiceName;
                    ServiceInfo = App.LoginResponse.professionalInfo.services[0].ChargingPeriod;
                    ServicesPrice = App.LoginResponse.professionalInfo.services[0].Charges;
                }

                EmailAddress = App.LoginResponse.Email;
                Password = App.LoginResponse.Password;
                User64String = "NA";
                SelectedView = App.SelectedView;

            }
            
        }


        private async void GetCurrentPosition()
        {

            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;


                position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);
                if (position == null)
                {
                    position = await locator.GetLastKnownLocationAsync();

                }


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to get location: " + ex);
            }

        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
