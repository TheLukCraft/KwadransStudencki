using KwadransStudencki.Model;
using KwadransStudencki.View;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KwadransStudencki
{
    public partial class App : Application
    {
        public static string FilePath;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MasterDetail());
        }
        public App(string filePath)
        {
            InitializeComponent();
            //Users users = new Users()
            //{
            //    Login = "admin",
            //    Password = "admin",
            //    TypeAccount = "Admin"
            //};
            //using (SQLiteConnection conn = new SQLiteConnection(filePath))
            //{
            //    conn.CreateTable<Users>();
            //    int rowsAdded = conn.Insert(users);
            //    conn.Close();
            //}

            //Specialization specialization = new Specialization()
            //{
            //    NameOfSpecialization = "Grafika"
            //};
            //using (SQLiteConnection conn = new SQLiteConnection(filePath))
            //{
            //    conn.CreateTable<Specialization>();
            //    int rowsAdded = conn.Insert(specialization);
            //    conn.Close();

            //}

            //using (SQLiteConnection conn = new SQLiteConnection(filePath))
            //{
            //    conn.CreateTable<Staroste>();
            //}
            Application.Current.Properties.Clear();
            MainPage = new NavigationPage(new MasterDetail());
            FilePath = filePath;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
