using EngieApplication.FirebaseInteraction;
using EngieApplication.Models;
using EngieApplication.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EngieApplication.ViewModels
{
    class LightingViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Creator: Kacper Stawski
        /// 
        /// This is the view model for adding a new Lighting asset.
        /// It is binded to AddLightingAsset.xaml. 
        /// All fields that user inputs are validated here and passed to database.
        /// 
        /// 
        /// </summary>




        public event PropertyChangedEventHandler PropertyChanged;
        LightingFirebaseHelper assetFireBase = new LightingFirebaseHelper();
        Person worker = (Person)Application.Current.Properties["LoggedIn"];
        DateTime dateTime = DateTime.Today;


        // Only ones that require yes/no/NA/unknown and input validation

        string q11;
        bool q11Valid;
        string q12;
        bool q12Valid;
        string q13;
        bool q13Valid;
        string q14;
        bool q14Valid;
        string q15;
        bool q15Valid;
        string q16;
        bool q16Valid;

        string q21;
        bool q21Valid;
        string q22;
        bool q22Valid;
        string q23;
        bool q23Valid;
        string q24;
        bool q24Valid;
        string q25;
        bool q25Valid;
        string q26;
        bool q26Valid;
        string q27;
        bool q27Valid;

        string q31;
        bool q31Valid;
        string q32;
        bool q32Valid;
        string q33;
        bool q33Valid;
        string q34;
        bool q34Valid;

        string q41;
        bool q41Valid;
        string q42;
        bool q42Valid;
        string q43;
        bool q43Valid;
        string q44;
        bool q44Valid;
        string q45;
        bool q45Valid;

        string q51;
        bool q51Valid;

        string q61;
        bool q61Valid;
        string q62;
        bool q62Valid;
        string q63;
        bool q63Valid;
        string q64;
        bool q64Valid;
        string q65;
        bool q65Valid;
        string q66;
        bool q66Valid;
        string q67;
        bool q67Valid;
        string q68;
        bool q68Valid;
        string q69;
        bool q69Valid;
        string q610;
        bool q610Valid;



        IPageService page;

        public LightingViewModel(PageService inPage)
        {
            page = inPage;
            AddAssetCommand = new Command(async () => await AddAssetAsync());
        }


        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }




        public string Name { get; set; }
        public string Adress { get; set; }
        public string Postcode { get; set; }
        public string TelNo { get; set; }
        public string JobRef { get; set; }
        public string Id { get; set; }

        public string EngineersName
        {
            get
            {
                return worker.Name;
            }
        }
        public string RPC { get; set; }
        public string OfficeAdress { get; set; }
        public string OfficePostcode { get; set; }
        public string OfficeTelNo { get; set; }

        public string ResponsiblePerson { get; set; }

        public string SystemManufacturer { get; set; }
        public string ManufacturerTelNo { get; set; }
        public string ResponsibleEngineer { get; set; }
        public string EngineersTelNo { get; set; }

        public string ComissionDate { get; set; }

        public string Nonmaintained { get; set; }
        //Non-maintained luminaires maintained signs
        public string NonmaintainedLMS { get; set; }
        public string Maintained { get; set; }
        public string Others { get; set; }

        public int Hours { get; set; }
        public bool IsAutomatic { get; set; }

        public string AddMod1 { get; set; }
        public string AddMod2 { get; set; }
        public string AddMod3 { get; set; }
        public string AddMod4 { get; set; }
        public string AddMod5 { get; set; }
        public string AddMod6 { get; set; }

        public string Signature { get; set; }
        //  Currently in US time
        public string Date
        {
            get
            {
                return dateTime.ToString();
            }
        }
        public string SiteAdress { get; set; }

        //Question 1.1
        public string Q11
        {
            get
            {
                return q11;
            }
            set
            {
                q11 = value;
                if (q11.ToLower() == "yes" || q11.ToLower() == "no")
                {
                    q11Valid = true;
                }
                else
                {
                    q11Valid = false;
                }
                OnPropertyChanged();
            }
        }

        public string Q12
        {
            get
            {
                return q12;
            }
            set
            {
                q12 = value;
                if (q12.ToLower() == "yes" || q12.ToLower() == "no" || q12.ToLower() == "unknown")
                {
                    q12Valid = true;
                }
                else
                {
                    q12Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q13
        {
            get
            {
                return q13;
            }
            set
            {
                q13 = value;
                if (q13.ToLower() == "yes" || q13.ToLower() == "no" || q13.ToLower() == "unknown")
                {
                    q13Valid = true;
                }
                else
                {
                    q13Valid = false;
                }
                OnPropertyChanged();
            }
        }

        public string Q14
        {
            get
            {
                return q14;
            }
            set
            {
                q14 = value;
                if (q14.ToLower() == "yes" || q14.ToLower() == "no" || q14.ToLower() == "unknown")
                {
                    q14Valid = true;
                }
                else
                {
                    q14Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q15
        {
            get
            {
                return q15;
            }
            set
            {
                q15 = value;
                if (q15.ToLower() == "yes" || q15.ToLower() == "no")
                {
                    q15Valid = true;
                }
                else
                {
                    q15Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q16
        {
            get
            {
                return q16;
            }
            set
            {
                q16 = value;
                if (q16.ToLower() == "yes" || q16.ToLower() == "no")
                {
                    q16Valid = true;
                }
                else
                {
                    q16Valid = false;
                }
                OnPropertyChanged();
            }
        }

        public string Q21
        {
            get
            {
                return q21;
            }
            set
            {
                q21 = value;
                if (q21.ToLower() == "yes" || q21.ToLower() == "no" || q21.ToLower() == "unknown")
                {
                    q21Valid = true;
                }
                else
                {
                    q21Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q22
        {
            get
            {
                return q22;
            }
            set
            {
                q22 = value;
                if (q22.ToLower() == "yes" || q22.ToLower() == "no" || q22.ToLower() == "na")
                {
                    q22Valid = true;
                }
                else
                {
                    q22Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q23
        {
            get
            {
                return q23;
            }
            set
            {
                q23 = value;
                if (q23.ToLower() == "yes" || q23.ToLower() == "no")
                {
                    q23Valid = true;
                }
                else
                {
                    q23Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q24
        {
            get
            {
                return q24;
            }
            set
            {
                q24 = value;
                if (q24.ToLower() == "yes" || q24.ToLower() == "no" || q24.ToLower() == "unknown")
                {
                    q24Valid = true;
                }
                else
                {
                    q24Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q25
        {
            get
            {
                return q25;
            }
            set
            {
                q25 = value;
                if (q25.ToLower() == "yes" || q25.ToLower() == "no")
                {
                    q25Valid = true;
                }
                else
                {
                    q25Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q26
        {
            get
            {
                return q26;
            }
            set
            {
                q26 = value;
                if (q26.ToLower() == "yes" || q26.ToLower() == "no")
                {
                    q26Valid = true;
                }
                else
                {
                    q26Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q27
        {
            get
            {
                return q27;
            }
            set
            {
                q27 = value;
                if (q27.ToLower() == "yes" || q27.ToLower() == "no" || q27.ToLower() == "na")
                {
                    q27Valid = true;
                }
                else
                {
                    q27Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q31
        {
            get
            {
                return q31;
            }
            set
            {
                q31 = value;
                if (q31.ToLower() == "yes" || q31.ToLower() == "no" || q31.ToLower() == "unknown")
                {
                    q31Valid = true;
                }
                else
                {
                    q31Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q32
        {
            get
            {
                return q32;
            }
            set
            {
                q32 = value;
                if (q32.ToLower() == "yes" || q32.ToLower() == "no" || q32.ToLower() == "na" || q32.ToLower() == "unknown")
                {
                    q32Valid = true;
                }
                else
                {
                    q32Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q33
        {
            get
            {
                return q33;
            }
            set
            {
                q33 = value;
                if (q33.ToLower() == "yes" || q33.ToLower() == "no" || q33.ToLower() == "na")
                {
                    q33Valid = true;
                }
                else
                {
                    q33Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q34
        {
            get
            {
                return q34;
            }
            set
            {
                q34 = value;
                if (q34.ToLower() == "yes" || q34.ToLower() == "no" || q34.ToLower() == "na" || q34.ToLower() == "unknown")
                {
                    q34Valid = true;
                }
                else
                {
                    q34Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q41
        {
            get
            {
                return q41;
            }
            set
            {
                q41 = value;
                if (q41.ToLower() == "yes" || q41.ToLower() == "no")
                {
                    q41Valid = true;
                }
                else
                {
                    q41Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q42
        {
            get
            {
                return q42;
            }
            set
            {
                q42 = value;
                if (q42.ToLower() == "yes" || q42.ToLower() == "no")
                {
                    q42Valid = true;
                }
                else
                {
                    q42Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q43
        {
            get
            {
                return q43;
            }
            set
            {
                q43 = value;
                if (q43.ToLower() == "yes" || q43.ToLower() == "no")
                {
                    q43Valid = true;
                }
                else
                {
                    q43Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q44
        {
            get
            {
                return q44;
            }
            set
            {
                q44 = value;
                if (q44.ToLower() == "yes" || q44.ToLower() == "no")
                {
                    q44Valid = true;
                }
                else
                {
                    q44Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q45
        {
            get
            {
                return q45;
            }
            set
            {
                q45 = value;
                if (q45.ToLower() == "yes" || q45.ToLower() == "no" || q45.ToLower() == "na" || q45.ToLower() == "unknown")
                {
                    q45Valid = true;
                }
                else
                {
                    q45Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q51
        {
            get
            {
                return q51;
            }
            set
            {
                q51 = value;
                if (q51.ToLower() == "yes" || q51.ToLower() == "no" || q51.ToLower() == "na" || q51.ToLower() == "unknown")
                {
                    q51Valid = true;
                }
                else
                {
                    q51Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q61
        {
            get
            {
                return q61;
            }
            set
            {
                q61 = value;
                if (q61.ToLower() == "yes" || q61.ToLower() == "no" || q61.ToLower() == "unknown")
                {
                    q61Valid = true;
                }
                else
                {
                    q61Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q62
        {
            get
            {
                return q62;
            }
            set
            {
                q62 = value;
                if (q62.ToLower() == "yes" || q62.ToLower() == "no" || q62.ToLower() == "na" || q62.ToLower() == "unknown")
                {
                    q62Valid = true;
                }
                else
                {
                    q62Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q63
        {
            get
            {
                return q63;
            }
            set
            {
                q63 = value;
                if (q63.ToLower() == "yes" || q63.ToLower() == "no")
                {
                    q63Valid = true;
                }
                else
                {
                    q63Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q64
        {
            get
            {
                return q64;
            }
            set
            {
                q64 = value;
                if (q64.ToLower() == "yes" || q64.ToLower() == "no" || q64.ToLower() == "unknown")
                {
                    q64Valid = true;
                }
                else
                {
                    q64Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q65
        {
            get
            {
                return q65;
            }
            set
            {
                q65 = value;
                if (q65.ToLower() == "yes" || q65.ToLower() == "no" || q65.ToLower() == "unknown")
                {
                    q65Valid = true;
                }
                else
                {
                    q65Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q66
        {
            get
            {
                return q66;
            }
            set
            {
                q66 = value;
                if (q66.ToLower() == "yes" || q66.ToLower() == "no" || q66.ToLower() == "unknown")
                {
                    q66Valid = true;
                }
                else
                {
                    q66Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q67
        {
            get
            {
                return q67;
            }
            set
            {
                q67 = value;
                if (q67.ToLower() == "yes" || q67.ToLower() == "no")
                {
                    q67Valid = true;
                }
                else
                {
                    q67Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q68
        {
            get
            {
                return q68;
            }
            set
            {
                q68 = value;
                if (q68.ToLower() == "yes" || q68.ToLower() == "no" || q68.ToLower() == "unknown")
                {
                    q68Valid = true;
                }
                else
                {
                    q68Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q69
        {
            get
            {
                return q69;
            }
            set
            {
                q69 = value;
                if (q69.ToLower() == "yes" || q69.ToLower() == "no")
                {
                    q69Valid = true;
                }
                else
                {
                    q69Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Q610
        {
            get
            {
                return q610;
            }
            set
            {
                q610 = value;
                if (q610.ToLower() == "yes" || q610.ToLower() == "no")
                {
                    q610Valid = true;
                }
                else
                {
                    q610Valid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Results { get; set; }
        public string Comments { get; set; }



        public Command AddAssetCommand { get; }

        async System.Threading.Tasks.Task AddAssetAsync()
        {

            // App.Current.MainPage = new WorkerPages.WorkerMainPage();

            try
            {
                // Check all fields filled out and all vaild. 
                // it they input and delete the string desn't return to null but to a empty string ""

                if ((Name != "" && Name != null) && (Adress != "" && Adress != null) && (JobRef != "" && JobRef != null)
                    && (Postcode != "" && Postcode != null) && (TelNo != "" && TelNo != null)
                    && (EngineersName != "" && EngineersName != null) && (RPC != "" && RPC != null)
                    && (OfficeAdress != "" && OfficeAdress != null) && (OfficePostcode != "" && OfficePostcode != null)
                    && (OfficeTelNo != "" && OfficeTelNo != null) && (ResponsiblePerson != "" && ResponsiblePerson != null)
                    && (SystemManufacturer != "" && SystemManufacturer != null) && (ManufacturerTelNo != "" && ManufacturerTelNo != null)
                    && (EngineersTelNo != "" && EngineersTelNo != null) && (ComissionDate != "" && ComissionDate != null)
                    && (Nonmaintained != "" && Nonmaintained != null) && (NonmaintainedLMS != "" && NonmaintainedLMS != null)
                    && (Maintained != "" && Maintained != null) && (Others != "" && Others != null)
                    && (AddMod1 != "" && AddMod2 != null)
                    && (AddMod2 != "" && AddMod2 != null) && (AddMod3 != "" && AddMod3 != null) && (AddMod4 != "" && AddMod4 != null)
                    && (AddMod5 != "" && AddMod5 != null) && (AddMod6 != "" && AddMod6 != null) && (Signature != "" && Signature != null)
                    && (Date != "" && Date != null) && (SiteAdress != "" && SiteAdress != null) && (Results != "" && Results != null)
                    && (Comments != "" && Comments != null)
                    && (q11Valid && q12Valid && q13Valid
                    && q14Valid && q15Valid && q16Valid && q21Valid && q22Valid && q23Valid && q24Valid && q25Valid && q26Valid
                    && q27Valid && q31Valid && q32Valid && q33Valid && q34Valid && q41Valid && q42Valid && q43Valid && q44Valid
                    && q45Valid && q51Valid && q61Valid && q62Valid && q63Valid && q64Valid && q65Valid && q66Valid && q67Valid
                    && q69Valid && q610Valid))
                {



                    LightingFirebaseHelper lightingFirebaseHelper = new LightingFirebaseHelper();
                    // Checks if serial Num already exists?
                    Lighting Exists = await lightingFirebaseHelper.GetAllLightingByID(Id);


                    if (Exists == null)
                    {


                        await assetFireBase.AddLightingAsset(
                            Id,
                            Name,
                            Adress,
                            Postcode,
                            TelNo,
                            Int32.Parse(JobRef),
                            EngineersName,
                            RPC,
                            OfficeAdress,
                            OfficePostcode,
                            OfficeTelNo,
                            ResponsiblePerson,
                            SystemManufacturer,
                            ManufacturerTelNo,
                            ResponsibleEngineer,
                            EngineersTelNo,
                            ComissionDate,
                            Nonmaintained,
                            NonmaintainedLMS,
                            Maintained,
                            Others,
                            Hours,
                            IsAutomatic,
                            AddMod1,
                            AddMod2,
                            AddMod3,
                            AddMod4,
                            AddMod5,
                            AddMod6,
                            Signature,
                            Date,
                            SiteAdress,
                            Q11,
                            Q12,
                            Q13,
                            Q14,
                            Q15,
                            Q16,
                            Q21,
                            Q22,
                            Q23,
                            Q24,
                            Q25,
                            Q26,
                            Q27,
                            Q31,
                            Q32,
                            Q33,
                            Q34,
                            Q41,
                            Q42,
                            Q43,
                            Q44,
                            Q45,
                            Q51,
                            Q61,
                            Q62,
                            Q63,
                            Q64,
                            Q65,
                            Q66,
                            Q67,
                            Q68,
                            Q69,
                            Q610,
                            Results,
                            Comments);

                        await page.DisplayAlert("Added succesfully", "Success", "Ok");
                        await page.PopAsync();
                    }
                    else
                    {
                        await page.DisplayAlert("Exists", "That serial number already exists", "Ok");
                    }

                }
                else
                {
                    await page.DisplayAlert("Error", "Unable to add asset or fields missing", "Ok");
                }
            }
            catch
            {
                await page.DisplayAlert("Error", "Please enter all fields", "Ok");
            }


     
        }

    }
}
