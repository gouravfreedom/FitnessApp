using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DFS
{
    public class RootPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> Pages { get; set;}
        String selectedView;

        public RootPage(String _selectedView)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Pages = new Dictionary<int, NavigationPage>();
            Master = new MenuPage(this);
            BindingContext = new BaseViewModel
                {
                    Title = "Hanselman",
                    Icon = "slideout.png"
                };
            Pages.Add((int)MenuType.CoachList, new HanselmanNavigationPage(new Views.CoachListPage()));
            Detail = Pages[(int)MenuType.CoachList];

            InvalidateMeasure();

            selectedView = _selectedView;
        }



        public async Task NavigateAsync(int id)
        {

        	
        	Page newPage;
        	if (!Pages.ContainsKey(id))
        	{

        		switch (id)
        		{
                    case (int)MenuType.CoachList:
                        Pages.Add(id, new HanselmanNavigationPage(new Views.CoachListPage()));
        				break;

                    case (int)MenuType.Logout:
                        Application.Current.MainPage = new NavigationPage(new Views.SelectionPage());
                        //await this.Navigation.PushAsync(new NavigationPage(new LoginPage(selectedView)));
                        return;
        			
        		}
        	}

        	newPage = Pages[id];
        	if (newPage == null)
        		return;

        	

        	Detail = newPage;
            this.IsPresented = false;
        }
    }
}

