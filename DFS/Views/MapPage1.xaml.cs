using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace DFS
{
    public partial class MapPage1 : ContentPage
    {
        
        async Task Googlemaps_PinClickedAsync(object sender, PinClickedEventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Views.PopUpView());
        }


        public MapPage1()
        {
            InitializeComponent();

            googlemaps.PinClicked += async delegate (object sender, PinClickedEventArgs e)
            {
                await Googlemaps_PinClickedAsync(sender, e);
            };

            Initialization = InitializeAsync();
                   

        }

        public Task Initialization { get; private set; }

        private async Task InitializeAsync()
        {
           await GetCurrentPosition();
        }

        public async Task GetCurrentPosition()
        {
            //var stack = new StackLayout { Spacing = 0 };

           
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;
                Plugin.Geolocator.Abstractions.Position position1 = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            System.Diagnostics.Debug.WriteLine(position1.Latitude + " lat");
            System.Diagnostics.Debug.WriteLine(position1.Longitude + " long");

                
          //  var steam = "marker01.png"
                var currentPin = new Pin()
                {
                    Icon = BitmapDescriptorFactory.DefaultMarker(Color.Pink),
                    Type = PinType.Place,
                    Label = "Current Location",
                    Address = "Current Location",
                    Position = new Xamarin.Forms.GoogleMaps.Position(position1.Latitude, position1.Longitude)

                };
            //currentPin.Clicked += CurrentPin_Clicked;

            googlemaps.Pins.Add(currentPin);
            googlemaps.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.GoogleMaps.Position(position1.Latitude, position1.Longitude), Distance.FromMeters(5000)));


              //  var map = new Map(
    		        //MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(30.704, 76.79), Distance.FromMiles(0.3)))
                //    {
                //    	IsShowingUser = true,
                //    	HeightRequest = 100,
                //    	WidthRequest = 960,
                //    	VerticalOptions = LayoutOptions.FillAndExpand
                //    };
                //map.MapType = MapType.Satellite;

                //var position2 = new Xamarin.Forms.Maps.Position(30.705, 76.79); // Latitude, Longitude
                //var pin = new Pin
                //{
                //	Type = PinType.Place,
                //	Position = position2,
                //	Label = "Yes",
                //	Address = "Done"

                //};
                //map.Pins.Add(pin);
                
                
                //stack.Children.Add(map);
        


        }
    }
}
