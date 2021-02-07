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
    public partial class InsertDB : ContentPage
    {
        public InsertDB()
        {
            InitializeComponent();
            UserControl userControl = new UserControl();

            typeOfUser.Text = (string)Application.Current.Properties["UserType"];
            //isUserActive.Text = userControl.GetIsUser().ToString();

            IDLabel.Text = (string)Application.Current.Properties["IDSession"];
            loginUser.Text = (string)Application.Current.Properties["LoginSession"];
            passwordUser.Text = (string)Application.Current.Properties["PasswordSession"];
        }
        private void ShowResults_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ViewData());
        }
        private void SaveButton_Clicked(object sender, EventArgs e)
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
                    DisplayAlert("Udało się", "pomyślnie wstawiono", "ok");
                else
                {
                    DisplayAlert("Błąd", "Nie wstawiono danych", "ok");
                }
            }
        }
        private void saveButtonAdmin_Clicked(object sender, EventArgs e)
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
                    DisplayAlert("Udało się", "pomyślnie wstawiono", "ok");
                else
                {
                    DisplayAlert("Błąd", "Nie wstawiono danych", "ok");
                }
            }
        }

        private void saveButtonLecturer_Clicked(object sender, EventArgs e)
        {
            Users users = new Users()
            {
                Login = loginLecturerEntry.Text,
                Password = passwordLecturerEntry.Text,
                TypeAccount = "Lecturer"
            };
            Lecturers lecturers = new Lecturers()
            {
                IdUser = users.IdUser,
                AcademicTitle = academicTitleLecturerEntry.Text,
                Name = nameLecturerEntry.Text
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Users>();
                conn.CreateTable<Lecturers>();
                int rowsAdded = conn.Insert(users);
                int rowsAdded2 = conn.Insert(lecturers);
                conn.Close();
                if (rowsAdded > 0)
                    DisplayAlert("Udało się", "pomyślnie wstawiono", "ok");
                else
                {
                    DisplayAlert("Błąd", "Nie wstawiono danych", "ok");
                }
            }
        }
        private void saveButtonNews_Clicked(object sender, EventArgs e)
        {
            News news = new News()
            {
                DateOfNews = newsOfDateNewsEntry.Text,
                Specialization = newsSpecializationEntry.Text,
                Semestr = newsSemestrEntry.Text,
                Mode = newsModeEntry.Text,
                Content = newsContentEntry.Text,
                DateWhen = newsDateWhenEntry.Text,
                Delay = newsDelayEntry.Text
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<News>();
                int rowsAdded = conn.Insert(news);
                conn.Close();
                if (rowsAdded > 0)
                    DisplayAlert("Udało się", "pomyślnie wstawiono", "ok");
                else
                {
                    DisplayAlert("Błąd", "Nie wstawiono danych", "ok");
                }
            }
        }
        private void SaveButtonMesseges_Clicked(object sender, EventArgs e)
        {
            Message message = new Message()
            {
                Time = DateTime.UtcNow.Date.ToString(),
                ID_Sender = ID_SenderMessegesEntry.Text,
                ID_Reciever = ID_RecieverMessegesEntry.Text,
                Title = titleMessegesEntry.Text,
                Content = contentMessegesEntry.Text
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Message>();
                int rowsAdded = conn.Insert(message);
                conn.Close();
                if (rowsAdded > 0)
                    DisplayAlert("Udało się", "pomyślnie wstawiono", "ok");
                else
                {
                    DisplayAlert("Błąd", "Nie wstawiono danych", "ok");
                }
            }
        }
    }
}