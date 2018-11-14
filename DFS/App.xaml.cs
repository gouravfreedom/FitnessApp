using Xamarin.Forms;

namespace DFS
{
    public partial class App : Application
    {
        public static TodoItemManager TodoManager { get; private set; }

        public static Service.DatabaseManager DatabaseManager { get; private set; }

        public static string SelectedView { get; set; }

        public static Models.LoginResponse.Member LoginResponse { get; set; }

        public App()
        {
            InitializeComponent();

            TodoManager = new TodoItemManager(new HTTPService());

            DatabaseManager = new Service.DatabaseManager(new Service.DatabaseService());

            MainPage = new HanselmanNavigationPage( new Views.SelectionPage());
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
