using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EngieApplication.WorkerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Help : ContentPage
    {
        public Help()
        {
            InitializeComponent();
        }

        async void Contact(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Contact());
        }

        async void UpdateAccount(object sender, EventArgs args)
        {
            Person worker = (Person)Application.Current.Properties["LoggedIn"];
            await Navigation.PushAsync(new AdminPages.ViewAccount(worker));
        }

        async void DeleteAccount(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new DeleteAccount());
        }
    }
}