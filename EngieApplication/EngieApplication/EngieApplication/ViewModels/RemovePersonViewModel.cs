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
    class RemovePersonViewModel : INotifyPropertyChanged

    /// <summary>
    /// Creator: Denis Kostin
    /// 
    /// This view model is binded to RemoveAccount in AdminPages
    /// It retrieves the inputted user ID and then calls the DeletePerson
    /// method to remove the targeted user from the database
    /// 
    /// 
    /// </summary>
    {
        IPageService pageService;

        string personID;

        FireBaseHelper fireBaseHelper = new FireBaseHelper();

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public RemovePersonViewModel(IPageService inpageService)
        {
            pageService = inpageService;
            RemoveAccountCommand = new Command(async () => await RemoveAccountAsync());
        }


        public string PersonID
        {
            get
            {
                return personID;

            }
            set
            {
                personID = value;
                OnPropertyChanged();
            }
        }

        public Command RemoveAccountCommand { get; }

        public async Task RemoveAccountAsync()
        {
            FireBaseHelper fireBaseHelper = new FireBaseHelper();
            try
            {
                var user = await fireBaseHelper.GetPersonID(Int32.Parse(PersonID));
                await fireBaseHelper.DeletePerson(Int32.Parse(personID));
                await pageService.DisplayAlert("Success", "Deleted user successfully", "OK");

            }
            catch (Exception ex)
            {
                //await pageService.PushAsync(new AdminPages.RemoveAccount());
                await pageService.DisplayAlert("Unsuccessful", "Could not find user, please check the ID again", "OK");
            }
            
        }
    }
}
