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
    public partial class AdminCommunication : ContentPage
    {
        public AdminCommunication()
        {
            InitializeComponent();
        }

        private void saveButtonNews_Clicked(object sender, EventArgs e)
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
        private void LecturerTransferred_Clicled(object sender, EventArgs e)
        {

        }
    }
}