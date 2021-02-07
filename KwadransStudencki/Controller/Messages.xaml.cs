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
        private void replyMessageButton(object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new NewMessege());
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