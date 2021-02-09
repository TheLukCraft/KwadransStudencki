using KwadransStudencki.Model;
using KwadransStudencki.View;
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
    public partial class Messages : ContentPage
    {
        public Messages()
        {
            InitializeComponent();

        }
        private void NewMsgButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewMessage());
        }
        async private void replyMessageButton(object sender, System.EventArgs e)
        {
            var asc = (ImageButton)sender;
            bool das = await DisplayAlert("Odpowiedzieć na wiadomość?", "Czy chcesz odpowiedzieć na tą wiadomość?", "Tak", "Nie");
            if (das == true)
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                { 
                    conn.Query<Message>("SELECT FROM Message WHERE IdMessages == " + (int)asc.CommandParameter);
                }
                Navigation.PushAsync(new NewMessage());
            }
            else
            {
                OnAppearing();
            }
            

        }
        async private void DeleteMessage_Clicked(object sender, System.EventArgs e)
        {
            var asc = (ImageButton)sender;
            bool das = await DisplayAlert("Usunąć wiadomość?", "Czy chcesz usunąć tą wiadomość?", "Tak", "Nie");
            if(das == true)
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    //var deleteMessage = conn.Table<Message>().Where(x => (int)asc.CommandParameter == x.IdMessages);
                    conn.Query<Message>("DELETE FROM Message WHERE IdMessages == " + (int)asc.CommandParameter);
                }
                OnAppearing();
            }
            else
            {
                OnAppearing();
            }
            
        }
        void OnImageNameTapped(object sender, EventArgs args)
        {
            DisplayAlert("Alert", "You have been alerted", "OK");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Message>();
                var news = conn.Table<Message>().ToList();

                messagesView.ItemsSource = news;
            }
        }
    }
}