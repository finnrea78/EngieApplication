using EngieApplication.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EngieApplication.ViewModels
{
    class LoginViewModel: INotifyPropertyChanged
    {
        /// <summary>
        /// Creator: Finn Rea
        /// Modifications: Denis Kostin
        /// 
        /// This viewModel is binded to MainPage view.
        /// It allows for the user to input credentials, checking them against the database to see if the user exists
        /// If login infomation is correct then it'll navigate to admin pages or worker pages depending on the user's status.
        /// 
        /// </summary>

        private IPageService pageService; 

        public LoginViewModel(IPageService inpageService)
        {
            LoginCommand = new Command(async () => await Login());
            pageService = inpageService;
        }

        public Command LoginCommand { get; }


        string email = "";
        string password = "";
        bool admin = false;
        FireBaseHelper fireBaseHelper = new FireBaseHelper();
        static PageService page = new PageService();
        AddPersonViewModel hashMethod = new AddPersonViewModel(inpageService: page);



        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
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


        public async Task Login()
        {

    
        
            //null or empty field validation, check weather email and password is null or empty    

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                //call GetUser function which we define in Firebase helper class 

                var user = await fireBaseHelper.GetPersonEmail(Email);
                
                //firebase return null valuse if user data not found in database    
                if (user != null)
                    if (email == user.Email && hashMethod.HashPass(password, user.Salt) == user.Password) 
                    {
                        // Sets session logged in worker
                        Application.Current.Properties["LoggedIn"] = user;


                        // once logged in removes logged in infomation from entrys 
                        email = "";
                        password = "";
                        OnPropertyChanged(Email);
                        OnPropertyChanged(Password);


                        if(user.Admin == true) {
                            //Navigate to Wellcom page after successfuly login    
                            //pass user email to welcom page

                            await pageService.DisplayAlert("Success", "Admin Logged in", "Ok");
                            await pageService.PushAsync(new AdminPages.AdminMainPage());
                        }
                        else
                        {
                            await pageService.DisplayAlert("Login success", "", "OK");

                            await pageService.PushAsync(new WorkerPages.WorkerMainPage());
                            //await App.Current.MainPage.Navigation.PushAsync(new WorkerPages.WorkerMainPage()); -- Old method of page navigation does not adher to MVVM model

                        }




                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
                else
                    await App.Current.MainPage.DisplayAlert("Login Fail", "User not found", "OK");
            }
        }


    
      
    }
}
