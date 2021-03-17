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
    public partial class AdminCreateUsers : ContentPage
    {
        public AdminCreateUsers()
        {
            InitializeComponent();
        }

        private void CreateStaroste_Clicked(object sender, EventArgs e)
        {
            Users users = new Users()
            {
                Login = loginUsersEntry.Text,
                Password = passwordUsersEntry.Text,
                TypeAccount = "Staroste"
            };
          
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Users>();
                int rowsAdded = conn.Insert(users);
                conn.Close();
                if (rowsAdded > 0)
                {
                    DisplayAlert("Udało się", "pomyślnie wstawiono", "ok");
                    loginUsersEntry.Text = string.Empty;
                    passwordUsersEntry.Text = string.Empty;
                }
                    
                else
                {
                    DisplayAlert("Błąd", "Nie wstawiono danych", "ok");
                }
            }
        }

        private void CreateLecturer_Clicked(object sender, EventArgs e)
        {
            int _currentID = 0; 
            Users users = new Users()
            {
                Login = loginLecturerEntry.Text,
                Password = passwordLecturerEntry.Text,
                TypeAccount = "Lecturer"
            };
            Lecturers lecturers = new Lecturers()
            {
                IdUser = _currentID,
                AcademicTitle = (string)pickerAcademicTitle.SelectedItem,
                Name = nameLecturerEntry.Text
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Users>();
                conn.CreateTable<Lecturers>();
                int rowsAdded = conn.Insert(users);
                _currentID = conn.Table<Users>().Max(x => x.IdUser);
                int rowsAdded2 = conn.Insert(lecturers);
                conn.Close();
                if (rowsAdded > 0)
                {
                    DisplayAlert("Udało się", "pomyślnie wstawiono", "ok");
                    pickerAcademicTitle.SelectedIndex = -1;
                    nameLecturerEntry.Text = string.Empty;
                    loginLecturerEntry.Text = string.Empty;
                    passwordLecturerEntry.Text = string.Empty;
                }
                    
                else
                {
                    DisplayAlert("Błąd", "Nie wstawiono danych", "ok");
                }
            }
        }
            private void CreateAdmin_Clicked(object sender, EventArgs e)
        {
            Users users = new Users()
            {
                Login = loginAdminEntry.Text,
                Password = passwordAdminEntry.Text,
                TypeAccount = "Admin"
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Users>();
                int rowsAdded = conn.Insert(users);
                conn.Close();
                if (rowsAdded > 0)
                {
                    DisplayAlert("Udało się", "pomyślnie wstawiono", "ok");
                    loginAdminEntry.Text = string.Empty;
                    passwordAdminEntry.Text = string.Empty;

                }

                else
                {
                    DisplayAlert("Błąd", "Nie wstawiono danych", "ok");
                }
            }
        }

        private void selectedGroupForStaroste(object sender, EventArgs e)
        {

        }
    }
}