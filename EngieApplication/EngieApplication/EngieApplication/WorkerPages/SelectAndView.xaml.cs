using EngieApplication.AdminPages;
using EngieApplication.FirebaseInteraction;
using EngieApplication.Models;
using EngieApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EngieApplication.WorkerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectAndView : ContentPage
    {

        /// <summary>
        /// 
        /// Creator: Finn Rea
        /// 
        /// Preferably done in a view model. However, as mentioned I found it impossible to input a search bar with async returns in a view model
        /// This page allows for a user to search for a job by job reference.
        /// It then allows for the user to select a job and move to SelectedJob page. 
        /// 
        /// 
        /// </summary>



        List<Job> jobs;
        PageService pageService = new PageService();
        public SelectAndView()
        {


            InitializeComponent();

            GetAllJobsAsync().Await(Completed, HandleError);

            JobsView.ItemsSource = jobs;

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
            JobsView.ItemsSource = jobs;


        }


        void OnTextChanged(object sender, EventArgs e)
        {

            SearchBar searchBar = (SearchBar)sender;


            List<Job> searchedJobs =
                (from job in jobs
                 where job.JobRef.ToString().Contains(searchBar.Text)
                 select job).ToList();

            JobsView.ItemsSource = searchedJobs;
        }

        async void BTN_Clicked(object sender, EventArgs args)
        {

            try
            {
                await pageService.PushAsync(new SelectedJob((Job)JobsView.SelectedItem));
            }
            catch
            {
               await pageService.DisplayAlert("Error", "Please select and asset", "Ok");
            }
          
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetAllJobsAsync().Await(Completed, HandleError);

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await pageService.PushAsync(new Scanner());
        }


        //async void Select_Clicked(object sender, EventArgs args)
        //{
        //    await Navigation.PushAsync(new ScannedAsset());
        //}
    }


    public static class TaskExtention
    {
        public async static void Await(this Task task, Action completedCallBack, Action<Exception> errorCallback)
        {
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