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
    class ChooseAsset
    {

        /// <summary>
        /// 
        /// Creator: Finn Rea
        /// 
        ///  This view model is binded with Create asset. It is here mostly to continue the MVVM patturn.
        ///  It is movement between views allowing for the user to choose what type of asset to create
        /// 
        /// </summary>

        IPageService pageService;
        public event PropertyChangedEventHandler PropertyChanged;


        public ChooseAsset(IPageService inpageService)
        {
            pageService = inpageService;
            GasCommand = new Command(async () => await PageGas());
            RCDCommand = new Command(async () => await PageRCD());
            LightingCommand = new Command(async () => await PageLighting());
        }


        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Command GasCommand { get; }
       
        async System.Threading.Tasks.Task PageGas()
        {
            await pageService.PushAsync(new AddGasAsset());
        }

        public Command RCDCommand { get; }

        async System.Threading.Tasks.Task PageRCD()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddRCDAsset());
        }


        public Command LightingCommand { get; }

        async System.Threading.Tasks.Task PageLighting()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddLightingAsset());
        }
    }
}
