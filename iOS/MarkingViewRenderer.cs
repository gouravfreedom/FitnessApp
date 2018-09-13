using System;
using System.IO;
using DFS.iOS;
using DFS.Views;

using UIKit;
using Xamarin.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(MarkingView), typeof(MarkingViewRenderer))]
namespace DFS.iOS
{
    public class MarkingViewRenderer : ViewRenderer<MarkingView, SignaturePadView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<MarkingView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                e.OldElement.SaveImageWithBackground = null;
            }
            if (e.NewElement != null)
            {
                e.NewElement.SaveImageWithBackground += NewElement_SaveImageWithBackground;
            }
        }

        string NewElement_SaveImageWithBackground()
        {
            UIGraphics.BeginImageContextWithOptions(Bounds.Size, false, 0f);

            using (var context = UIGraphics.GetCurrentContext())
            {
                Layer.RenderInContext(context);
                using (UIImage img = UIGraphics.GetImageFromCurrentImageContext())
                {
                    UIGraphics.EndImageContext();

                    string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    string filename;
                    do
                    {
                        filename = Path.Combine(folder, "Marking-" + DateTime.Now.Ticks + ".png");
                    }
                    while (File.Exists(filename));

                    img.AsPNG().Save(filename, true);

                    return filename;
                }
            }
        }
    }
}
