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
    public partial class AdminSpecializations : ContentPage
    {
        public AdminSpecializations()
        {
            InitializeComponent();
        }

        private void CreateGroup_Clicked(object sender, EventArgs e)
        {
            string completeSpecialization = createSpecialization.Text.ToString() + " " +
                pickYear.Items[pickYear.SelectedIndex] + " " + pickMode.Items[pickMode.SelectedIndex];
            Specialization specialization = new Specialization()
            {
                NameOfSpecialization = completeSpecialization
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Specialization>();
                int rowsAdded = conn.Insert(specialization);
                conn.Close();
                if(rowsAdded > 0)
                {
                    DisplayAlert("Udało się", "pomyślnie wstawiono", "ok");
                    createSpecialization.Text = string.Empty;
                    pickMode.SelectedIndex = -1;
                    pickYear.SelectedIndex = -1;
                }
                else
                {
                    DisplayAlert("Błąd", "Nie wstawiono danych", "ok");
                }
            }
        }

        //private void AddLecturerToGrup_Clicked(object sender, EventArgs e)
        //{

        //}
    }
}