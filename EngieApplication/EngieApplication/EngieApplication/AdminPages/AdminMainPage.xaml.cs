using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EngieApplication.AdminPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminMainPage : TabbedPage
    {
        public AdminMainPage()
        {
            InitializeComponent();
        }

        async void UpdateAccount(object sender, EventArgs args)
        {
            Person worker = (Person)Application.Current.Properties["LoggedIn"];
            await Navigation.PushAsync(new ViewAccount(worker));
        }

        async void DeleteAccount(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new WorkerPages.DeleteAccount());
        }
    }
}