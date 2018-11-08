using Xamarin.Forms;

namespace DFS
{
    public partial class App : Application
    {
        public static TodoItemManager TodoManager { get; private set; }

        public static Service.DatabaseManager DatabaseManager { get; private set; }

        public static string SelectedView;

        public App()
        {
            InitializeComponent();

            TodoManager = new TodoItemManager(new HTTPService());

            DatabaseManager = new Service.DatabaseManager(new Service.DatabaseService());

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
