using System;
using System.Collections.Generic;
using System.Text;

namespace EngieApplication.Models
{
    public class Gas
    {
        /// <summary>
        /// Creator: Finn Rea
        /// Model of all attriutes required to create a Gas Asset
        /// </summary>



        public int JobRef { get; set; }
        public string SafeCard { get; set; }
        public string OfficeAddress { get; set; }


        public string SiteAddress { get; set; }
        public bool LandlordAppliance { get; set; }
        public string ServiceInspectionRepair { get; set; }
       
        public string Type { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string BurnerManufacture { get; set; }
        public string FlueType { get; set; }
        public string Operational { get; set; }
        public string InstallationLine { get; set; }
        public bool Installation { get; set; }
        public bool PipeWork { get; set; }
        public bool PipeWorkSleeved { get; set; }
        public string PipeWorkColour { get; set; }
        public bool Flue { get; set; }
        public string FlueTermination { get; set; }
        public string Tightness { get; set; }
        public bool PipeworkBonded { get; set; }
        public bool EmergencyValves { get; set; }
        public bool ValveHandles { get; set; }
        public bool ValvesPosition { get; set; }
        public bool CombutionMaterials { get; set; }
        public int FlowInletActual { get; set; }
        public int FlowInletRequired { get; set; }
        public int FlowExtractActual { get; set; }
        public int FlowExtractRequired { get; set; }
        public bool VentsClear { get; set; }
        public string FansOperational { get; set; }
        public string Faults { get; set; }
        public string Actions { get; set; }
        public string FlueFlowSatisfactory { get; set; }
        public string SpillageTest { get; set; }
        public string AirGasSwitch { get; set; }
        public string FlameDevices { get; set; }
        public int BurnerLockout { get; set; }
        public bool TempLimit { get; set; }
        public int HeatInput { get; set; }
        public int GasBurnerPressureRequired { get; set; }
        public int GasBurnerPressureMeasure { get; set; }
        public int GasRating { get; set; }
        public int AirGasRatio { get; set; }
        public int NetFlueTemp { get; set; }
        public int Oxygen { get; set; }
        public int CarbonMonoxide { get; set; }
        public int CarbonDioxide { get; set; }
        public int Air { get; set; }
        public int COCO2 { get; set; }
        public int Efficiency { get; set; }
        public int COFlue { get; set; }
        public int StandingPressure { get; set; }
        public int WorkingPressure { get; set; }
        public bool SafeToUse { get; set; }























    }
}
