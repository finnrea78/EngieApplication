using EngieApplication.FirebaseInteraction;
using EngieApplication.Models;
using EngieApplication.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace EngieApplication.ViewModels
{
    class ViewUpdateLightingViewModel : INotifyPropertyChanged
    {



        /// <summary>
        /// 
        /// Creator: Finn Rea 
        /// 
        /// This ViewModel is binded to ViewUpdateLighting View. 
        /// It displays all Gas asset infomation of selected lighting asset. it then allow for input or changes to asset infomation changes.
        /// Before updating asset it validate all new input are in the correct format. 
        /// It also allows for the deletion of selected lighting asset on button click.
        /// 
        /// 
        /// </summary>




        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    

        Lighting lighting;
        IPageService page;



         string name ;
         string adress ;
         string postcode ;
         string telNo ;
         string jobRef ;
         string id ;

        string engineersName;
        
         string rPC ;
         string officeAdress ;
         string officePostcode ;
         string officeTelNo ;

         string responsiblePerson ;

         string systemManufacturer ;
         string manufacturerTelNo ;
         string responsibleEngineer ;
         string engineersTelNo ;

         string comissionDate ;

         string nonmaintained ;
        //Non-maintained luminaires maintained signs
         string nonmaintainedLMS ;
         string maintained ;
         string others ;

         string hours ;
         bool isAutomatic ;

         string addMod1 ;
         string addMod2 ;
         string addMod3 ;
         string addMod4 ;
         string addMod5 ;
         string addMod6 ;

         string signature ;
        //  Currently in US time
        string date;
        
         string siteAdress ;

        //Question 1.1
         string q11 ;
         string q12 ;
         string q13 ;
         string q14 ;
         string q15 ;
         string q16;
         string q21 ;
         string q22 ;
         string q23 ;
         string q24 ;
         string q25 ;
         string q26 ;
         string q27 ;
         string q31 ;
         string q32 ;
         string q33 ;
         string q34 ;
         string q41 ;
         string q42 ;
         string q43 ;
         string q44 ;
         string q45 ;
         string q51 ;
         string q61 ;
         string q62 ;
         string q63 ;
         string q64 ;
         string q65 ;
         string q66 ;
         string q67 ;
         string q68 ;
         string q69 ;
         string q610 ;
         string results ;
         string comments ;




        bool q11Valid  =true;
        bool q12Valid = true;
        bool q13Valid = true;
        bool q14Valid = true;
        bool q15Valid = true;
        bool q16Valid = true;
        bool q21Valid = true;
        bool q22Valid = true;
        bool q23Valid = true;
        bool q24Valid = true;
        bool q25Valid = true;
        bool q26Valid = true;
        bool q27Valid = true;
        bool q31Valid = true;
        bool q32Valid = true;
        bool q33Valid = true;
        bool q34Valid = true;
        bool q41Valid = true;
        bool q42Valid = true;
        bool q43Valid = true;
        bool q44Valid = true; 
        bool q45Valid = true;
        bool q51Valid = true;
        bool q61Valid = true;
        bool q62Valid = true;
        bool q63Valid = true;
        bool q64Valid = true;
        bool q65Valid = true;
        bool q66Valid = true;
        bool q67Valid = true;
        bool q68Valid = true;
        bool q69Valid = true;
        bool q610Valid = true;




        LightingFirebaseHelper lightingFirebaseHelper = new LightingFirebaseHelper();
       


        public ViewUpdateLightingViewModel(Lighting inLighting, PageService inPage)
        {
            lighting = inLighting;
            page = inPage;
            DeleteLighting = new Command(async () => await DeleteLightingAssetAsync());
            UpdateLighting = new Command(async () => await UpdateLightingAssetAsync());




            name = lighting.Name;
            adress = lighting.Adress;
            postcode = lighting.Postcode;
            telNo = lighting.TelNo;
            jobRef = lighting.JobRef.ToString();
            id = lighting.ID;

            engineersName = lighting.EngineersName;

            rPC = lighting.RPC;
            officeAdress = lighting.OfficeAdress;
            officePostcode = lighting.OfficePostcode;
            officeTelNo = lighting.OfficeTelNo;

            responsiblePerson = lighting.ResponsiblePerson;

            systemManufacturer = lighting.SystemManufacturer;
            manufacturerTelNo = lighting. ManufacturerTelNo   ;
            responsibleEngineer = lighting.ResponsibleEngineer;
            engineersTelNo = lighting.EngineersTelNo;

            comissionDate = lighting.ComissionDate;

            nonmaintained = lighting.Nonmaintained;
            //Non-maintained luminaires maintained signs
            nonmaintainedLMS = lighting.NonmaintainedLMS;
            maintained = lighting.Maintained;
            others = lighting.Others;

            hours = lighting.Hours.ToString();
            isAutomatic = lighting.IsAutomatic;

            addMod1 = lighting.AddMod1;
            addMod2 = lighting.AddMod2;
            addMod3 = lighting.AddMod3;
            addMod4 = lighting.AddMod4;
            addMod5 = lighting.AddMod5;
            addMod6 = lighting.AddMod6;

            signature = lighting.Signature   ;
            //  Currently in US time
            date = lighting.Date;

            //siteAdress = lighting.SiteAdress;

            ////Question 1.1
            q11 = lighting.Q11;
            q12 = lighting.Q12;
            q13 = lighting.Q13;
            q14 = lighting.Q13;
            q15 = lighting.Q15;
            q21 = lighting.Q21;
            q22 = lighting.Q22;
            q23 = lighting.Q23;
            q24 = lighting.Q24;
            q25 = lighting.Q25;
            q26 = lighting.Q26;
            q27 = lighting.Q27;
            q31 = lighting.Q31;
            q32 = lighting.Q32;
            q33 = lighting.Q33;
            q34 = lighting.Q34;
            q41 = lighting.Q41;
            q42 = lighting.Q42;
            q43 = lighting.Q43;
            q44 = lighting.Q44;
            q45 = lighting.Q45;
            q51 = lighting.Q51;
            q61 = lighting.Q61;
            q62 = lighting.Q62;
            q63 = lighting.Q63;
            q64 = lighting.Q64;
            q65 = lighting.Q65;
            q66 = lighting.Q66;
            q67 = lighting.Q67;
            q68 = lighting.Q68;
            q69 = lighting.Q69;
            q610 = lighting.Q610;
            results = lighting.Results;
            comments = lighting.Comments;

        }



        public String Name { get { return name;  } set { name = value;OnPropertyChanged(); } }
        public String Adress { get { return adress;  } set { adress = value;OnPropertyChanged(); } }
        public String Postcode { get { return postcode;  } set { postcode = value;OnPropertyChanged(); } }
        public String TelNo { get { return telNo;  } set { telNo = value;OnPropertyChanged(); } }
        public string JobRef { get { return jobRef;  } }
        public string Id { get { return id;  } }

        public string EngineersName
        {
            get
            {
                return engineersName;
            }
        }
        public String RPC { get { return rPC;  } set { rPC = value;OnPropertyChanged(); } }
        public String OfficeAdress { get { return officeAdress;  } set { officeAdress = value;OnPropertyChanged(); } }
        public String OfficePostcode { get { return officePostcode;  } set { officePostcode = value;OnPropertyChanged(); } }
        public String OfficeTelNo { get { return officeTelNo;  } set { officeTelNo = value;OnPropertyChanged(); } }

        public String ResponsiblePerson { get { return responsiblePerson;  } set { responsiblePerson = value;OnPropertyChanged(); } }

        public String SystemManufacturer { get { return systemManufacturer;  } set { systemManufacturer = value;OnPropertyChanged(); } }
        public String ManufacturerTelNo { get { return manufacturerTelNo;  } set { manufacturerTelNo = value;OnPropertyChanged(); } }
        public String ResponsibleEngineer { get { return responsibleEngineer;  } set { responsibleEngineer = value;OnPropertyChanged(); } }
        public String EngineersTelNo { get { return engineersTelNo;  } set { engineersTelNo = value;OnPropertyChanged(); } }

        public String ComissionDate { get { return comissionDate;  } set { comissionDate = value;OnPropertyChanged(); } }

        public String Nonmaintained { get { return nonmaintained;  } set { nonmaintained = value;OnPropertyChanged(); } }
        //Non-maintained luminaires maintained signs
        public String NonmaintainedLMS { get { return nonmaintainedLMS;  } set { nonmaintainedLMS = value;OnPropertyChanged(); } }
        public String Maintained { get { return maintained;  } set { maintained = value;OnPropertyChanged(); } }
        public String Others { get { return others;  } set { others = value;OnPropertyChanged(); } }

        public string Hours { get { return hours;  } set { hours = value;OnPropertyChanged(); } }
        public bool IsAutomatic { get { return isAutomatic;  } set { isAutomatic = value;OnPropertyChanged(); } }

        public String AddMod1 { get { return addMod1;  } set { addMod1 = value;OnPropertyChanged(); } }
        public String AddMod2 { get { return addMod2;  } set { addMod2 = value;OnPropertyChanged(); } }
        public String AddMod3 { get { return addMod3;  } set { addMod3 = value;OnPropertyChanged(); } }
        public String AddMod4 { get { return addMod4;  } set { addMod4 = value;OnPropertyChanged(); } }
        public String AddMod5 { get { return addMod5;  } set { addMod5 = value;OnPropertyChanged(); } }
        public String AddMod6 { get { return addMod6;  } set { addMod6 = value;OnPropertyChanged(); } }

        public String Signature { get { return signature;  } set { signature = value;OnPropertyChanged(); } }
        //  Currently in US time
        public string Date { get { return date;  } set { date = value;OnPropertyChanged(); } }
        public String SiteAdress { get { return siteAdress; } set { siteAdress = value; OnPropertyChanged(); } }

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
        public String Results { get { return results; } set { results = value; OnPropertyChanged(); } }
        public String Comments { get { return comments; } set { comments = value; OnPropertyChanged(); } }

        public Command UpdateLighting { get; private set; }

        async System.Threading.Tasks.Task UpdateLightingAssetAsync()
        {



            try
            {



                if (
                    
                    results != "" &&
                    comments != "" &&
                    name != "" &&
                 adress != "" &&
                 postcode != "" &&
                 telNo != "" &&
                 jobRef != "" &&
                 id != "" &&

                 engineersName != "" &&

                 rPC != "" &&
                 officeAdress != "" &&
                 officePostcode != "" &&
                 officeTelNo != "" &&

                 responsiblePerson != "" &&

                 systemManufacturer != "" &&
                 manufacturerTelNo != "" &&
                 responsibleEngineer != "" &&
                 engineersTelNo != "" &&

                 comissionDate != "" &&

                 nonmaintained != "" &&
                //Non-maintained luminaires maintained signs
                 nonmaintainedLMS != "" &&
                 maintained != "" &&
                 others != "" &&

                 hours != "" &&
                

                 addMod1 != "" &&
                 addMod2 != "" &&
                 addMod3 != "" &&
                 addMod4 != "" &&
                 addMod5 != "" &&
                 addMod6 != "" &&

                 signature != "" &&
                 date != ""


                 && (q11Valid && q12Valid && q13Valid
                    && q14Valid && q15Valid && q16Valid && q21Valid && q22Valid && q23Valid && q24Valid && q25Valid && q26Valid
                    && q27Valid && q31Valid && q32Valid && q33Valid && q34Valid && q41Valid && q42Valid && q43Valid && q44Valid
                    && q45Valid && q51Valid && q61Valid && q62Valid && q63Valid && q64Valid && q65Valid && q66Valid && q67Valid
                    && q69Valid && q610Valid))
                {




                    await lightingFirebaseHelper.UpdateLightingAsset(Id,
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
                            Int32.Parse(Hours),
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


                    await page.DisplayAlert("Success", "Successfully updated asset", "Ok");
                }
                else
                {
                    await page.DisplayAlert("Error", "Missing input or incorrect input", "Ok");
                }

            }
            catch
            {

                await page.DisplayAlert("error", "error occured", "Ok");
            }
        }







        public Command DeleteLighting { get; private set; }

        async System.Threading.Tasks.Task DeleteLightingAssetAsync()
        {
            try
            {
                await lightingFirebaseHelper.DeleteLightingByID(lighting.ID);
                await page.DisplayAlert("Success", "Succefully removed asset", "Ok");
                await page.PopAsync();
            }
            catch
            {
                await page.DisplayAlert("Error", "Error occured when trying to remove asset", "Ok");
            }
        }



    }
}
