﻿using Xamarin.Forms;

namespace DFS
{
    public partial class App : Application
    {
        public static TodoItemManager TodoManager { get; private set; }

        public App()
        {
            InitializeComponent();

            TodoManager = new TodoItemManager(new HTTPService());

            MainPage = new NavigationPage( new Views.SelectionPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
