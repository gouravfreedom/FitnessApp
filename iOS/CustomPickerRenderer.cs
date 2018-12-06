using System;
using DFS;
using DFS.iOS.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace DFS.iOS.Controls
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            var element = (CustomPicker)this.Element;

            if (this.Control != null && this.Element != null )
            {
                Control.BorderStyle = UITextBorderStyle.RoundedRect;
                Control.Layer.CornerRadius = 8.0f;
                Control.Layer.MasksToBounds = true;
                Control.ClipsToBounds = true;

                Control.Layer.BorderWidth = 1;

                if(element.BorderColor == "RED"){
                    Control.Layer.BorderColor = UIColor.Red.CGColor;
                }else{
                    Control.Layer.BorderColor = UIColor.LightGray.CGColor;
                }

            }
        }
    }
}
