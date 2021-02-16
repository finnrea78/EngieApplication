using EngieApplication.Services;
using EngieApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EngieApplication.AdminPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewAccounts : ContentPage
    {




        /// <summary>
        /// Created by: Finn Rea
        /// In this code behind is where the admin can search for a user (by name) select a user.
        /// Once selected they move to the users infomation page (ViewAccount).
        /// 
        /// I would have liked to have done this in a modelview but was unable to get the search bar functionality 
        /// to work. I have added in a notepad my final attempt at a view model for this. 
        /// </summary>


        FireBaseHelper firebaseHelper = new FireBaseHelper();
        List<Person> Employees;
        PageService pageService = new PageService();
        public ViewAccounts()
        {

            
            InitializeComponent();
            GetAllPeopleAsync().Await(Completed, HandleError);

            EmployeeView.ItemsSource = Employees;

            BindingContext = this;



        }

        private void HandleError(Exception obj)
        {
           
        }

        private  void Completed()
        {
           
            
        }

        private async Task GetAllPeopleAsync()
        {
            FireBaseHelper firebaseHelper = new FireBaseHelper();
            List<Person> People = await firebaseHelper.GetAllPersons();
            Employees = People;
            
            EmployeeView.ItemsSource = Employees;

        }








        void OnTextChanged(object sender, EventArgs e)
        {

            SearchBar searchBar = (SearchBar)sender;
           

            List<Person> searchedPeople =
                (from people in Employees
                 where people.Name.ToLower().Contains(searchBar.Text.ToLower())
                 select people).ToList();

            EmployeeView.ItemsSource = searchedPeople;
        }


        async void BTN_Clicked(object sender, EventArgs args)
        {
            try
            {
                if (EmployeeView.SelectedItem != null)
                {
                    await pageService.PushAsync(new ViewAccount((Person)EmployeeView.SelectedItem));
                }
                else
                {
                    await pageService.DisplayAlert("Error", "Please select a person", "Ok");
                }
            }
            catch
            {
                await pageService.DisplayAlert("Error", "Please select a person", "Ok");
            }
        }


        // Updates listview on popasync
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetAllPeopleAsync().Await(Completed, HandleError);

        }



    }




    //Method for await in constuctor
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