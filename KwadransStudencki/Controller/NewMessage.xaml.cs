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
                //var listOfLecturers = conn.Table<Users>().Where(u => u.TypeAccount == "Lecturer").ToList();
                var listOfLecturers = conn.Query<Users>("SELECT IdUser,Login, TypeAccount FROM Users WHERE TypeAccount=='Lecturer'").ToList();
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
    }
}