using System;
using System.Collections.Generic;
using System.IO;
using PCLStorage;
using SignaturePad.Forms;
using Xamarin.Forms;

namespace DFS.Views
{
    public partial class SignaturePage : ContentPage
    {
        MarkingView markingView;
        public SignaturePage()
        {
            InitializeComponent();

            markingView = new MarkingView();
            markingView.BackgroundImage = "truck_copy.png";
           
            markingView.StrokeColor = Color.Red;


            signaturePad.Children.Add(markingView);

           


        }

        //public static byte[] ReadFully(Stream input)
        //{
        //    byte[] buffer = new byte[16 * 1024];
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        int read;
        //        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
        //        {
        //            ms.Write(buffer, 0, read);
        //        }
        //        return ms.ToArray();
        //    }
        //}

        private async void OnShowImage(object sender, EventArgs e)
        {

            //Stream image = await markingView.GetImageStreamAsync(SignatureImageFormat.Jpeg, true);
            //var result = ReadFully(image);

            //displayImage.Source = ImageSource.FromStream(() => new MemoryStream(result)); //ImageSource.FromStream( image);

            Label label = new Label();
            label.Text = "positive";
            label.VerticalTextAlignment = TextAlignment.Start;
            label.TextColor = Color.Red;
            markingView.Children.Add(label);

            var pathToimage = markingView.SaveImageWithBackground();
            displayImage.Source = ImageSource.FromFile(pathToimage);
        }
    }



}
