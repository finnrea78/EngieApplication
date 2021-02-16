using EngieApplication.FirebaseInteraction;
using EngieApplication.Models;
using EngieApplication.Services;
using EngieApplication.WorkerPages;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EngieApplication.ViewModels
{

    public class SendPDFViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Creator: Joe Lewis
        /// 
        /// View Model for sending a PDF table of the assets associated with a job
        /// This is binded to SendAsPDF
        /// The code uses the job reference to find assets associated with it stores them in a list
        /// this is then converted into a data table and then output as aa PDF
        /// 
        /// </summary>


        /// This should have been completed by Aaron shaote who dropped out hench why it is last minuete
        /// 


        PageService pageService = new PageService();
        string InputJobRef;
        string getEmail;

        public SendPDFViewModel(PageService page)
        {
            //sendPDFCommand = new Command(startPDFCreation);

            //Run this on button clicked
            ButtonClick = new Command(async () => await ButtonClickCommandAsync());
        }

        public Command sendPDFCommand
        {
            get;
        }

        public Command ButtonClick { get; }

        async Task ButtonClickCommandAsync()
        {
            //Create tables from the job reference
            await CreateTables(inputJobRef);
        }

        public String inputJobRef
        {
            get { return InputJobRef; }
            set
            {
                InputJobRef = value;
                INotifyPropertyChanged();
            }
        }

        public string inputEmail
        {
            get { return getEmail; }
            set
            {
                getEmail = value;
                INotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void INotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public async Task CreateTables(String jobref)
        {
            //Connect to databases for each asset type
            GasFirebaseHelper gasFirebaseHelper = new GasFirebaseHelper();
            RCDFirebaseHelper rcdFirebaseHelper = new RCDFirebaseHelper();
            LightingFirebaseHelper lightingFirebaseHelper = new LightingFirebaseHelper();

            //List creation for all assets associated to the job reference
            List<Gas> gasAssets = await gasFirebaseHelper.GetAllGasByJobRef(Int32.Parse(jobref));
            List<Lighting> lightingAssets = await lightingFirebaseHelper.GetAllLightingByJobRef(Int32.Parse(jobref));
            List<RCD> rcdAssets = await rcdFirebaseHelper.GetAllRCDsByJobRef(Int32.Parse(jobref));

            //Table Creations

            //Gas Table
            DataTable gastable = new DataTable();
            gastable.Columns.AddRange(new DataColumn[54] {
                new DataColumn("SafeCard"),
                new DataColumn("Office Address"),
                new DataColumn("Site Address"),
                new DataColumn("Landlord Appliance"),
                new DataColumn("Service Inspection Repair"),
                new DataColumn("Type"),
                new DataColumn("Model"),
                new DataColumn("Serial Number"),
                new DataColumn("Burner Manufacture"),
                new DataColumn("Flue Type"),
                new DataColumn("Operational"),
                new DataColumn("Installation Line"),
                new DataColumn("Installation"),
                new DataColumn("Pipework"),
                new DataColumn("Pipework Sleeved"),
                new DataColumn("Pipework Colour"),
                new DataColumn("Flue"),
                new DataColumn("Flue Termination"),
                new DataColumn("Tightness"),
                new DataColumn("Pipework Bonded"),
                new DataColumn("Emergency Valves"),
                new DataColumn("Valve Handles"),
                new DataColumn("Valves Position"),
                new DataColumn("Combution Maaterials"),
                new DataColumn("Flow In Let Actual"),
                new DataColumn("Flow In Let Required"),
                new DataColumn("Flow Extract Actual"),
                new DataColumn("Flow Extract Required"),
                new DataColumn("Vents Clear"),
                new DataColumn("Fans Operational"),
                new DataColumn("Faults"),
                new DataColumn("Actions"),
                new DataColumn("Flue Flow Satisfactory"),
                new DataColumn("Spillage Test"),
                new DataColumn("Air Gas Switch"),
                new DataColumn("Flame Devices"),
                new DataColumn("Burner Lockout"),
                new DataColumn("Temp Limit"),
                new DataColumn("Heat Input"),
                new DataColumn("Gas Burner Pressure Required"),
                new DataColumn("Gas Burner Pressure Measured"),
                new DataColumn("Gas Rating"),
                new DataColumn("Air Gas Ratio"),
                new DataColumn("Net Flue Temp"),
                new DataColumn("Oxygen"),
                new DataColumn("Carbon Monoxide"),
                new DataColumn("Carbon Dioxide"),
                new DataColumn("Air"),
                new DataColumn("COCO2"),
                new DataColumn("Efficiency"),
                new DataColumn("COFlue"),
                new DataColumn("Standing Pressure"),
                new DataColumn("Working Pressure"),
                new DataColumn("Safe To Use"),
            });

            //RCD Table

            DataTable rcdTable = new DataTable();
            rcdTable.Columns.AddRange(new DataColumn[9]
            {
                new DataColumn("Name"),
                new DataColumn("Worker ID"),
                new DataColumn("Site Address"),
                new DataColumn("Date"),
                new DataColumn("Switch Board Reference"),
                new DataColumn("Circuit Reference"),
                new DataColumn("Functional Test"),
                new DataColumn("Annual Service X1"),
                new DataColumn("Annual Service X5"),

            });

            //Lighting Table
            DataTable lightingTable = new DataTable();
            lightingTable.Columns.AddRange(new DataColumn[66]
            {
                new DataColumn("Name"),
                new DataColumn("Address"),
                new DataColumn("Postcode"),
                new DataColumn("Tel No"),
                new DataColumn("ID"),
                new DataColumn("Engineers Name"),
                new DataColumn("RPC"),
                new DataColumn("Office Address"),
                new DataColumn("Office Postcode"),
                new DataColumn("Office Tel No"),
                new DataColumn("Responsible Person"),
                new DataColumn("System Manufacturer"),
                new DataColumn("Manufacturer Tel No"),
                new DataColumn("Responsible Engineer"),
                new DataColumn("Engineer Tel No"),
                new DataColumn("Commision Date"),
                new DataColumn("Non Maintained"),
                new DataColumn("Non Maintained LMS"),
                new DataColumn("Maintained"),
                new DataColumn("Others"),
                new DataColumn("Hours"),
                new DataColumn("Is Automatic"),
                new DataColumn("Add Mod 1"),
                new DataColumn("Add Mod 2"),
                new DataColumn("Add Mod 3"),
                new DataColumn("Add Mod 4"),
                new DataColumn("Add Mod 5"),
                new DataColumn("Add Mod 6"),
                new DataColumn("Signature"),
                new DataColumn("Date"),
                new DataColumn("Site Address"),
                new DataColumn("Q11"),
                new DataColumn("Q12"),
                new DataColumn("Q13"),
                new DataColumn("Q14"),
                new DataColumn("Q15"),
                new DataColumn("Q16"),
                new DataColumn("Q21"),
                new DataColumn("Q22"),
                new DataColumn("Q23"),
                new DataColumn("Q24"),
                new DataColumn("Q25"),
                new DataColumn("Q26"),
                new DataColumn("Q27"),
                new DataColumn("Q31"),
                new DataColumn("Q32"),
                new DataColumn("Q33"),
                new DataColumn("Q34"),
                new DataColumn("Q41"),
                new DataColumn("Q42"),
                new DataColumn("Q43"),
                new DataColumn("Q44"),
                new DataColumn("Q45"),
                new DataColumn("Q51"),
                new DataColumn("Q61"),
                new DataColumn("Q62"),
                new DataColumn("Q63"),
                new DataColumn("Q64"),
                new DataColumn("Q65"),
                new DataColumn("Q66"),
                new DataColumn("Q67"),
                new DataColumn("Q68"),
                new DataColumn("Q69"),
                new DataColumn("Q610"),
                new DataColumn("Results"),
                new DataColumn("Comments"),
            });

            //Table Insertions

            //Gas Table
            foreach (Gas asset in gasAssets)
            {
                gastable.Rows.Add(asset.SafeCard, asset.OfficeAddress, asset.SiteAddress, asset.LandlordAppliance, asset.ServiceInspectionRepair, asset.Type,
                    asset.Model, asset.SerialNumber, asset.BurnerManufacture, asset.FlueType, asset.Operational, asset.InstallationLine, asset.Installation,
                    asset.PipeWork, asset.PipeWorkSleeved, asset.PipeWorkColour, asset.Flue, asset.FlueTermination, asset.Tightness, asset.PipeworkBonded,
                    asset.EmergencyValves, asset.ValveHandles, asset.ValvesPosition, asset.CombutionMaterials, asset.FlowInletActual, asset.FlowInletRequired,
                    asset.FlowExtractActual, asset.FlowExtractRequired, asset.VentsClear, asset.FansOperational, asset.Faults, asset.Actions, asset.FlueFlowSatisfactory,
                    asset.SpillageTest, asset.AirGasSwitch, asset.FlameDevices, asset.BurnerLockout, asset.TempLimit, asset.HeatInput, asset.GasBurnerPressureRequired,
                    asset.GasBurnerPressureMeasure, asset.GasRating, asset.AirGasRatio, asset.NetFlueTemp, asset.Oxygen, asset.CarbonMonoxide, asset.CarbonDioxide, asset.Air,
                    asset.COCO2, asset.Efficiency, asset.COFlue, asset.StandingPressure, asset.WorkingPressure, asset.SafeToUse);
            }

            //RCD Table
            foreach (RCD asset in rcdAssets)
            {
                rcdTable.Rows.Add(asset.Name, asset.WorkerId, asset.SiteAddress, asset.Date, asset.SwitchBoardReferance, asset.CircuitReference, asset.FunctionalTest,
                    asset.AnnualServiceX1, asset.AnnualServiceX5);
            }

            //Lighting Table
            foreach (Lighting asset in lightingAssets)
            {
                lightingTable.Rows.Add(asset.Name, asset.Adress, asset.Postcode, asset.TelNo, asset.ID, asset.EngineersName, asset.RPC, asset.OfficeAdress, asset.OfficePostcode,
                    asset.OfficeTelNo, asset.ResponsiblePerson, asset.SystemManufacturer, asset.ManufacturerTelNo, asset.ResponsibleEngineer, asset.EngineersTelNo,
                    asset.ComissionDate, asset.Nonmaintained, asset.NonmaintainedLMS, asset.Maintained, asset.Others, asset.Hours, asset.IsAutomatic, asset.AddMod1, asset.AddMod2,
                    asset.AddMod3, asset.AddMod4, asset.AddMod5, asset.AddMod6, asset.Signature, asset.Date, asset.SiteAdress, asset.Q11, asset.Q12, asset.Q13, asset.Q14, asset.Q15,
                    asset.Q16, asset.Q21, asset.Q22, asset.Q23, asset.Q24, asset.Q25, asset.Q26, asset.Q27, asset.Q31, asset.Q32, asset.Q33, asset.Q34, asset.Q41, asset.Q42, asset.Q43,
                    asset.Q44, asset.Q45, asset.Q51, asset.Q61, asset.Q62, asset.Q63, asset.Q64, asset.Q65, asset.Q66, asset.Q67, asset.Q68, asset.Q69, asset.Q610, asset.Results,
                    asset.Comments);
            }

            //Email sends

            //Gas Table
            string filename = "EngiePDF_Gas_" + DateTime.Now.ToString("dd") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("yyyy") + ".pdf";
            await convertToPDFAsync(gastable, filename);
            //RCD Table
            string filename2 = "EngiePDF_RCD_" + DateTime.Now.ToString("dd") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("yyyy") + ".pdf";
            await convertToPDFAsync(rcdTable, filename2);
            //Lighting Table
            string filename3 = "EngiePDF_Lighting_" + DateTime.Now.ToString("dd") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("yyyy") + ".pdf";
            await convertToPDFAsync(lightingTable, filename3);

            await pageService.PushAsync(new WorkerMainPage());


        }

        private async Task convertToPDFAsync(DataTable table, String filename)
        {
            using (MemoryStream mem = new MemoryStream())
            {
                using (PdfDocument document = new PdfDocument())
                {
                    PdfPage page = document.Pages.Add();
                    PdfGrid grid = new PdfGrid();
                    grid.DataSource = table;
                    //Output the datatable to the page
                    grid.Draw(page, new PointF(10, 10));
                    //Assign the document to the memory stream
                    document.Save(mem);
                    document.Close(true);
                    mem.Position = 0;
                }


                await sendEmailAsync(mem, filename);
            }

        }

        private async Task sendEmailAsync(Stream memory, string filename)
        {
            Person sender = (Person)Application.Current.Properties["LoggedIn"];
            string from = "engie27345@gmail.com";
            string receiver = inputEmail;
            if (receiver.Equals(null))
            {
                receiver = sender.Email;
            }
            string subject = "PDF Request";
            string body = "Attached are the PDFs requested through the ENGIE Application.";
            using (Attachment attachment = new Attachment(memory, filename, MediaTypeNames.Application.Pdf))
            {
                using (MailMessage mail = new MailMessage(from, receiver, subject, body))
                {
                    mail.Attachments.Add(attachment);
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential networkCredential = new NetworkCredential();
                    networkCredential.UserName = "engie27345";
                    networkCredential.Password = "Pa$$w0rd1!";
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.Send(mail);



                }
            }

            await pageService.DisplayAlert("Success", "PDF file: " + filename + " sent", "OK");
        }
    }
}