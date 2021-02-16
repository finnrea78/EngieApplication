using EngieApplication.Services;
using EngieApplication.ViewModels;
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
    public partial class AddGasAsset : ContentPage
    {
        public AddGasAsset()
        {
            InitializeComponent();
            var page = new PageService();
            BindingContext = new AddGasViewModel(page);
        }

        async void UpdateAccount(object sender, EventArgs args)
        {

            // Passes in refreshed user details

            FireBaseHelper fireBaseHelper = new FireBaseHelper();
            Person worker = (Person)Application.Current.Properties["LoggedIn"];
            Person workerUpdate = await fireBaseHelper.GetPersonID(worker.PersonId);
            await Navigation.PushAsync(new AdminPages.ViewAccount(workerUpdate));
        }

        async void DeleteAccount(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new DeleteAccount());
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