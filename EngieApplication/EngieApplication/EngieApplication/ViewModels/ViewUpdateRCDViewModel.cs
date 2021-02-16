using EngieApplication.FirebaseInteraction;
using EngieApplication.Models;
using EngieApplication.Services;
using EngieApplication.WorkerPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace EngieApplication.ViewModels
{
    class ViewUpdateRCDViewModel : INotifyPropertyChanged
    {


        /// <summary>
        /// 
        /// Creator: Finn Rea 
        /// 
        /// This ViewModel is binded to ViewUpdateGas View. 
        /// It displays all Gas asset infomation of selected RCD asset. it then allow for input or changes to asset infomation changes.
        /// Before updating asset it validate all new input are in the correct format. 
        /// It also allows for the deletion of selected RCD asset on button click 
        /// 
        /// 
        /// </summary>



        IPageService page;
        RCD rCD;
        RCDFirebaseHelper rCDFirebaseHelper = new RCDFirebaseHelper();
        Person worker = (Person)Application.Current.Properties["LoggedIn"];


        string jobRef;

        string siteAddress;

        // string applianceDetails;

        string switchBoardReferance;

        string circuitReference;

        bool functionalTest;

        string annualServiceX1;

        string annualServiceX5;

        string date;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



        public ViewUpdateRCDViewModel(RCD inRCD, PageService inPageService)
        {
            UpdateRCD = new Command(async () => await UpdateRCDAssetAsync());
            DeleteRCD = new Command(async () => await DeleteRCDAssetAsync());
            page = inPageService;
            rCD = inRCD;

            jobRef = rCD.JobRef.ToString();

            siteAddress = rCD.SiteAddress;

            switchBoardReferance = rCD.SwitchBoardReferance;

            circuitReference = rCD.CircuitReference;

            functionalTest = rCD.FunctionalTest;

            annualServiceX1 = rCD.AnnualServiceX1.ToString();

            annualServiceX5 = rCD.AnnualServiceX5.ToString();

            date = rCD.Date;


        }


        public string Name { get { return worker.Name;  } }

        public string JobRef { get { return jobRef; } }

        public string SiteAddress { get { return siteAddress; } set { siteAddress = value; OnPropertyChanged(); } }


        public string SwitchBoardReferance { get { return switchBoardReferance; OnPropertyChanged(); } }

        public string CircuitReference { get { return circuitReference; } set { circuitReference = value; OnPropertyChanged(); } }

        public bool FunctionalTest { get { return functionalTest; } set { functionalTest = value; OnPropertyChanged(); } }


        public string AnnualServiceX1 { get { return annualServiceX1; } set { annualServiceX1 = value; OnPropertyChanged(); } }

        public string AnnualServiceX5 { get { return annualServiceX5; } set { annualServiceX5 = value; OnPropertyChanged(); } }


        //  Currently in US time
        public string Date { get { return date; } set { date = value; OnPropertyChanged(); } }


        public Command UpdateRCD { get; private set; }

        async System.Threading.Tasks.Task UpdateRCDAssetAsync()
        {



            try
            {


                if (jobRef != "" &&

                 siteAddress != "" &&

                 switchBoardReferance != "" &&

                 circuitReference != "" &&

                 annualServiceX1 != "" &&

                 annualServiceX5 != "" &&

                 date != "")
                {

                    await rCDFirebaseHelper.UpdateRCD(worker.Name, worker.PersonId, Int32.Parse(jobRef), siteAddress, date,
                        switchBoardReferance, circuitReference, functionalTest, Int32.Parse(annualServiceX1), Int32.Parse(annualServiceX5));

                    await page.DisplayAlert("", "", "Ok");
                }
                else
                {
                    await page.DisplayAlert("Error", "You are missing fields", "Ok");
                }
            }
            catch
            {

            }
        }

        public Command DeleteRCD { get; private set; }

        async System.Threading.Tasks.Task DeleteRCDAssetAsync()
        {
            try
            {
                await rCDFirebaseHelper.DeleteRCDBySwitchBoardRef(SwitchBoardReferance);
                await page.DisplayAlert("Success", "Successfully Remove Asset", "Ok");
                await page.PopAsync();
            }
            catch
            {
                await page.DisplayAlert("Error", "Error when deleting Asset", "Ok");
            }
        }



     
    }
}
