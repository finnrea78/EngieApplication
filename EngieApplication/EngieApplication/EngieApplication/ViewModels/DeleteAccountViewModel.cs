using EngieApplication.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EngieApplication.ViewModels
{
    class DeleteAccountViewModel
    {


        /// <summary>
        /// Creator: Kacper Stawski
        /// 
        /// This is view model for deleting account by normal user.
        /// It is binded to DeleteAccount.xaml.
        /// It uses ID of a currently user that is logged in the session 
        /// and deletes this user's account. After that user is redirected
        /// to the main page.
        /// 
        /// </summary>




        IPageService pageService;

        Person worker = (Person)Application.Current.Properties["LoggedIn"];

        int personID;
        

        public DeleteAccountViewModel(IPageService inpageService)
        {
            personID = worker.PersonId;
            pageService = inpageService;
            RemoveAccountCommand = new Command(async () => await RemoveAccountAsync());
        }
        public Command RemoveAccountCommand { get; }
        public async Task RemoveAccountAsync()
        {
            FireBaseHelper fireBaseHelper = new FireBaseHelper();
            try
            {
                await fireBaseHelper.DeletePerson(personID);
                await pageService.DisplayAlert("Success", "Deleted user successfully", "OK");
                await pageService.PushAsync(new MainPage());
            }

            catch (Exception ex)
            {
                await pageService.DisplayAlert("Unsuccessful", "Could not find user, please check the ID again", "OK");
            }

        }
    }
}
