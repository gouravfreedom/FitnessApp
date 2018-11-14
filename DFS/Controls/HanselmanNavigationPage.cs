using System;
using Xamarin.Forms;

namespace DFS
{
    public class HanselmanNavigationPage :NavigationPage
    {
        public HanselmanNavigationPage(Page root) : base(root)
        {
            Init();
        }

        public HanselmanNavigationPage()
        {
            Init();
        }

        void Init()
        {

            BarBackgroundColor = Color.FromHex("#191613");
            BarTextColor = Color.White;
            Icon = "about.png";
        }
    }
}

