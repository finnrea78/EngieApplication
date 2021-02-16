using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EngieApplication.Services
{
    public class PageService: IPageService
    {



        /// <summary>
        /// Creator: Finn Rea
        /// 
        /// This is the creation of a page service so view models don't directly referance the Main page 
        /// It also reduce repeated code Application.Navigation.xxxx
        /// 
        /// 
        /// 
        /// </summary>
  
        public async Task<bool> DisplayAlert(string Title,string message, string ok, string cancel)
        {
            return await MainPage.DisplayAlert(Title, message, ok, cancel);
        }

        public async Task DisplayAlert(string title, string message, string ok)
        {
            await MainPage.DisplayAlert(title, message, ok);
        }

        public async Task<Page> PopAsync()
        {
            return await MainPage.Navigation.PopAsync();
        }

        public async Task PushAsync(Page page)
        {
            await MainPage.Navigation.PushAsync(page);
        }

        private Page MainPage
        {
            get { return Application.Current.MainPage; }
        }
    }
}
