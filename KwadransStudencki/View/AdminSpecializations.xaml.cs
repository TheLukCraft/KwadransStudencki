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
                if (rowsAdded > 0)
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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                var listOfSpecializations = conn.Query<Specialization>("SELECT NameOfSpecialization FROM Specialization").ToList();
                if (listOfSpecializations != null)
                {
                    pickGroupsForStaroste.ItemsSource = listOfSpecializations;
                }
                var listOfStaroste = conn.Query<Users>("SELECT Login FROM Users WHERE TypeAccount =='Staroste'").ToList();
                if (listOfStaroste != null)
                {
                    pickStaroste.ItemsSource = listOfStaroste;
                }
            }
        }
        void SelectedIndex(object sender, System.EventArgs e)
        {
            var selectedStaroste = pickStaroste.Items[pickStaroste.SelectedIndex];
            var selectedGroup = pickGroupsForStaroste.Items[pickGroupsForStaroste.SelectedIndex];
        }

        private void AssignStaroteToGroup_Clicked(object sender, EventArgs e)
        {
            StarosteAndGroup starosteAndGroup = new StarosteAndGroup()
            {
                Staroste = pickStaroste.Items[pickStaroste.SelectedIndex],
                Group = pickGroupsForStaroste.Items[pickGroupsForStaroste.SelectedIndex]
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<StarosteAndGroup>();
                int rowsAdded = conn.Insert(starosteAndGroup);
                conn.Close();
                if (rowsAdded > 0)
                {
                    DisplayAlert("Udało się", "pomyślnie wstawiono", "ok");
                    pickStaroste.SelectedIndex = -1;
                    pickGroupsForStaroste.SelectedIndex = -1;
                }

                else
                {
                    DisplayAlert("Błąd", "Nie wstawiono danych", "ok");
                }
            }
        }
    }
}