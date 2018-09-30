﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Plugin.Media;
using System.Collections.Generic;

namespace DFS.ViewModels
{
    public class SignupViewModel : INotifyPropertyChanged
    {
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

        private String _servicesPrice { get; set; }

        public String ServicesPrice
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

            _specialityList = new ObservableCollection<String>();
            _specialityList.Add("Cricket");
            _specialityList.Add("Baseball");
            _specialityList.Add("Football");
            _specialityList.Add("Tennis");
            _specialityList.Add("Table Tennis");
            _specialityList.Add("Basketball");
            _specialityList.Add("Swimming");
            _specialityList.Add("Athletics");
            _specialityList.Add("Others");

            _userIcon = "defaultIcon.png";

            _user64String = "NA";

            _isTrainerView = false;

            // Intialize commands
            SaveCommand = new Command(() => SaveClicked());
            PictureCommand = new Command(() => SelectImage());

            _isServiceInProgress = false;

            _dateOfBirth = new DateTime(2000, 1, 1);


        }

        private async void SaveClicked(){

            IsServiceInProgress = true;

            Models.TraineeSignupModel signupModel = new Models.TraineeSignupModel();

            signupModel.email = EmailAddress;
            signupModel.password = Password;
            signupModel.profile = SelectedView;
            signupModel.signUpMetod = "App";
            signupModel.imagePayload = User64String;


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
            basicInfo.sportsInterest = SportsList[SportsIndex];
            basicInfo.state = "sdfjkj";
            basicInfo.title = TitleList[TitleIndex];
            basicInfo.valueAdded = "dsfjk";
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
            service.chargingPeriod = "hours";
            service.serviceName = Services;
            service.charges = 10;

            services.Add(service);

            professionalInfo.services = services;


            // Creating the final object
            signupModel.basicInfo = basicInfo;
            signupModel.professionalInfo = professionalInfo;

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
