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
    public partial class DeleteDB : ContentPage
    {
        public DeleteDB()
        {
            InitializeComponent();
        }
        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                int degreesDelete = conn.DropTable<Degrees>();
                int lecturersDelete = conn.DropTable<Lecturers>();
                int messageDelete = conn.DropTable<Message>();
                int modeDelete = conn.DropTable<Mode>();
                int newsDelete = conn.DropTable<News>();
                int usersDelete = conn.DropTable<Users>();
                conn.CreateTable<Degrees>();
                conn.CreateTable<Lecturers>();
                conn.CreateTable<Users>();
                //conn.CreateTable<Message>();
                conn.CreateTable<Mode>();
                conn.CreateTable<News>();
                //conn.CreateTable<Specialization>();
                //conn.CreateTable<Staroste>();
                conn.Close();
                if (newsDelete < 1)
                    DisplayAlert("Udało się", "pomyślnie usunięto", "ok");
                else
                {
                    DisplayAlert("Błąd", "Nie usunięto tabel", "ok");
                }
            }
        }
    }
}