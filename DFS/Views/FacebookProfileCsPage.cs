using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DFS.Views
{
    public class FacebookProfileCsPage : ContentPage
    {

        public FacebookProfileCsPage()
        {

            Title = "Facebook Profile";
            BackgroundColor = Color.White;
            //var apiRequest = "https://www.facebook.com/login.php?skip_api_login=1&display=popup&response_type=token&api_key=319948035479489&signed_next=1&next=https%3A%2F%2Fwww.facebook.com%2Fv3.1%2Fdialog%2Foauth%3Fredirect_uri%3Dhttps%253A%252F%252Fwww.facebook.com%252Fconnect%252Flogin_success.html%26client_id%3D350372338845678%26ret%3Dlogin%26logger_id%3Daa8e492a-3469-543e-12da-f4cb96d49c81&cancel_url=https%3A%2F%2Fwww.facebook.com%2Fconnect%2Flogin_success.html%3Ferror%3Daccess_denied%26error_code%3D200%26error_description%3DPermissions%2Berror%26error_reason%3Duser_denied%23_%3D_&display=page&locale=en_GB&logger_id=aa8e492a-3469-543e-12da-f4cb96d49c81";

            var apiRequest = "https://www.facebook.com/v3.2/dialog/oauth?client_id=1699986470106189&redirect_uri=https://www.facebook.com/connect/login_success.html";

            WebView webView = new WebView
            {
                Source = apiRequest,
                HeightRequest = 1
            };

            webView.Navigated += WebViewOnNavigated;

            Content = webView;
        }

        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {

            System.Diagnostics.Debug.WriteLine(e.Url);

            var accessToken = ExtractAccessTokenFromUrl(e.Url);

            if (accessToken != "")
            {
                App.access_code = accessToken;

                await this.Navigation.PopAsync();

            }

        }

        private String ExtractAccessTokenFromUrl(string url)
        {
            if (url.Contains("code"))
            {
                String at = url.Replace("https://www.facebook.com/connect/login_success.html?code=", "");

                return at;
            }

            return string.Empty;
        }
    }
}