using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using SQLite;
using Xamarin.Forms;

namespace DFS.Views
{
    public partial class DatabasePage : ContentPage
    {
        void More_Clicked(object sender, System.EventArgs e)
        {
            Debug.WriteLine("More_Clicked");
        }

        void Delete_Clicked(object sender, System.EventArgs e)
        {
            Debug.WriteLine("Delete_Clicked");
        }

        SQLiteConnection db;
        void ShowList(object sender, System.EventArgs e)
        {
            listData.Clear();
            // DatabaseIntegration
            var query = db.Table<Stock>();


            foreach (var stock in query){
                listData.Add(stock.Symbol);
                Debug.WriteLine(stock.Symbol);
            }
                
        }

        void AddItem(object sender, System.EventArgs e)
        {
            // DatabaseIntegration
            if(DataEntry.Text != "" && DataEntry.Text != null){

                AddStock(db, DataEntry.Text.ToUpper().Trim().ToString());
                DataEntry.Text = "";
            }

        }

        public static ObservableCollection<string> listData { get; set; }
        public DatabasePage()
        {
            listData = new ObservableCollection<string> { };
            InitializeComponent();

            listView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
            listView.BindingContext = listData;

            // DatabaseIntegration
            var databasePath = DependencyService.Get<IPlatformPath>().GetPlatformPath("MyData.db");
            db = new SQLiteConnection(databasePath);
            db.CreateTable<Stock>();

        }

        public static void AddStock(SQLiteConnection db, string symbol)
        {
            var s = db.Insert(new Stock()
            {
                Symbol = symbol
            });
            //Debug.WriteLine("{0} == {1}", );
        }
    }
}
