using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DFS.Views
{
    public partial class UserInformationPage : ContentPage
    {
        public UserInformationPage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {

            Models.TraineeSignupModel signupModel = new Models.TraineeSignupModel();

            signupModel.email = "jdfj@gmail.com";
            signupModel.password = "123456";
            signupModel.profile = "Trainee";
            signupModel.signUpMetod = "App";
            signupModel.imagePayload = "";


            Models.TraineeSignupModel.BasicInfo basicInfo = new Models.TraineeSignupModel.BasicInfo();
            basicInfo.address = "dfdsf";
            basicInfo.anyMedicalCondition = "dfdf";
            basicInfo.country = "sdfjkdf";
            basicInfo.dateOfBirth = "dfjkj";
            basicInfo.gender = "sdfjk";
            basicInfo.height = "dsfjkl";
            basicInfo.id = 1;
            basicInfo.imageUrl = "sdhjf";
            basicInfo.instaGramId = "sdfjk";
            basicInfo.latitude = "sdfjk";
            basicInfo.longitude = "djksf";
            basicInfo.mobileNumber = "sdfdfjk";
            basicInfo.name = "dsfjkl";
            basicInfo.phoneNumber = "dkfj";
            basicInfo.sportsInterest = "fjkjdf";
            basicInfo.state = "sdfjkj";
            basicInfo.title = "sdfjk";
            basicInfo.valueAdded = "dsfjk";
            basicInfo.weight = "sdf";

            signupModel.basicInfo = basicInfo;


            var message = await App.TodoManager.SignUp(signupModel);

            //await this.Navigation.PushAsync(new RootPage());
        }
    }
}
