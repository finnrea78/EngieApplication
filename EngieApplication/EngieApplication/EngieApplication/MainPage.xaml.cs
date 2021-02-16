using EngieApplication.Services;
using EngieApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EngieApplication
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var page = new PageService();
            BindingContext = new LoginViewModel(page);
        }

        
        async void Admin_btn(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AdminPages.AdminMainPage());
        }

        async void Create_btn(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CreateAccount());
        }


    }
}
