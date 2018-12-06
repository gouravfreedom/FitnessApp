using System;
using Xamarin.Forms;

namespace DFS
{
    public class CustomPicker : Picker
    {
        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(string), typeof(CustomPicker), string.Empty);

        public string BorderColor
        {
            get { return (string)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
    }
}
