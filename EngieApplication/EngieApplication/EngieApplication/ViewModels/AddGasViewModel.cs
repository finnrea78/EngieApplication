using EngieApplication.FirebaseInteraction;
using EngieApplication.Models;
using EngieApplication.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EngieApplication.ViewModels
{
    class AddGasViewModel : INotifyPropertyChanged
    {
        /// <summary>
        ///  Creator: Finn Rea
        ///  
        ///  This is the view model for adding a new Gas asset.
        ///  It is binded the ADDGasAsset.
        ///  In here it checks all fields are filled and valid then attempted to add the asset to the database.
        /// 
        /// 
        /// </summary>





        public event PropertyChangedEventHandler PropertyChanged;



        // This is to check if the binded value has change it re-updates values. 
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



        GasFirebaseHelper gasFireBaseHelper = new GasFirebaseHelper();
        IPageService pageService;


        Person worker = (Person)Application.Current.Properties["LoggedIn"];



        // Only ones that require yes/no/Na and input validation


        string flueType;
        bool flueTypeValid = false;
        string operational;
        bool operationalValid = false;
        string installationLine;
        bool installationLineValid = false;
        string pipeWorkColour;
        bool pipeWorkColourValid = false;
        string flueTermination;
        bool flueTerminationValid = false;
        string tightness;
        bool tightnessValid = false;
        string fansOperational;
        bool fansOperationalValid = false;
        string flueFlowSatisfactory;
        bool flueFlowSatisfactoryValid = false;
        string spillageTest;
        bool spillageTestValid = false;
        string airGasSwitch;
        bool airGasSwitchValid = false;
        string flameDevices;
        bool flameDevicesValid = false;





        public AddGasViewModel(IPageService inpage)
        {
            AddAssetCommand = new Command(async () => await AddAssetAsync());
            pageService = inpage;
        }



        public string Name { get; set; }
        public int WorkerId { get; set; }
        public string JobRef { get; set; }
        public string SafeCard { get; set; }
        public string OfficeAddress { get; set; }
        public string SiteAddress { get; set; }
        public bool LandlordAppliance { get; set; }
        public string ServiceInspectionRepair { get; set; }

        public string Type { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string BurnerManufacture { get; set; }
        public string FlueType
        {
            get
            {
                return flueType;
            }
            set
            {

                ///
                ///
                /// There is no drop down box forces user to only type in one of 3 possible options 
                ///
                ///


                flueType = value;
                if (flueType.ToLower() == "of" || flueType.ToLower() == "rs" || flueType.ToLower() == "rl")
                {
                    flueTypeValid = true;
                }
                else
                {
                    flueTypeValid = false;
                }
                OnPropertyChanged();

            }
        }
        public string Operational
        {
            get
            {
                return operational;
            }
            set
            {
                operational = value;
                if (operational.ToLower() == "yes" || operational.ToLower() == "no" || operational.ToLower() == "na")
                {
                    operationalValid = true;
                }
                else
                {
                    operationalValid = false;
                }
                OnPropertyChanged();
            }
        }
        public string InstallationLine
        {
            get
            {
                return installationLine;
            }
            set
            {
                installationLine = value;
                if (installationLine.ToLower() == "yes" || installationLine.ToLower() == "no" || installationLine.ToLower() == "na")
                {
                    installationLineValid = true;
                }
                else
                {
                    installationLineValid = false;
                }
                OnPropertyChanged();
            }
        }
        public bool Installation { get; set; }
        public bool PipeWork { get; set; }
        public bool PipeWorkSleeved { get; set; }
        public string PipeWorkColour
        {
            get
            {
                return pipeWorkColour;
            }
            set
            {
                pipeWorkColour = value;
                if (pipeWorkColour.ToLower() == "yes" || pipeWorkColour.ToLower() == "no" || pipeWorkColour.ToLower() == "na")
                {
                    pipeWorkColourValid = true;
                }
                else
                {
                    pipeWorkColourValid = false;
                }
                OnPropertyChanged();
            }
        }
        public bool Flue { get; set; }
        public string FlueTermination
        {
            get
            {
                return flueTermination;
            }
            set
            {
                flueTermination = value;
                if (flueTermination.ToLower() == "yes" || flueTermination.ToLower() == "no" || flueTermination.ToLower() == "na")
                {
                    flueTerminationValid = true;
                }
                else
                {
                    flueTerminationValid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Tightness
        {
            get
            {
                return tightness;
            }
            set
            {
                tightness = value;
                if (tightness.ToLower() == "yes" || tightness.ToLower() == "no" || tightness.ToLower() == "na")
                {
                    tightnessValid = true;
                }
                else
                {
                    tightnessValid = false;
                }
                OnPropertyChanged();
            }
        }
        public bool PipeworkBonded { get; set; }
        public bool EmergencyValves { get; set; }
        public bool ValveHandles { get; set; }
        public bool ValvesPosition { get; set; }
        public bool CombutionMaterials { get; set; }
        public string FlowInletActual { get; set; }
        public string FlowInletRequired { get; set; }
        public string FlowExtractActual { get; set; }
        public string FlowExtractRequired { get; set; }
        public bool VentsClear { get; set; }
        public string FansOperational
        {
            get
            {
                return fansOperational;
            }
            set
            {
                fansOperational = value;
                if (fansOperational.ToLower() == "yes" || fansOperational.ToLower() == "no" || fansOperational.ToLower() == "na")
                {
                    fansOperationalValid = true;
                }
                else
                {
                    fansOperationalValid = false;
                }
                OnPropertyChanged();
            }
        }
        public string Faults { get; set; }
        public string Actions { get; set; }
        public string FlueFlowSatisfactory
        {
            get
            {
                return flueFlowSatisfactory;
            }
            set
            {
                flueFlowSatisfactory = value;
                if (flueFlowSatisfactory.ToLower() == "yes" || flueFlowSatisfactory.ToLower() == "no" || flueFlowSatisfactory.ToLower() == "na")
                {
                    flueFlowSatisfactoryValid = true;
                }
                else
                {
                    flueFlowSatisfactoryValid = false;
                }
                OnPropertyChanged();
            }
        }
        public string SpillageTest
        {
            get
            {
                return spillageTest;
            }
            set
            {
                spillageTest = value;
                if (spillageTest.ToLower() == "yes" || spillageTest.ToLower() == "no" || spillageTest.ToLower() == "na")
                {
                    spillageTestValid = true;
                }
                else
                {
                    spillageTestValid = false;
                }
                OnPropertyChanged();
            }
        }
        public string AirGasSwitch
        {
            get
            {
                return airGasSwitch;
            }
            set
            {
                airGasSwitch = value;
                if (airGasSwitch.ToLower() == "yes" || airGasSwitch.ToLower() == "no" || airGasSwitch.ToLower() == "na")
                {
                    airGasSwitchValid = true;
                }
                else
                {
                    airGasSwitchValid = false;
                }
                OnPropertyChanged();
            }
        }
        public string FlameDevices
        {
            get
            {
                return flameDevices;
            }
            set
            {
                flameDevices = value;
                if (flameDevices.ToLower() == "yes" || flameDevices.ToLower() == "no" || flameDevices.ToLower() == "na")
                {
                    flameDevicesValid = true;
                }
                else
                {
                    flameDevicesValid = false;
                }
                OnPropertyChanged();
            }
        }
        public string BurnerLockout { get; set; }
        public bool TempLimit { get; set; }
        public string HeatInput { get; set; }
        public string GasBurnerPressureRequired { get; set; }
        public string GasBurnerPressureMeasure { get; set; }
        public string GasRating { get; set; }
        public string AirGasRatio { get; set; }
        public string NetFlueTemp { get; set; }
        public string Oxygen { get; set; }
        public string CarbonMonoxide { get; set; }
        public string CarbonDioxide { get; set; }
        public string Air { get; set; }
        public string COCO2 { get; set; }
        public string Efficiency { get; set; }
        public string COFlue { get; set; }
        public string StandingPressure { get; set; }
        public string WorkingPressure { get; set; }
        public bool SafeToUse { get; set; }

        public Command AddAssetCommand { get; }

        async System.Threading.Tasks.Task AddAssetAsync()
        {


            try
            {

                // Check all fields filled out and all vaild. 
                // it they input and delete the string desn't return to null but to a empty string ""




                if ((Name != "" && Name != null)&&(

          JobRef != "" && JobRef != null)&&(
          SafeCard != "" && SafeCard != null)&&(
          OfficeAddress != "" && OfficeAddress != null)&&(
          SiteAddress != "" && SiteAddress != null)&&(
          ServiceInspectionRepair != "" && ServiceInspectionRepair != null)&&(
          Type != "" && Type != null)&&(
          Model != "" && Model != null)&&(
          SerialNumber != "" && SerialNumber != null)&&(
          BurnerManufacture != "" && BurnerManufacture != null)&&(
          FlowInletActual != "" && FlowInletActual != null)&&(
          FlowInletRequired != "" && FlowInletRequired != null)&&(
          FlowExtractActual != "" && FlowExtractActual != null)&&(
          FlowExtractRequired != "" &&   FlowExtractRequired  !=null)&&(
          Faults != "" && Faults != null)&&(
          Actions != "" && Actions != null)&&(
          BurnerLockout != "" && BurnerLockout != null)&&(
          GasBurnerPressureRequired != "" && GasBurnerPressureRequired != null)&&(
          GasBurnerPressureMeasure != "" && GasBurnerPressureMeasure != null)&&(
          GasRating != "" && GasRating != null)&&(
          AirGasRatio != "" && AirGasRatio != null)&&(
          NetFlueTemp != "" && NetFlueTemp != null)&&(
          Oxygen != "" && Oxygen != null)&&(
          CarbonMonoxide != "" && CarbonMonoxide != null)&&(
          CarbonDioxide != "" && CarbonDioxide != null)&&(
          Air != "" && Air != null)&&(
          COCO2 != "" && COCO2 != null)&&(
          Efficiency != "" && Efficiency != null)&&(
          COFlue != "" && COFlue != null)&&(
          StandingPressure != "" && StandingPressure != null)&&(
          WorkingPressure != "" && WorkingPressure != null)&&(
          flueTypeValid &&
          operationalValid &&
          installationLineValid &&
          pipeWorkColourValid &&
          flueTerminationValid &&
          tightnessValid &&
          fansOperationalValid &&
          flueFlowSatisfactoryValid &&
          spillageTestValid &&
          airGasSwitchValid &&
          flameDevicesValid))
                {




                    // Checks if serial Num already exists?
                    Gas gasExists = await gasFireBaseHelper.GetAllGasBySerialNum(SerialNumber);


                    if (gasExists == null)
                    {


                        await gasFireBaseHelper.AddGasAsset(
                              Name,
                  worker.PersonId,
                  Int32.Parse(JobRef),
                  SiteAddress,
                  SafeCard,
                  OfficeAddress,
                  LandlordAppliance,
                  ServiceInspectionRepair,
                  Type,
                  Model,
                  SerialNumber,
                  BurnerManufacture,
                  flueType,
                  operational,
                  installationLine,
                  Installation,
                  PipeWork,
                  PipeWorkSleeved,
                  pipeWorkColour,
                  Flue,
                  flueTermination,
                  tightness,
                  PipeworkBonded,
                  EmergencyValves,
                  ValveHandles,
                  ValvesPosition,
                  CombutionMaterials,
                  Int32.Parse(FlowInletActual),
                  Int32.Parse(FlowInletRequired),
                  Int32.Parse(FlowExtractActual),
                  Int32.Parse(FlowExtractRequired),
                  VentsClear,
                  fansOperational,
                  Faults,
                  Actions,
                  flueFlowSatisfactory,
                  spillageTest,
                  airGasSwitch,
                  flameDevices,
                  Int32.Parse(BurnerLockout),
                  TempLimit,
                  Int32.Parse(HeatInput),
                  Int32.Parse(GasBurnerPressureRequired),
                  Int32.Parse(GasBurnerPressureMeasure),
                  Int32.Parse(GasRating),
                  Int32.Parse(AirGasRatio),
                  Int32.Parse(NetFlueTemp),
                  Int32.Parse(Oxygen),
                  Int32.Parse(CarbonMonoxide),
                  Int32.Parse(CarbonDioxide),
                  Int32.Parse(Air),
                  Int32.Parse(COCO2),
                  Int32.Parse(Efficiency),
                  Int32.Parse(COFlue),
                  Int32.Parse(StandingPressure),
                  Int32.Parse(WorkingPressure),
                  SafeToUse);

                        

                        await pageService.DisplayAlert("Added succesfully", "Success", "Ok");
                        await pageService.PopAsync();
                    }
                    else
                    {
                        await pageService.DisplayAlert("Exists", "That serial number already exists", "Ok");
                    }

                }
                else
                {
                    await pageService.DisplayAlert("Error", "Unable to add asset or fields missing", "Ok");
                }
            }
            catch
            {
                await pageService.DisplayAlert("error", "please enter all fields", "Ok");
            }
        }

    }
}
