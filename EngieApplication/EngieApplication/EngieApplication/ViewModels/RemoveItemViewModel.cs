using EngieApplication.FirebaseInteraction;
using EngieApplication.Models;
using EngieApplication.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EngieApplication.ViewModels
{
    class RemoveItemViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Creator: Finn Rea 
        /// 
        /// This view model was an attempt at using the search bar in a viewModel and with async retrival of informtion 
        /// This I found impossible. However, this was my best attempt. Possibly with more time and experience the program 
        /// could adhead to full MVVM pattern. 
        /// 
        /// 
        /// </summary>



        NotifyTaskCompletion<List<Gas>> gasAssets;
        List<RCD> rcdAssets;


        LightingFirebaseHelper lightingFirebaseHelper = new LightingFirebaseHelper();
        GasFirebaseHelper gasFirebaseHelper = new GasFirebaseHelper();
        RCDFirebaseHelper rCDFirebaseHelper = new RCDFirebaseHelper();


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



        public RemoveItemViewModel()
        {
            gasAssets = new NotifyTaskCompletion<List<Gas>>(ListOfGasAssetByJobRef());
            rcdAssets = new NotifyTaskCompletion<List<RCD>>(ListOfRCDByJobRef()).Result;

            //.Await(Completed, HandleError
        }

        private async Task<List<Gas>> ListOfGasAssetByJobRef()
        {

            return await gasFirebaseHelper.GetAllGasAsync();

        }

        private async Task<List<RCD>> ListOfRCDByJobRef()
        {

            return await rCDFirebaseHelper.GetAllRCDsAsync();

        }


        public string SelectedAssets { get; private set; }



        public ICommand PerformSearch => new Command<string>((string query) =>
        {
            GasAssets = new NotifyTaskCompletion<List<Gas>>(ListOfGasAssetByJobRef(Int32.Parse(query)));
            
        });

        private async Task<List<Gas>> ListOfGasAssetByJobRef(int JobRef)
        {

            return await gasFirebaseHelper.GetAllGasByJobRef(JobRef);

        }



        public NotifyTaskCompletion<List<Gas>> GasAssets
        {
            get
            {
                return gasAssets;
            }
            set
            {
                gasAssets = value;
                OnPropertyChanged();
            }
        }





    }
}
