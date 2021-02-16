using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngieApplication.Services;
using EngieApplication.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EngieApplication.AdminPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAcount : ContentPage
    {
        public AddAcount()
        {
            InitializeComponent();
            var page = new PageService();
            BindingContext = new AddPersonViewModel(page);
        }

        async void UpdateAccount(object sender, EventArgs args)
        {
            Person worker = (Person)Application.Current.Properties["LoggedIn"];
            await Navigation.PushAsync(new AdminPages.ViewAccount(worker));
        }

        async void DeleteAccount(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new WorkerPages.DeleteAccount());
        }

        async void Contact(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new WorkerPages.Contact());
        }

        async void Help(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new WorkerPages.Help());
        }

    }
}