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
    public partial class LecturerLate : ContentPage
    {
        public LecturerLate()
        {
            InitializeComponent();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                var listOfUsers = conn.Table<Specialization>().Select(x => x.NameOfSpecialization).ToList();
                pickerLate.ItemsSource = listOfUsers;

            }
             
        }
        private void LecturerLate_Clicled(object sender, EventArgs e)
        {
            News news = new News()
            {
                DateOfNews = DateTime.Now.ToString(),
                Specialization = pickerLate.SelectedItem.ToString(),
                Semestr = "VII",
                Mode = "Dzienne",
                Content = contentEntry.Text,
                DateWhen = DateTime.Now.ToString(),
                Delay = timerEntry.Text
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<News>();
                int rowsAdded = conn.Insert(news);
                conn.Close();
                if (rowsAdded > 0)
                {
                    DisplayAlert("Udało się", "pomyślnie wstawiono", "ok");
                    Navigation.PushAsync(new Home());
                }
                else
                {
                    DisplayAlert("Błąd", "Nie wstawiono danych", "ok");
                }
            }
        }
    }
}