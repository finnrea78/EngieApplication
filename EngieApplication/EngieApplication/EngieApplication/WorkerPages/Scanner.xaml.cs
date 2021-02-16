using EngieApplication.FirebaseInteraction;
using EngieApplication.Models;
using EngieApplication.Services;
using EngieApplication.ViewModels;
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
    public partial class Scanner : ContentPage
    {

        /// <summary>
        /// 
        /// Creator: Finn Rea
        /// 
        /// Preferably done in a view model. However, due to time constrains and loss of a team member has been completed in code behind
        /// 
        /// The user can put scanner over the bar code. If a scanner finds a value it trys to pass the barcode value with should be a number of a jobRef
        /// pushing and passing this to SelectedJob View. 
        /// 
        /// </summary>
        


        PageService page;
        public Scanner()
        {
            InitializeComponent();
            page = new PageService();
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

        public async Task GetJobAsync(string JobRef)
        {
            JobsFirebaseHelper jobsFireBaseHelper = new JobsFirebaseHelper();
            Job tempjob = await jobsFireBaseHelper.GetJobByJobRef(Int32.Parse(JobRef));
            await page.PushAsync(new SelectedJob(tempjob));  
        }


        private void scanView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
              
                GetJobAsync(result.Text).Await(Completed, HandleError);
            });
           
        }
        async void UpdateAccount(object sender, EventArgs args)
        {
            FireBaseHelper fireBaseHelper = new FireBaseHelper();
            Person worker = (Person)Application.Current.Properties["LoggedIn"];
            Person workerUpdate = await fireBaseHelper.GetPersonID(worker.PersonId);
            await Navigation.PushAsync(new AdminPages.ViewAccount(workerUpdate));
        }

        async void DeleteAccount(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new DeleteAccount());
        }

        async void Contact(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Contact());
        }

        async void Help(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Help());
        }
    }
}