using EngieApplication.FirebaseInteraction;
using EngieApplication.Models;
using EngieApplication.Services;
using EngieApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EngieApplication.WorkerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RemoveItem : ContentPage
    {



        /// <summary>
        /// 
        /// Creator: Finn Rea
        /// 
        /// Unfortunately similar to ViewAccounts Page in AdminPages I was unable to implement search bar or picker in view model. Attempt can be seen in RemoveItemViewModel.cs 
        /// 
        /// In here it gets a list of all assets and jobs. Then dependant on picker displays a list of type of asset or Jobs.
        /// From here the user can then search by Ids dependany on what items is picked from the picker.
        /// On this the user can select the asset and remove. On remove they can refresh the list view. 
        /// 
        /// 
        /// </summary>

        List<Job> jobs;
        List<Gas> gas;
        List<RCD> RCDs;
        List<Lighting> lightings;
        int index;
        PageService pageService;
        public RemoveItem()
        {
            
            InitializeComponent();
            GetAllJobsAsync().Await(Completed, HandleError);
            GetAllRCDAsync().Await(Completed, HandleError);
            GetAllGasAsync().Await(Completed, HandleError);
            GetAllLightsAsync().Await(Completed, HandleError);
            pageService = new PageService();
            Refresh = new Command(async () => await refresh());

            BindingContext = this;
        }

        private void HandleError(Exception obj)
        {
            //throw new NotImplementedException();
        }

        private void Completed()
        {
            //throw new NotImplementedException();
        }

        public async Task GetAllJobsAsync()
        {
            JobsFirebaseHelper jobsFireBaseHelper = new JobsFirebaseHelper();
            List<Job> tempjobs = await jobsFireBaseHelper.GetAllJobsAsync();
            jobs = tempjobs;
        }
        public async Task GetAllGasAsync()
        {
            GasFirebaseHelper GasFireBaseHelper = new GasFirebaseHelper();
            List<Gas> tempGas = await GasFireBaseHelper.GetAllGasAsync();
            gas = tempGas;
        }

        public async Task GetAllRCDAsync()
        {
            RCDFirebaseHelper rCDFirebaseHelper = new RCDFirebaseHelper();
            List<RCD> tempRCD = await rCDFirebaseHelper.GetAllRCDsAsync();
            RCDs = tempRCD;
        }

        public async Task GetAllLightsAsync()
        {
            LightingFirebaseHelper lightingFirebaseHelper = new LightingFirebaseHelper();
            List<Lighting> tempLighting = await lightingFirebaseHelper.GetAllLightingAsync();
            lightings = tempLighting;
        }
            private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            searchBar.Text = "";
            index = picker.SelectedIndex;
            if (index == 0)
            {
                ViewAssets.ItemsSource = jobs;
            }
            else if(index == 1)
            {
                ViewAssets.ItemsSource = RCDs;
            }
            else if(index == 2)
            {
                ViewAssets.ItemsSource = gas;
            }
            else if (index == 3)
            {
                ViewAssets.ItemsSource = lightings;
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            SearchBar searchBar = (SearchBar)sender;
            if (index == -1)
            {

            }
            else if (index == 0 )
            {
                List<Job> searchedJobs =
               (from job in jobs
                where job.JobRef.ToString().Contains(searchBar.Text)
                select job).ToList();

                ViewAssets.ItemsSource = searchedJobs;
            }
            else if (index == 1)
            {
                List<RCD> searchedRCD =
               (from RCD in RCDs
                where RCD.SwitchBoardReferance.Contains(searchBar.Text)
                select RCD).ToList();

                ViewAssets.ItemsSource = searchedRCD;
            }
            else if (index ==2 )
            {
                GetAllGasAsync().Await(Completed, HandleError);
                List<Gas> searchedGas =
              (from gasSelect in gas
               where gasSelect.SerialNumber.Contains(searchBar.Text)
               select gasSelect).ToList();

                ViewAssets.ItemsSource = searchedGas;

            }
            else if(index == 3)
            {
                List<Lighting> searchedLighting =
                    (from lightingSelect in lightings
                     where lightingSelect.ID.Contains(searchBar.Text)
                     select lightingSelect).ToList();
                    
                ViewAssets.ItemsSource = searchedLighting;
            }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {


            try
            {

                GasFirebaseHelper gasFireBaseHelper = new GasFirebaseHelper();
                JobsFirebaseHelper jobsFirebase = new JobsFirebaseHelper();
                RCDFirebaseHelper rCDFirebaseHelper = new RCDFirebaseHelper();
                LightingFirebaseHelper lightingFirebaseHelper = new LightingFirebaseHelper();
                var selectedItem = ViewAssets.SelectedItem;

                if (selectedItem != null)
                {
                    if (index == -1)
                    {

                    }
                    else if (index == 0)
                    {
                        GetAllJobsAsync().Await(Completed, HandleError);
                        Job job = (Job)selectedItem;
                        await jobsFirebase.DeleteJob(job.JobRef);
                        await pageService.DisplayAlert("Success", "Removed job", "Ok");
                        GetAllJobsAsync().Await(Completed, HandleError);

                        ViewAssets.ItemsSource = jobs;
                    }
                    else if (index == 1)
                    {
                        GetAllRCDAsync().Await(Completed, HandleError);
                        RCD rcd = (RCD)selectedItem;
                        await rCDFirebaseHelper.DeleteRCDBySwitchBoardRef(rcd.SwitchBoardReferance);
                        await pageService.DisplayAlert("Success", "Removed RCD", "Ok");
                        GetAllRCDAsync().Await(Completed, HandleError);
                        ViewAssets.ItemsSource = RCDs;



                    }
                    else if (index == 2)
                    {
                        Gas gasRemove = (Gas)selectedItem;
                        await gasFireBaseHelper.DeleteGasBySerialNumber(gasRemove.SerialNumber);
                        await pageService.DisplayAlert("Success", "Removed Gas", "Ok");
                        GetAllGasAsync().Await(Completed, HandleError);

                        ViewAssets.ItemsSource = gas;
                    }

                    else if (index == 3)
                    {
                        Lighting lightRemove = (Lighting)selectedItem;
                        await lightingFirebaseHelper.DeleteLightingByID(lightRemove.ID);
                        await pageService.DisplayAlert("Success", "Removed light", "Ok");
                        GetAllLightsAsync().Await(Completed, HandleError);

                        ViewAssets.ItemsSource = lightings;
                    }

                    ViewAssets.SelectedItem = null;



                }
                else
                {
                    await pageService.DisplayAlert("Error", "Select Asset or Job", "Ok");
                }
            }
            catch
            {
                await pageService.DisplayAlert("Error", "", "Ok");
            }
        }

        public Command Refresh
        {
            get; private set;
        }

        public async Task refresh()
        {
            ViewAssets.IsRefreshing = true;
            //This turns on the activity
            //Indicator for the ListView
            //Then add your code to execute when the ListView is pulled
            if (index == -1)
            {

            }
            else if (index == 0)
            {
                ViewAssets.ItemsSource = jobs;
            }
            else if (index == 1)
            {
                ViewAssets.ItemsSource = RCDs;
            }
            else if (index == 2)
            {
                ViewAssets.ItemsSource = gas;
            }
            else if (index == 3)
            {
                ViewAssets.ItemsSource = lightings;
            }

            ViewAssets.IsRefreshing = false;

        }

        protected  override void OnAppearing()
        {
            GetAllJobsAsync().Await(Completed, HandleError);
            GetAllRCDAsync().Await(Completed, HandleError);
            GetAllGasAsync().Await(Completed, HandleError);
        }

    }


}