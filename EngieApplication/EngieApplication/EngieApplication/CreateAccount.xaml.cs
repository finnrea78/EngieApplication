using EngieApplication.Services;
using EngieApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EngieApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccount : ContentPage
    {
        
        public CreateAccount()
        {
            InitializeComponent();
            var page = new PageService();
            BindingContext = new AddPersonViewModel(page);
        }

        async void Return_btn(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }




    }
}