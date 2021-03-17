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
    public partial class NewMessage : ContentPage
    {
        public NewMessage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                //var listOfLecturers = conn.Table<Users>().Where(u => u.Account == "Lecturer").ToList();
                var listOfLecturers = conn.Query<StarosteAndGroup>("SELECT * FROM StarosteAndGroup").ToList();
                if (listOfLecturers != null)
                {
                    pickerOfLecturers.ItemsSource = listOfLecturers;
                }
            }
        }
        void SelectedIndex(object sender, System.EventArgs e)
        {
            var selected = pickerOfLecturers.Items[pickerOfLecturers.SelectedIndex];
        }
        private void NewMessage_Clicled(object sender, EventArgs e)
        {
            Message message = new Message()
            {
                Time = DateTime.UtcNow.Date.ToString(),
                ID_Sender = (string)Application.Current.Properties["IDSession"],
                ID_Reciever = pickerOfLecturers.Items[pickerOfLecturers.SelectedIndex],
                Title = titleMessageEntry.Text,
                Content = ContentMessageEntry.Text
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Message>();
                int rowsAdded = conn.Insert(message);
                conn.Close();
                if (rowsAdded > 0)
                {
                    DisplayAlert("Udało się", "pomyślnie wstawiono", "ok");
                    Navigation.PushAsync(new Messages());
                }
                    
                else
                {
                    DisplayAlert("Błąd", "Nie wstawiono danych", "ok");
                }
            }
        }
    }
}