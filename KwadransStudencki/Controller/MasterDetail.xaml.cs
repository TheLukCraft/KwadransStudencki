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
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            InitializeComponent();
            //IsVisibleInsertDBButton.IsVisible = Application.Current.Properties.ContainsKey("UserType") && Application.Current.Properties["UserType"] == "Staroste";
        }
        void HomeButton(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new Home());
            IsPresented = false;
        }
        void ReportButton(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new LecturerReport());
            IsPresented = false;
        }

        void MessageButton(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new Messages());
            IsPresented = false;
        }
        void LoginButton(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new Login());
            IsPresented = false;
        }
        void AdminPanelButton(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new AdminPanel());
            IsPresented = false;
        }
        void DeleteDBButton(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new DeleteDB());
            IsPresented = false;
        }
        Login loginObj = new Login();
        //bool isLogged = loginObj.IsLogged();
        //if( == true)
        //    {

        //    }|
    }
}