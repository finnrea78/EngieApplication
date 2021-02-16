using EngieApplication.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngieApplication.FirebaseInteraction
{
    class GasFirebaseHelper
    {


        /// <summary>
        /// Creator: Finn Rea
        /// This class is where all communication with the database for Gas assets takes place.
        /// It contains all basic CRUD (Create, read, update and delete) functionality 
        /// for Gas infomation. 
        /// 
        /// </summary>


        FirebaseClient firebase = new FirebaseClient("https://engie-31a7e-default-rtdb.firebaseio.com/");
        JobsFirebaseHelper jobsFirebase = new JobsFirebaseHelper();





        public async Task AddGasAsset(string Name, int WorkerId, int JobRef, string SiteAddress, string safeCard, string officeAddress
        , bool LandlordAppliance, string ServiceInspectionRepair, string Type, string Model
           , string SerialNumber, string BurnerManufacture, string FlueType, string Operational, string InstallationLine, bool Installation
        , bool PipeWork, bool PipeWorkSleeved, string PipeWorkColour, bool Flue, string FlueTermination, string Tightness
        , bool PipeworkBonded, bool EmergencyValves, bool ValveHandles, bool ValvesPosition, bool CombutionMaterials
        , int FlowInletActual, int FlowInletRequired, int FlowExtractActual, int FlowExtractRequired, bool VentsClear, string FansOperational
        , string Faults, string Actions, string FlueFlowSatisfactory, string SpillageTest, string AirGasSwitch, string FlameDevices
        , int BurnerLockout, bool TempLimit, int HeatInput, int GasBurnerPressureRequired, int GasBurnerPressureMeasure
        , int GasRating, int AirGasRatio, int NetFlueTemp, int Oxygen, int CarbonMonoxide, int CarbonDioxide
        , int Air, int COCO2, int Efficiency, int COFlue, int StandingPressure, int WorkingPressure, bool SafeToUse)
        {
            await firebase
              .Child("Gas")
              .PostAsync(new Gas()
              {

                  JobRef = JobRef,
                  SafeCard = safeCard,
                  OfficeAddress = officeAddress,
                  SiteAddress = SiteAddress,
                  LandlordAppliance = LandlordAppliance,
                  ServiceInspectionRepair = ServiceInspectionRepair,
                  Type = Type,
                  Model = Model,
                  SerialNumber = SerialNumber,
                  BurnerManufacture = BurnerManufacture,
                  FlueType = FlueType,
                  Operational = Operational,
                  InstallationLine = InstallationLine,
                  Installation = Installation,
                  PipeWork = PipeWork,
                  PipeWorkSleeved = PipeWorkSleeved,
                  PipeWorkColour = PipeWorkColour,
                  Flue = Flue,
                  FlueTermination = FlueTermination,
                  Tightness = Tightness,
                  PipeworkBonded = PipeworkBonded,
                  EmergencyValves = EmergencyValves,
                  ValveHandles = ValveHandles,
                  ValvesPosition = ValvesPosition,
                  CombutionMaterials = CombutionMaterials,
                  FlowInletActual = FlowInletActual,
                  FlowInletRequired = FlowInletRequired,
                  FlowExtractActual = FlowExtractActual,
                  FlowExtractRequired = FlowExtractRequired,
                  VentsClear = VentsClear,
                  FansOperational = FansOperational,
                  Faults = Faults,
                  Actions = Actions,
                  FlueFlowSatisfactory = FlueFlowSatisfactory,
                  SpillageTest = SpillageTest,
                  AirGasSwitch = AirGasSwitch,
                  FlameDevices = FlameDevices,
                  BurnerLockout = BurnerLockout,
                  TempLimit = TempLimit,
                  HeatInput = HeatInput,
                  GasBurnerPressureRequired = GasBurnerPressureRequired,
                  GasBurnerPressureMeasure = GasBurnerPressureMeasure,
                  GasRating = GasRating,
                  AirGasRatio = AirGasRatio,
                  NetFlueTemp = NetFlueTemp,
                  Oxygen = Oxygen,
                  CarbonMonoxide = CarbonMonoxide,
                  CarbonDioxide = CarbonDioxide,
                  Air = Air,
                  COCO2 = COCO2,
                  Efficiency = Efficiency,
                  COFlue = COFlue,
                  StandingPressure = StandingPressure,
                  WorkingPressure = WorkingPressure,
                  SafeToUse = SafeToUse

              });


            await jobsFirebase.AddJob(JobRef);

        }


        public async Task<List<Gas>> GetAllGasByJobRef(int JobRef)
        {
            List<Gas> GasAssets = await GetAllGasAsync();

            await firebase
            .Child("Gas")
            .OnceAsync<Gas>();

            return GasAssets.Where(a => a.JobRef == JobRef).ToList();
        }

        public async Task<Gas> GetAllGasBySerialNum(string serialNum)
        {
            List<Gas> GasAssets = await GetAllGasAsync();

            await firebase
            .Child("Gas")
            .OnceAsync<Gas>();

            return GasAssets.Where(a => a.SerialNumber == serialNum).FirstOrDefault();
        }



        public async Task<List<Gas>> GetAllGasAsync()
        {
            List<Gas> GasAssets = (await firebase
              .Child("Gas")
              .OnceAsync<Gas>()).Select(item => new Gas
              {
                  JobRef = item.Object.JobRef,
                  SafeCard = item.Object.SafeCard,
                  OfficeAddress = item.Object.OfficeAddress,
                  SiteAddress = item.Object.SiteAddress,
                  LandlordAppliance = item.Object.LandlordAppliance,
                  ServiceInspectionRepair = item.Object.ServiceInspectionRepair,
                  Type = item.Object.Type,
                  Model = item.Object.Model,
                  SerialNumber = item.Object.SerialNumber,
                  BurnerManufacture = item.Object.BurnerManufacture,
                  FlueType = item.Object.FlueType,
                  Operational = item.Object.Operational,
                  InstallationLine = item.Object.InstallationLine,
                  Installation = item.Object.Installation,
                  PipeWork = item.Object.PipeWork,
                  PipeWorkSleeved = item.Object.PipeWorkSleeved,
                  PipeWorkColour = item.Object.PipeWorkColour,
                  Flue = item.Object.Flue,
                  FlueTermination = item.Object.FlueTermination,
                  Tightness = item.Object.Tightness,
                  PipeworkBonded = item.Object.PipeworkBonded,
                  EmergencyValves = item.Object.EmergencyValves,
                  ValveHandles = item.Object.ValveHandles,
                  ValvesPosition = item.Object.ValvesPosition,
                  CombutionMaterials = item.Object.CombutionMaterials,
                  FlowInletActual = item.Object.FlowInletActual,
                  FlowInletRequired = item.Object.FlowInletRequired,
                  FlowExtractActual = item.Object.FlowExtractActual,
                  FlowExtractRequired = item.Object.FlowExtractRequired,
                  VentsClear = item.Object.VentsClear,
                  FansOperational = item.Object.FansOperational,
                  Faults = item.Object.Faults,
                  Actions = item.Object.Actions,
                  FlueFlowSatisfactory = item.Object.FlueFlowSatisfactory,
                  SpillageTest = item.Object.SpillageTest,
                  AirGasSwitch = item.Object.AirGasSwitch,
                  FlameDevices = item.Object.FlameDevices,
                  BurnerLockout = item.Object.BurnerLockout,
                  TempLimit = item.Object.TempLimit,
                  HeatInput = item.Object.HeatInput,
                  GasBurnerPressureRequired = item.Object.GasBurnerPressureRequired,
                  GasBurnerPressureMeasure = item.Object.GasBurnerPressureMeasure,
                  GasRating = item.Object.GasRating,
                  AirGasRatio = item.Object.AirGasRatio,
                  NetFlueTemp = item.Object.NetFlueTemp,
                  Oxygen = item.Object.Oxygen,
                  CarbonMonoxide = item.Object.CarbonMonoxide,
                  CarbonDioxide = item.Object.CarbonDioxide,
                  Air = item.Object.Air,
                  COCO2 = item.Object.COCO2,
                  Efficiency = item.Object.Efficiency,
                  COFlue = item.Object.COFlue,
                  StandingPressure = item.Object.StandingPressure,
                  WorkingPressure = item.Object.WorkingPressure,
                  SafeToUse = item.Object.SafeToUse
              }).ToList();

            return GasAssets;
        }


        public async Task UpdateGas(string Name, int WorkerId, int JobRef, string SiteAddress, string safeCard, string officeAddress
  , bool LandlordAppliance, string ServiceInspectionRepair, string Type, string Model
     , string SerialNumber, string BurnerManufacture, string FlueType, string Operational, string InstallationLine, bool Installation
  , bool PipeWork, bool PipeWorkSleeved, string PipeWorkColour, bool Flue, string FlueTermination, string Tightness
  , bool PipeworkBonded, bool EmergencyValves, bool ValveHandles, bool ValvesPosition, bool CombutionMaterials
  , int FlowInletActual, int FlowInletRequired, int FlowExtractActual, int FlowExtractRequired, bool VentsClear, string FansOperational
  , string Faults, string Actions, string FlueFlowSatisfactory, string SpillageTest, string AirGasSwitch, string FlameDevices
  , int BurnerLockout, bool TempLimit, int HeatInput, int GasBurnerPressureRequired, int GasBurnerPressureMeasure
  , int GasRating, int AirGasRatio, int NetFlueTemp, int Oxygen, int CarbonMonoxide, int CarbonDioxide
  , int Air, int COCO2, int Efficiency, int COFlue, int StandingPressure, int WorkingPressure, bool SafeToUse)
        {



            var toUpdateGas = (await firebase
              .Child("Gas")
              .OnceAsync<Gas>()).Where(a => a.Object.SerialNumber == SerialNumber).FirstOrDefault();

            await firebase
              .Child("Gas")
              .Child(toUpdateGas.Key)
              .PutAsync(new Gas()
              {
                  JobRef = JobRef,
                  SafeCard = safeCard,
                  OfficeAddress = officeAddress,
                  SiteAddress = SiteAddress,
                  LandlordAppliance = LandlordAppliance,
                  ServiceInspectionRepair = ServiceInspectionRepair,
                  Type = Type,
                  Model = Model,
                  SerialNumber = SerialNumber,
                  BurnerManufacture = BurnerManufacture,
                  FlueType = FlueType,
                  Operational = Operational,
                  InstallationLine = InstallationLine,
                  Installation = Installation,
                  PipeWork = PipeWork,
                  PipeWorkSleeved = PipeWorkSleeved,
                  PipeWorkColour = PipeWorkColour,
                  Flue = Flue,
                  FlueTermination = FlueTermination,
                  Tightness = Tightness,
                  PipeworkBonded = PipeworkBonded,
                  EmergencyValves = EmergencyValves,
                  ValveHandles = ValveHandles,
                  ValvesPosition = ValvesPosition,
                  CombutionMaterials = CombutionMaterials,
                  FlowInletActual = FlowInletActual,
                  FlowInletRequired = FlowInletRequired,
                  FlowExtractActual = FlowExtractActual,
                  FlowExtractRequired = FlowExtractRequired,
                  VentsClear = VentsClear,
                  FansOperational = FansOperational,
                  Faults = Faults,
                  Actions = Actions,
                  FlueFlowSatisfactory = FlueFlowSatisfactory,
                  SpillageTest = SpillageTest,
                  AirGasSwitch = AirGasSwitch,
                  FlameDevices = FlameDevices,
                  BurnerLockout = BurnerLockout,
                  TempLimit = TempLimit,
                  HeatInput = HeatInput,
                  GasBurnerPressureRequired = GasBurnerPressureRequired,
                  GasBurnerPressureMeasure = GasBurnerPressureMeasure,
                  GasRating = GasRating,
                  AirGasRatio = AirGasRatio,
                  NetFlueTemp = NetFlueTemp,
                  Oxygen = Oxygen,
                  CarbonMonoxide = CarbonMonoxide,
                  CarbonDioxide = CarbonDioxide,
                  Air = Air,
                  COCO2 = COCO2,
                  Efficiency = Efficiency,
                  COFlue = COFlue,
                  StandingPressure = StandingPressure,
                  WorkingPressure = WorkingPressure,
                  SafeToUse = SafeToUse
              });
        }


        public async Task DeleteGasByJobRef(int jobRef)
        {


            var toDeleteGas = (await firebase
              .Child("Gas")
              .OnceAsync<Gas>()).Where(a => a.Object.JobRef == jobRef).ToList();
            foreach (var gas in toDeleteGas)
            {
                await firebase.Child("Gas").Child(gas.Key).DeleteAsync();
            }

        }

        public async Task DeleteGasBySerialNumber(string serialNumber)
        {

            var toDeleteGas = (await firebase
              .Child("Gas")
              .OnceAsync<Gas>()).Where(a => a.Object.SerialNumber == serialNumber).FirstOrDefault();
            await firebase.Child("Gas").Child(toDeleteGas.Key).DeleteAsync();

        }


    }
}
