using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Syncfusion.ListView.XForms.iOS;
using UIKit;

namespace DFS.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Rg.Plugins.Popup.Popup.Init();
            global::Xamarin.Forms.Forms.Init();
            //global::Xamarin.FormsMaps.Init ();
            //Xamarin.FormsGoogleMaps.Init("AIzaSyDoXdTaPhf4w3EQpjciwMVsQJ4TPcMGXjY");
            //Xamarin.Forms.DependencyService.Register<Platform_Implemetation_IOS>();

            XamForms.Controls.iOS.Calendar.Init();

            LoadApplication(new App());


            SfListViewRenderer.Init();

            return base.FinishedLaunching(app, options);
        }
    }
}
