using EngieApplication.FirebaseInteraction;
using EngieApplication.Models;
using EngieApplication.Services;
using EngieApplication.WorkerPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EngieApplication.ViewModels
{
    class SelectedJobViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Creator: Finn Rea
        /// 
        /// This is binded to  SelectedJob view. It returns all assets contained with a job in lists
        /// It allows for the selection of individaul assets of each type, and navigated to there update page
        /// This only issue with this view model is that it doesn't auto update asset lists if one is removed in 
        /// Updated views. It also allows for the user to be able to delete the entire job from the database. 
        /// 
        /// </summary>


        Job job;
        public List<Gas> gasAssets;
        NotifyTaskCompletion<ObservableCollection<RCD>> rCDAssets;

        LightingFirebaseHelper lightingFirebaseHelper = new LightingFirebaseHelper();
        RCDFirebaseHelper rCDFirebaseHelper = new RCDFirebaseHelper();

        GasFirebaseHelper gasFirebaseHelper = new GasFirebaseHelper();
        JobsFirebaseHelper jobsFirebase = new JobsFirebaseHelper();

        public event PropertyChangedEventHandler PropertyChanged;
        IPageService page;


        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public SelectedJobViewModel(Job inJob, PageService inpage)
        {
            page = inpage;
            SelectGas = new Command(async () => await ViewGasAssetAsync());
            SelectRCD = new Command(async () => await ViewRCDAssetAsync());
            SelectLighting = new Command(async () => await ViewLightingAssetAsync());
            DeleteJob = new Command(async () => await DeleteJobAsync());
            //RefreshGas = new Command(async () => await refreshGas());
            RefreshRCD = new Command(async () => await refreshRCD());


            job = inJob;

            // Gets all infomation of assets contained in jobs
            GasAssets = new NotifyTaskCompletion<List<Gas>>(ListOfGasAssetByJobRef(job.JobRef));
            RCDAssets = new NotifyTaskCompletion<List<RCD>>(ListOfRCDByJobRef(job.JobRef));
            LightingAssets = new NotifyTaskCompletion<List<Lighting>>(ListOfLightingByJobRef(job.JobRef));

            //.Await(Completed, HandleError
        }

        private async Task<List<Gas>> ListOfGasAssetByJobRef(int JobRef)
        {

            return await gasFirebaseHelper.GetAllGasByJobRef(JobRef);

        }

        private async Task<List<RCD>> ListOfRCDByJobRef(int JobRef)
        {
            return await rCDFirebaseHelper.GetAllRCDsByJobRef(JobRef);
           
        }

        private async Task<List<Lighting>> ListOfLightingByJobRef(int JobRef)
        {
            return await lightingFirebaseHelper.GetAllLightingByJobRef(JobRef);
        }

        private void HandleError(Exception obj)
        {
            //throw new NotImplementedException();
        }

        private void Completed()
        {
            //throw new NotImplementedException();
        }


        public NotifyTaskCompletion<List<Gas>> GasAssets
        {

            get; private set;


        }


        public NotifyTaskCompletion<List<RCD>> RCDAssets
        {

            get; private set;

        }



        public NotifyTaskCompletion<List<Lighting>> LightingAssets
        {

            get; private set;


        }



        public Gas SelectedGas
        {
            get; set;
        }

        public Command SelectGas { get; private set; }

        async System.Threading.Tasks.Task ViewGasAssetAsync()
        {
            if (SelectedGas != null)
            {
                await page.PushAsync(new ViewUpdateGas(SelectedGas));
            }
            else
            {
                await page.DisplayAlert("Select", "Please Select a Gas Asset", "Ok");
            }
        }

        public RCD SelectedRCD
        {
            get; set;
        }

        public Command SelectRCD { get; private set; }

        async System.Threading.Tasks.Task ViewRCDAssetAsync()
        {
            if (SelectedRCD != null)
            {
                await page.PushAsync(new ViewUpdateRCD(SelectedRCD));
            }
            else
            {
                await page.DisplayAlert("Select", "Please Select a Gas Asset", "Ok");
            }
        }


        public Lighting SelectedLighting
        {
            get; set;
        }
        public Command SelectLighting { get; private set; }

        async System.Threading.Tasks.Task ViewLightingAssetAsync()
        {
            if (SelectedLighting != null)
            {
                await page.PushAsync(new ViewUpdateLighting(SelectedLighting));
            }
            else
            {
                await page.DisplayAlert("Select", "Please Select a Lighting Asset", "Ok");
            }
        }








        public Command DeleteJob { get; private set; }

        async System.Threading.Tasks.Task DeleteJobAsync()
        {
            await jobsFirebase.DeleteJob(job.JobRef);
            await page.DisplayAlert("Succuss", "Delete Job", "Ok");
            await page.PopAsync();
        }




        public Command RefreshRCD
        {
            get; private set;
        }


        // Unfortunately as its async I can't see a way to auto update this and can't use await
        public async Task refreshRCD()
        {
            NotifyTaskCompletion<List<RCD>> Check = RCDAssets;
            IsRefreshing = true;
            
            RCDAssets = new NotifyTaskCompletion<List<RCD>>(ListOfRCDByJobRef(job.JobRef));
          
            
                IsRefreshing = false;
            
            //This turns on the activity
            //Indicator for the ListView
            //Then add your code to execute when the ListView is pulled

        }

        // For binding to refreahdata to say if it is still refreshing or not

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }








    }
}
