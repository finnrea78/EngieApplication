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
    public partial class DeleteAccount : ContentPage
    {
        public DeleteAccount()
        {
            InitializeComponent();
            var page = new Services.PageService();
            BindingContext = new ViewModels.DeleteAccountViewModel(page);
        }

        async void UpdateAccount(object sender, EventArgs args)
        {
            Person worker = (Person)Application.Current.Properties["LoggedIn"];
            await Navigation.PushAsync(new AdminPages.ViewAccount(worker));
        }

        async void Contact(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Contact());
        }

        async void Help(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Help());
        }
    }
}