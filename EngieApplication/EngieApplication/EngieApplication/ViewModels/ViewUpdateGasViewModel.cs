using EngieApplication.FirebaseInteraction;
using EngieApplication.Models;
using EngieApplication.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace EngieApplication.ViewModels
{
    class ViewUpdateGasViewModel : INotifyPropertyChanged
    {


        /// <summary>
        /// 
        /// Creator: Finn Rea 
        /// 
        /// This ViewModel is binded to ViewUpdateGas View. 
        /// It displays all Gas asset infomation of selected gas asset. it then allow for input or changes to asset infomation changes.
        /// Before updating asset it validate all new input are in the correct format. 
        /// It also allows for the deletion of selected Gas asset on button click 
        /// 
        /// 
        /// </summary>




        Gas gas;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



        string jobRef;
        string safeCard;
        string officeAddress;
        string siteAddress;
        bool landlordAppliance;
        string serviceInspectionRepair;
        //string location ; 
        string type;
        string model;
        string serialNumber;
        string burnerManufacture;
        string flueType;
        string operational;
        string installationLine;
        bool installation;
        bool pipeWork;
        bool pipeWorkSleeved;
        string pipeWorkColour;
        bool flue;
        string flueTermination;
        string tightness;
        bool pipeworkBonded;
        bool emergencyValves;
        bool valveHandles;
        bool valvesPosition;
        bool combutionMaterials;
        string flowInletActual;
        string flowInletRequired;
        string flowExtractActual;
        string flowExtractRequired;
        bool ventsClear;
        string fansOperational;
        string faults;
        string actions;
        string flueFlowSatisfactory;
        string spillageTest;
        string airGasSwitch;
        string flameDevices;
        string burnerLockout;
        bool tempLimit;
        string heatInput;
        string gasBurnerPressureRequired;
        string gasBurnerPressureMeasure;
        string gasRating;
        string airGasRatio;
        string netFlueTemp;
        string oxygen;
        string carbonMonoxide;
        string carbonDioxide;
        string air;
        string cOCO2;
        string efficiency;
        string cOFlue;
        string standingPressure;
        string workingPressure;
        bool safeToUse;








        bool flueTypeValid = false;

        bool operationalValid = false;

        bool installationLineValid = false;

        bool pipeWorkColourValid = false;

        bool flueTerminationValid = false;

        bool tightnessValid = false;

        bool fansOperationalValid = false;

        bool flueFlowSatisfactoryValid = false;

        bool spillageTestValid = false;

        bool airGasSwitchValid = false;

        bool flameDevicesValid = false;



        Person worker = (Person)Application.Current.Properties["LoggedIn"];
        GasFirebaseHelper gasFirebaseHelper = new GasFirebaseHelper();

        IPageService page;
        public ViewUpdateGasViewModel(Gas inGas, PageService inpage)
        {
            gas = inGas;
            UpdateGas = new Command(async () => await UpdateGasAssetAsync());
            DeleteGas = new Command(async () => await DeleteGasAssetAsync());

            page = inpage;

            jobRef = gas.JobRef.ToString();
            safeCard = gas.SafeCard;
            officeAddress = gas.OfficeAddress;
            siteAddress = gas.SiteAddress;
            landlordAppliance = gas.LandlordAppliance;
            serviceInspectionRepair = gas.ServiceInspectionRepair;
            //location = gas.Location;
            type = gas.Type;
            model = gas.Model;
            serialNumber = gas.SerialNumber;
            burnerManufacture = gas.BurnerManufacture;
            flueType = gas.FlueType;
            operational = gas.Operational;
            installationLine = gas.InstallationLine;
            installation = gas.Installation;
            pipeWork = gas.PipeWork;
            pipeWorkSleeved = gas.PipeWorkSleeved;
            pipeWorkColour = gas.PipeWorkColour;
            flue = gas.Flue;
            flueTermination = gas.FlueTermination;
            tightness = gas.Tightness;
            pipeworkBonded = gas.PipeworkBonded;
            emergencyValves = gas.EmergencyValves;
            valveHandles = gas.ValveHandles;
            valvesPosition = gas.ValvesPosition;
            combutionMaterials = gas.CombutionMaterials;
            flowInletActual = gas.FlowInletActual.ToString();
            flowInletRequired = gas.FlowInletRequired.ToString();
            flowExtractActual = gas.FlowExtractActual.ToString();
            flowExtractRequired = gas.FlowExtractRequired.ToString();
            ventsClear = gas.VentsClear;
            fansOperational = gas.FansOperational;
            faults = gas.Faults;
            actions = gas.Actions;
            flueFlowSatisfactory = gas.FlueFlowSatisfactory;
            spillageTest = gas.SpillageTest;
            airGasSwitch = gas.AirGasSwitch;
            flameDevices = gas.FlameDevices;
            burnerLockout = gas.BurnerLockout.ToString();
            tempLimit = gas.TempLimit;
            heatInput = gas.HeatInput.ToString();
            gasBurnerPressureRequired = gas.GasBurnerPressureRequired.ToString();
            gasBurnerPressureMeasure = gas.GasBurnerPressureMeasure.ToString();
            gasRating = gas.GasRating.ToString();
            airGasRatio = gas.AirGasRatio.ToString();
            netFlueTemp = gas.NetFlueTemp.ToString();
            oxygen = gas.Oxygen.ToString();
            carbonMonoxide = gas.CarbonMonoxide.ToString();
            carbonDioxide = gas.CarbonDioxide.ToString();
            air = gas.Air.ToString();
            cOCO2 = gas.COCO2.ToString();
            efficiency = gas.Efficiency.ToString();
            cOFlue = gas.COFlue.ToString();
            standingPressure = gas.StandingPressure.ToString();
            workingPressure = gas.WorkingPressure.ToString();
            safeToUse = gas.SafeToUse;




        }


        public string Name { get { return worker.Name; } }
        public int WorkerId { get { return worker.PersonId; } }
        public string JobRef { get { return jobRef; } set { jobRef = value; OnPropertyChanged(); } }
        public string SafeCard { get { return safeCard; } set { safeCard = value; OnPropertyChanged(); } }
        public string OfficeAddress { get { return officeAddress; } set { officeAddress = value; OnPropertyChanged(); } }
        public string SiteAddress { get { return siteAddress; } set { siteAddress = value; OnPropertyChanged(); } }
        public bool LandlordAppliance { get { return landlordAppliance; } set { landlordAppliance = value; OnPropertyChanged(); } }
        public string ServiceInspectionRepair { get { return serviceInspectionRepair; } set { serviceInspectionRepair = value; OnPropertyChanged(); } }
        public string Type { get { return type; } set { type = value; OnPropertyChanged(); } }
        public string Model { get { return model; } set { model = value; OnPropertyChanged(); } }
        public string SerialNumber { get { return serialNumber; } set { serialNumber = value; OnPropertyChanged(); } }
        public string BurnerManufacture { get { return burnerManufacture; } set { burnerManufacture = value; OnPropertyChanged(); } }
        public string FlueType
        {
            get
            {
                return flueType;
            }
            set
            {
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
        public bool Installation { get { return installation; } set { installation = value; OnPropertyChanged(); } }
        public bool PipeWork { get { return pipeWork; } set { pipeWork = value; OnPropertyChanged(); } }
        public bool PipeWorkSleeved { get { return pipeWorkSleeved; } set { pipeWorkSleeved = value; OnPropertyChanged(); } }
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
        public bool Flue { get { return flue; } set { flue = value; OnPropertyChanged(); } }
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
            get { return tightness; }
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
        public bool PipeworkBonded { get { return pipeworkBonded; } set { pipeworkBonded = value; OnPropertyChanged(); } }
        public bool EmergencyValves { get { return emergencyValves; } set { emergencyValves = value; OnPropertyChanged(); } }
        public bool ValveHandles { get { return valveHandles; } set { valveHandles = value; OnPropertyChanged(); } }
        public bool ValvesPosition { get { return valvesPosition; } set { valvesPosition = value; OnPropertyChanged(); } }
        public bool CombutionMaterials { get { return combutionMaterials; } set { combutionMaterials = value; OnPropertyChanged(); } }
        public string FlowInletActual { get { return flowInletActual; } set { flowInletActual = value; OnPropertyChanged(); } }
        public string FlowInletRequired { get { return flowInletRequired; } set { flowInletRequired = value; OnPropertyChanged(); } }
        public string FlowExtractActual { get { return flowExtractActual; } set { flowExtractActual = value; OnPropertyChanged(); } }
        public string FlowExtractRequired { get { return flowExtractRequired; } set { flowExtractRequired = value; OnPropertyChanged(); } }
        public bool VentsClear { get { return ventsClear; } set { ventsClear = value; OnPropertyChanged(); } }
        public string FansOperational
        {
            get { return fansOperational; }
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
        public string Faults { get { return faults; } set { faults = value; OnPropertyChanged(); } }
        public string Actions { get { return actions; } set { actions = value; OnPropertyChanged(); } }
        public string FlueFlowSatisfactory
        {
            get { return flueFlowSatisfactory; }
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
            get { return spillageTest; }
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
            get { return airGasSwitch; }
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
            get { return flameDevices; }
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
        public string BurnerLockout { get { return burnerLockout; } set { burnerLockout = value; OnPropertyChanged(); } }
        public bool TempLimit { get { return tempLimit; } set { tempLimit = value; OnPropertyChanged(); } }
        public string HeatInput { get { return heatInput; } set { heatInput = value; OnPropertyChanged(); } }
        public string GasBurnerPressureRequired { get { return gasBurnerPressureRequired; } set { gasBurnerPressureRequired = value; OnPropertyChanged(); } }
        public string GasBurnerPressureMeasure { get { return gasBurnerPressureMeasure; } set { gasBurnerPressureMeasure = value; OnPropertyChanged(); } }
        public string GasRating { get { return gasRating; } set { gasRating = value; OnPropertyChanged(); } }
        public string AirGasRatio { get { return airGasRatio; } set { airGasRatio = value; OnPropertyChanged(); } }
        public string NetFlueTemp { get { return netFlueTemp; } set { netFlueTemp = value; OnPropertyChanged(); } }
        public string Oxygen { get { return oxygen; } set { oxygen = value; OnPropertyChanged(); } }
        public string CarbonMonoxide { get { return carbonMonoxide; } set { carbonMonoxide = value; OnPropertyChanged(); } }
        public string CarbonDioxide { get { return carbonDioxide; } set { carbonDioxide = value; OnPropertyChanged(); } }
        public string Air { get { return air; } set { air = value; OnPropertyChanged(); } }
        public string COCO2 { get { return cOCO2; } set { cOCO2 = value; OnPropertyChanged(); } }
        public string Efficiency { get { return efficiency; } set { efficiency = value; OnPropertyChanged(); } }
        public string COFlue { get { return cOFlue; } set { cOFlue = value; OnPropertyChanged(); } }
        public string StandingPressure { get { return standingPressure; } set { standingPressure = value; OnPropertyChanged(); } }
        public string WorkingPressure { get { return workingPressure; } set { workingPressure = value; OnPropertyChanged(); } }
        public bool SafeToUse { get { return safeToUse; } set { safeToUse = value; OnPropertyChanged(); } }




        public Command UpdateGas { get; private set; }

        async System.Threading.Tasks.Task UpdateGasAssetAsync()
        {



            try
            {



                if (jobRef != "" &&
                 safeCard != "" &&
                 officeAddress != "" &&
                 siteAddress != "" &&
                 serviceInspectionRepair != "" &&
                // location != "" &&
                 type != "" &&
                 model != "" &&
                 serialNumber != "" &&
                 burnerManufacture != "" &&
                 flueType != "" &&
                 operational != "" &&
                 installationLine != "" &&
                 pipeWorkColour != "" &&
                 flueTermination != "" &&
                 tightness != "" &&
                 flowInletActual != "" &&
                 flowInletRequired != "" &&
                 flowExtractActual != "" &&
                 flowExtractRequired != "" &&
                 fansOperational != "" &&
                 faults != "" &&
                 actions != "" &&
                 flueFlowSatisfactory != "" &&
                 spillageTest != "" &&
                 airGasSwitch != "" &&
                 flameDevices != "" &&
                 burnerLockout != "" &&
                 heatInput != "" &&
                 gasBurnerPressureRequired != "" &&
                 gasBurnerPressureMeasure != "" &&
                 gasRating != "" &&
                 airGasRatio != "" &&
                 netFlueTemp != "" &&
                 oxygen != "" &&
                 carbonMonoxide != "" &&
                 carbonDioxide != "" &&
                 air != "" &&
                 cOCO2 != "" &&
                 efficiency != "" &&
                 cOFlue != "" &&
                 standingPressure != "" &&
                 workingPressure != "" &&
                 flueTypeValid == true &&
                 operationalValid == true &&
                 installationLineValid == true &&
                 pipeWorkColourValid == true &&
                 flueTerminationValid == true &&
                 tightnessValid == true &&
                 fansOperationalValid == true &&
                 flueFlowSatisfactoryValid == true &&
                 spillageTestValid == true &&
                 airGasSwitchValid == true &&
                 flameDevicesValid == true)
                {




                    await gasFirebaseHelper.UpdateGas("", worker.PersonId, Int32.Parse(jobRef),
                     safeCard,
                     officeAddress,
                     siteAddress,
                     landlordAppliance,
                     serviceInspectionRepair,
                     //location,
                     type,
                     model,
                     serialNumber,
                     burnerManufacture,
                     flueType,
                     operational,
                     installationLine,
                     installation,
                     pipeWork,
                     pipeWorkSleeved,
                     pipeWorkColour,
                     flue,
                     flueTermination,
                     tightness,
                     pipeworkBonded,
                     emergencyValves,
                     valveHandles,
                     valvesPosition,
                     combutionMaterials,
                     Int32.Parse(flowInletActual),
                     Int32.Parse(flowInletRequired),
                     Int32.Parse(flowExtractActual),
                     Int32.Parse(flowExtractRequired),
                     ventsClear,
                     fansOperational,
                     faults,
                     actions,
                     flueFlowSatisfactory,
                     spillageTest,
                     airGasSwitch,
                     flameDevices,
                    Int32.Parse(burnerLockout),
                     tempLimit,
                    Int32.Parse(heatInput),
                    Int32.Parse(gasBurnerPressureRequired),
                    Int32.Parse(gasBurnerPressureMeasure),
                    Int32.Parse(gasRating),
                    Int32.Parse(airGasRatio),
                     Int32.Parse(netFlueTemp),
                    Int32.Parse(oxygen),
                    Int32.Parse(carbonMonoxide),
                     Int32.Parse(carbonDioxide),
                    Int32.Parse(air),
                    Int32.Parse(cOCO2),
                    Int32.Parse(efficiency),
                    Int32.Parse(cOFlue),
                    Int32.Parse(standingPressure),
                    Int32.Parse(workingPressure),
                     safeToUse);


                    await page.DisplayAlert("Success", "Successfully updated asset", "Ok");
                }
                else
                {
                    await page.DisplayAlert("Error", "Missing input or incorrect input", "Ok");
                }

            }
            catch
            {

                await page.DisplayAlert("error", "error occured", "Ok");
            }
        }






















        public Command DeleteGas { get; private set; }

        async System.Threading.Tasks.Task DeleteGasAssetAsync()
        {
            try
            {
                await gasFirebaseHelper.DeleteGasBySerialNumber(SerialNumber);
                await page.DisplayAlert("Success", "Succefully removed asset", "Ok");
                await page.PopAsync();
            }
            catch
            {
                await page.DisplayAlert("Error", "Error occured when trying to remove asset", "Ok");
            }
        }
    }
}
