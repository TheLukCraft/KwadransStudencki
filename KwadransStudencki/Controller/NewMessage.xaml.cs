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
                var listOfLecturers = conn.Query<StarosteAndGroup>("SELECT Staroste FROM StarosteAndGroup").ToList();
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
           
        }
    }
}