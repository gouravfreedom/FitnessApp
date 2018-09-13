using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DFS
{
    public partial class AboutPage : ContentPage
    {
            	
    	public AboutPage()
    	{
    		InitializeComponent();


            //getData();

        }

        public async Task getData()
        {
            var user = new TodoItem();
            user.email = "peter@klaven";
            user.password = "cityslicka";
            var data = await App.TodoManager.SaveTaskAsync(user, true);
            Debug.WriteLine(data.email);
            Debug.WriteLine(data.password);
        }



    }
}
