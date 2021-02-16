using EngieApplication.Services;
using EngieApplication.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Net.Mail;
using System.Net;
using Xamarin.Forms.Xaml;

namespace EngieApplication.WorkerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contact : ContentPage
    {
        PageService pageService = new PageService();
        public Contact()
        {
            InitializeComponent();
            BindingContext = new ViewModels.SendEmailViewModel();
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

        async void Help(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Help());
        }

    }
}