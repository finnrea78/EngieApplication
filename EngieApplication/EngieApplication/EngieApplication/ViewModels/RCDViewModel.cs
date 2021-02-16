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
    class RCDViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Creator: Finn Rea
        /// 
        /// This view model is binded to AddRCDAsset. It allows for input of all nessary infomation to create an RCD asset
        /// When creating RCD checks all parts are valid. Linking the Asset to JobRef provided
        /// 
        /// 
        /// </summary>




        public event PropertyChangedEventHandler PropertyChanged;
        RCDFirebaseHelper rCDFirebaseHelper = new RCDFirebaseHelper();
        
        // Gets currently logged in user in session 
        
        Person worker = (Person)Application.Current.Properties["LoggedIn"];
        DateTime dateTime = DateTime.Today;

        IPageService pageService;


        public RCDViewModel(IPageService inpageService)
        {
            pageService = inpageService;
            AddAssetCommand = new Command(async () => await AddAssetAsync());
        }


        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



        public string Name
        {
            get
            {
                return worker.Name;
            }
        }


        public string JobRef { get; set; }

        public string SiteAddress { get; set; }

        public string SwitchBoardReferance { get; set; }

        public string CircuitReference { get; set; }

        public bool FunctionalTest { get; set; }


        public string AnnualServiceX1 { get; set; }

        public string AnnualServiceX5 { get; set; }


        //  Currently in US time
        public string Date
        {
            get
            {
                return dateTime.ToString();
            }
        }


        public Command AddAssetCommand { get; }

        async System.Threading.Tasks.Task AddAssetAsync()
        {

            // App.Current.MainPage = new WorkerPages.WorkerMainPage();

            try
            {


                if (
              JobRef != null && JobRef != "" &&
              SiteAddress != null && SiteAddress != "" &&
              SwitchBoardReferance != null && SwitchBoardReferance != "" &&
              CircuitReference != null && CircuitReference != "" &&
              AnnualServiceX1 != null && AnnualServiceX1 != "" &&
              AnnualServiceX5 != null && AnnualServiceX5 != "")
                {

                    // Check if switch board already exists
                    RCD rCD = await rCDFirebaseHelper.GetAllRCDsBySwitchBoardRef(SwitchBoardReferance);
                    if (rCD == null)
                    {

                        await rCDFirebaseHelper.AddRCDAsset(Name, worker.PersonId, Int32.Parse(JobRef), SiteAddress, Date,
                            SwitchBoardReferance, CircuitReference, FunctionalTest, Int32.Parse(AnnualServiceX1), Int32.Parse(AnnualServiceX5));


                        await pageService.DisplayAlert("Added successfully", "", "Ok");
                        await pageService.PopAsync();
                        
                    }
                    else
                    {

                        await pageService.DisplayAlert("Error", "This switch board already exists", "Ok");
                    }


                }
                else
                {
                    await pageService.DisplayAlert("Error", "You are missing fields", "Ok");
                }


            }
            catch(Exception e)
            {
                await pageService.DisplayAlert("Error", "Missing input", "Ok");
                Console.WriteLine(e.StackTrace);
            }
        }




    }
    public static class TaskExtention
    {
        public async static void Await(this Task task, Action completedCallBack, Action<Exception> errorCallback)
        {

            /// 
            /// This is used in other classes. It allow for awaiting within syncrous methods or constuctors which is an issue difficult to over come otherwise
            ///
            ///

            try
            {
                await task;
                completedCallBack?.Invoke();
            }
            catch (Exception ex)
            {
                errorCallback?.Invoke(ex);
            }
        }
    }
}
