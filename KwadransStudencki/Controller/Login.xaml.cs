using KwadransStudencki.Controller;
using KwadransStudencki.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KwadransStudencki.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public bool IsLogged(bool temp)
        {
            return false;
        }
        private const string IDKey = "IDKey";
        private const string LoginKey = "LoginKey";
        private const string PasswordKey = "PasswordKey";

        public Login()
        {
            InitializeComponent();
        }
        private void LogInButton_Clicked(object sender, EventArgs e)
        {
            //bool isLoginEmpty = string.IsNullOrEmpty(loginEntry.Text);
            //bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            //if(isLoginEmpty || isPasswordEmpty)
            //{

            //}
            //else
            //{

            //}
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Users>();
                conn.CreateTable<Lecturers>();
                var myQuery = conn.Table<Users>().Where(u => u.Login.Equals(loginEntry.Text) && u.Password.Equals(passwordEntry.Text)).First();
                var myLecturers = conn.Table<Lecturers>();
                if (myQuery != null)
                {
                    if (myQuery.TypeAccount == "Staroste")
                    {
                        Application.Current.Properties["UserType"] = "Staroste";
                    }
                    else if (myQuery.TypeAccount == "Lecturer")
                    {
                        Application.Current.Properties["UserType"] = "Lecturer";
                        //Application.Current.Properties["AcademicTitle"] = myLecturers.AcademicTitle;
                    }
                    else if (myQuery.TypeAccount == "Admin")
                    {
                        Application.Current.Properties["UserType"] = "Admin";
                    }
                    //else
                    //{
                    //    Application.Current.Properties["UserType"] = "Błąd TypeAccount";
                    //}

                    Application.Current.Properties["IDSession"] = myQuery.IdUser.ToString();
                    Application.Current.Properties["LoginSession"] = myQuery.Login;
                    Application.Current.Properties["PasswordSession"] = myQuery.Password;
                    UserControl userControl = new UserControl();
                    userControl.SetIsUser(true);

                    App.Current.MainPage = new NavigationPage(new MasterDetail());
                }
                else
                {
                    var result = DisplayAlert("Błąd", "Wprowadziłeś/aś błędne dane lub konto nie istnieje", "OK");
                    Navigation.PushAsync(new Login());

                }
            }

        }
    }
}