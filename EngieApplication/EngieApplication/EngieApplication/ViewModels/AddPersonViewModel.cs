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
    class AddPersonViewModel : INotifyPropertyChanged
    {




        /// <summary>
        ///  Creator: Finn Rea
        ///  Modifications: Denis Kostin
        ///  
        ///  This is view model that is linked to CreateAccount view and AddAccount view.
        ///  It verifies that all user infomation is correct and in the correct format.
        ///  This then hashes passwords and adds the account to the database.
        ///  
        /// </summary>

        IPageService pageService;
        public AddPersonViewModel(IPageService inpageService)
        {
            pageService = inpageService;
            AddAccountCommand = new Command(async ()=> await AddAccountAsync());
        }


        // All variable and account info needs to ensure it is in the correct format and has input 
        // Second boolean to check if the string is null or and empty string after input

        bool isValidEmail = false;
        bool emailHadInput = false;
        Regex emailRegex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$");
        string email = "";


        bool isValidPassword = false;
        bool passHadInput = false;
        Regex passRegEx = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
        string password = "";


        bool isValidPhone = false;
        bool phoneHadInput = false;
        Regex phoneRegex = new Regex(@"^\(?([0-9]{2})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{6})$");
        string phonenumber = "";



        bool isValidName = false;
        bool nameHadInput = false;
        string name = "";


        string personId;
        bool isValidID = false;
        bool iDHadInput = false;


        string company = "";
        bool isValidCompany = false;
        bool companyHadInput = false;


        string salt = "";

        bool admin = false;


        FireBaseHelper fireBaseHelper = new FireBaseHelper();



        // This is to check if the binded value has change it re-updates values. 

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public string PersonId
        {
            get
            {
                return personId;
            }
            set
            {
                personId = value;
                if (personId != "")
                {
                    iDHadInput = true;
                    isValidID = true;
                }
                else
                {
                    isValidID = false;
                }



                OnPropertyChanged();
                OnPropertyChanged(nameof(IsIDValid));
            }
        }

        public string IsIDValid
        {
            get
            {
                if (iDHadInput && !isValidID)
                {
                    return "You need to input a ID";
                }
                else
                {
                    return "";
                }
            }
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
                if(name != "")
                {
                    nameHadInput = true;
                    isValidName = true;
                }
                else
                {
                    isValidName = false;
                }



                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNameValid));
            }
        }
        public string IsNameValid
        {
            get
            {
                if (nameHadInput && !isValidName)
                {
                    return "You need to input a name";
                }
                else
                {
                    return "";
                }
            }
        }




        public string PhoneNumber
        {
            get
            {
                return phonenumber;
            }
            set
            {
                phonenumber = value;
                if (phonenumber != "")
                {
                    phoneHadInput = true;
                }
               
                if (phoneRegex.IsMatch(phonenumber))
                {
                    isValidPhone = true;
                }
                else
                {
                    isValidPhone = false;
                }


                OnPropertyChanged();
                OnPropertyChanged(nameof(IsPhoneValid));
            }
        }
        public string IsPhoneValid
        {
            get
            {
                if (phoneHadInput)
                {
                    if (isValidPhone)
                    {
                        return "";
                    }
                    else
                    {
                        return "Phone input is required in format xx-xxx-xxxxxx or 11 digits";
                    }
                }
                else
                {
                    return "";
                }
            }
            set
            {

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
                if (password != "")
                {
                    passHadInput = true;
                }
                if (passRegEx.IsMatch(password))
                {
                    isValidPassword = true;
                }


                OnPropertyChanged();
                OnPropertyChanged(nameof(IsPasswordValid));

            }
        }

        public string IsPasswordValid
        {
            get
            {
                if (passHadInput)
                {
                    if (isValidPassword)
                    {
                        return "";
                    }
                    else
                    {
                        return "Password requires 8 letter 1 number, special character, lower and uppercase letter";
                    }
                }
                else
                {
                    return "";
                }
            }
            set
            {

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
                if (company != "")
                {
                    companyHadInput = true;
                    isValidCompany = true;
                }
                else
                {
                    isValidCompany = false;
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsCompanyValid));

            }
        }

        public string IsCompanyValid
        {
            get
            {
                if (companyHadInput && !isValidCompany)
                {
                    return "You need to input a Company";
                }
                else
                {
                    return "";
                }
            }
        }


        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                if (email != "")
                {
                    emailHadInput = true;
                }
                if (emailRegex.IsMatch(Email))
                {
                    isValidEmail = true;
                }
                else
                {
                    isValidEmail = false;
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsEmailValid));

            }
        }
        public string IsEmailValid
        {
            get
            {
                if (emailHadInput)
                {
                    if (isValidEmail)
                    {
                        return "";
                    }
                    else
                    {
                        return "Email is incorrect format";
                    }
                }
                else
                {
                    return "";
                }
            }
            set { }
        }

        public bool Admin
        {
            get
            {
                return admin;
            }
            set
            {
                if (admin != value)
                {
                    admin = value;
                    OnPropertyChanged();
                }
            }
        }


        public Command AddAccountCommand { get; }

        async System.Threading.Tasks.Task AddAccountAsync()
        {
            
            try
            {
                if (isValidEmail && isValidPassword && isValidPhone && isValidName && isValidCompany && isValidID)
                {

                    // ensure unique email and ID (Could possible use email)
                    Person People = await fireBaseHelper.GetPersonEmail(email);
                    if (People == null)
                    {
                        People = await fireBaseHelper.GetPersonID(Int32.Parse(personId));
                        if (People == null)
                        {
                            salt = GenerateSalt();
                            await fireBaseHelper.AddPerson(Convert.ToInt32(personId), name, email, phonenumber, HashPass(password, salt), salt, company, admin);
                            await pageService.DisplayAlert("Success", "Person Added Successfully", "OK");
                            await pageService.PopAsync();
                        }
                        else
                        {
                            await pageService.DisplayAlert("UnSuccessful", "This ID already exists", "ok");
                        }
                    }
                    else
                    {
                        await pageService.DisplayAlert("UnSuccessful", "This Email already exists", "ok");
                    }
                }
                else
                {
                    await pageService.DisplayAlert("Failed", "Unable to add account check fields aren't missing or incorrect format", "OK");
                }
            }
            catch
            {

            }
        }


        public string HashPass(string pwd, string salt)
        {

            // Uses salt, first mixing it with the password then hashing the password.

            byte[] pwdBytes = Encoding.UTF8.GetBytes(pwd);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[pwdBytes.Length + saltBytes.Length];

            for (int i = 0; i < pwdBytes.Length; i++)
            {
                plainTextWithSaltBytes[i] = pwdBytes[i];
            }
            for (int i = 0; i < saltBytes.Length; i++)
            {
                plainTextWithSaltBytes[pwdBytes.Length + i] = saltBytes[i];
            }

            return Convert.ToBase64String(algorithm.ComputeHash(plainTextWithSaltBytes));

        }
        public string GenerateSalt()
        {


            // Generates a random 32 byte salt.
            var random = new RNGCryptoServiceProvider();
            byte[] salt = new byte[32];
            random.GetNonZeroBytes(salt);
            return Convert.ToBase64String(salt);
        }








        private Task DisplayAlert(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
    }
}
