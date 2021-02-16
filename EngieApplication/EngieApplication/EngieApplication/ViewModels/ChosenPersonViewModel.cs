using EngieApplication.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace EngieApplication.ViewModels
{
    class ChosenPersonViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// 
        /// Creator: Finn Rea
        /// Modifications: Denis Kostin
        /// 
        /// This is binded to ViewAccount in admin pages. Once the account is selected and passed in 
        /// This view model splits all infomation of the user, allowing for the user to update account infomation 
        /// for everything but ID that remain the same
        /// 
        /// </summary>



        Person person;
        string name;
        string email;
        int iD;
        string phone;
        string company;
        bool admin;

        public event PropertyChangedEventHandler PropertyChanged;
        IPageService pageService;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            UpdateCommand = new Command(async () => await UpdateAccountAsync());

        }

        public ChosenPersonViewModel(Person inPerson, PageService inPageService)
        {
            person = inPerson;
            name = person.Name;
            email = person.Email;
            iD = person.PersonId;
            phone = person.PhoneNumber;
            company = person.Company;
            admin = person.Admin;
            pageService = inPageService;

        }


        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }

        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged();
            }

        }
        public int ID
        {
            get
            {
                return iD;
            }
            
        }
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                OnPropertyChanged();
            }

        }
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
                OnPropertyChanged();
            }

        }

        public bool Admin
        {
            get
            {
                return admin;
            }
            set
            {
                admin = value;
                OnPropertyChanged();
            }
        }



        // Improvement to be made if more time would be to allow for them to be able to change password


        public Command UpdateCommand { get; set;  }

        async System.Threading.Tasks.Task UpdateAccountAsync()
        {
            FireBaseHelper fireBaseHelper = new FireBaseHelper();
            // Must pass in salt and password otherwise update wont include and wont be able to login with account
            await fireBaseHelper.UpdatePerson(iD, name, email, phone, company, person.Password, person.Salt, person.Admin);
            await pageService.DisplayAlert("Success", "Updated Person Successfully", "Ok");

        }



    }
}
