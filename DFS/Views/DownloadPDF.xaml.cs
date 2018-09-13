using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Net.Http;

namespace DFS.Views
{
    public partial class DownloadPDF : ContentPage
    {
        async System.Threading.Tasks.Task Handle_ClickedAsync(object sender, System.EventArgs e)
        {

            var webClient = new HttpClient(); //new WebClient();
            HttpResponseMessage response = null;
            response = await webClient.GetAsync(new Uri("http://www.pdf995.com/samples/pdf.pdf"));

            //if (response.IsSuccessStatusCode)
            //{
            //        var data = response.Content;
            //        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //        string localFilename = $"{_blueways}.pdf";
            //        File.WriteAllBytes(Path.Combine(documentsPath, localFilename), data);
            //        InvokeOnMainThread(() => {
            //            new UIAlertView("Done", "File downloaded and saved", null, "OK", null).Show();
            //        });
                
            //}

                //webClient.DownloadDataCompleted += (s, e) => {
                //    var data = e.Result;
                //    string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                //    string localFilename = $"{_blueways}.pdf";
                //    File.WriteAllBytes(Path.Combine(documentsPath, localFilename), data);
                //    InvokeOnMainThread(() => {
                //        new UIAlertView("Done", "File downloaded and saved", null, "OK", null).Show();
                //    });
                //};
                //var url = new Uri("_blueway.PDF");
                //webClient.DownloadDataAsync(url);

        }

        public DownloadPDF()
        {
            InitializeComponent();
        }
    }
}
