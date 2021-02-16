using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EngieApplication.Services
{
    interface IPageService
    {


        Task PushAsync(Page page);
        Task<Page> PopAsync();
        Task<bool> DisplayAlert(string Title, string message, string ok, string cancel);
        Task DisplayAlert(string title, string message, string ok);
    }
}
