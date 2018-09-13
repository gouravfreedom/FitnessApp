using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DFS.Views
{
    public partial class LayoutPage : ContentPage
    {
        public LayoutPage()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            System.Diagnostics.Debug.WriteLine(width + "a");
            System.Diagnostics.Debug.WriteLine(height + "height");
            System.Diagnostics.Debug.WriteLine(this.Width + "s");
            System.Diagnostics.Debug.WriteLine(this.Height + "d");

                
                if (width > height)
                {
                    outerStack.Orientation = StackOrientation.Horizontal;
                }
                else
                {
                    outerStack.Orientation = StackOrientation.Vertical;
                }

        }
    }
}
