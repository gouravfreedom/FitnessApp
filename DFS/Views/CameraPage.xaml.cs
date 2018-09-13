using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Forms;

namespace DFS.Views
{
    public partial class CameraPage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            InitializeAsync();
        }

        public CameraPage()
        {
            InitializeComponent();

            //Initialization = InitializeAsync();

        }

        public Task Initialization { get; private set; }

        private async Task InitializeAsync()
        { 
            // camera feature
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Error", "No Camera Available", "Ok");
                return;

            }

            //var file = await CrossMedia.Current.PickPhotoAsync(
                //new Plugin.Media.Abstractions.PickMediaOptions
                //{
                //    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

                //});

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions  
                {  
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });  

            if (file == null)
            {
                return;
            }

            Debug.WriteLine("Image jkf" + file.Path);
            ImageName.Source = ImageSource.FromStream(() =>  
                {  
                    var stream = file.GetStream();  
                    file.Dispose();  
                    return stream;  
                });  
        }
    }
}
