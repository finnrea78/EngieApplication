using EngieApplication.Services;
using EngieApplication.ViewModels;
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
    public partial class ViewAccount : ContentPage
    {
        Person person;
        public ViewAccount(Person inperson)
        {
            person = inperson;
            var page = new PageService();
            BindingContext = new ChosenPersonViewModel(inperson, page);
            
            InitializeComponent();

            
        }

        async void DeleteAccount(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new WorkerPages.DeleteAccount());
        }

    }
}