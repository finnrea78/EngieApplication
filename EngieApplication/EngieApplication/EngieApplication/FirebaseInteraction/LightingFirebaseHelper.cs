using EngieApplication.Models;
using EngieApplication.Services;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Mobile.Forms;

namespace EngieApplication.FirebaseInteraction
{
    class LightingFirebaseHelper
    {



        /// <summary>
        /// Creator: Finn Rea, Kacper Stawski (AddLightingAsset)
        /// This class is where all communication with the database for Lighting asset takes place.
        /// It contains all basic CRUD (Create, read, update and delete) functionality 
        /// for Lighting infomation. 
        /// </summary>




        FirebaseClient firebase = new FirebaseClient("https://engie-31a7e-default-rtdb.firebaseio.com/");

        JobsFirebaseHelper jobsFirebase = new JobsFirebaseHelper();

        
        public async Task AddLightingAsset(string ID, string name, string adress, string postcode, string telno, int jobref, string engineersname, string rpc,
            string officeadress, string officepostcode, string officetelno, string responsibleperson, string systemmanufacturer, string
            manufacturertelno, string responsibleengineer, string engineerstelno, string comissiondate, string nonmaintained, string nonmaintainedlms,
            string maintained, string others, int hours, bool isautomatic, string addmod1, string addmod2, string addmod3, string addmod4,
            string addmod5, string addmod6, string signature, string date, string siteadress, string q11, string q12, string q13, string q14,
            string q15, string q16, string q21, string q22, string q23, string q24, string q25, string q26, string q27, string q31, string q32, string q33,
            string q34, string q41, string q42, string q43, string q44, string q45, string q51, string q61, string q62, string q63, string q64,
            string q65, string q66, string q67, string q68, string q69, string q610, string results, string comments)
        {
            await firebase
              .Child("Lighting")
              .PostAsync(new Lighting()
              {
                  ID = ID,
                  Name = name,
                  Adress = adress,
                  Postcode = postcode,
                  TelNo = telno,
                  JobRef = jobref,
                  EngineersName = engineersname,
                  RPC = rpc,
                  OfficeAdress = officeadress,
                  OfficePostcode = officepostcode,
                  OfficeTelNo = officetelno,
                  ResponsiblePerson = responsibleperson,
                  SystemManufacturer = systemmanufacturer,
                  ManufacturerTelNo = manufacturertelno,
                  ResponsibleEngineer = responsibleengineer,
                  EngineersTelNo = engineerstelno,
                  ComissionDate = comissiondate,
                  Nonmaintained = nonmaintained,
                  NonmaintainedLMS = nonmaintainedlms,
                  Maintained = maintained,
                  Others = others,
                  Hours = hours,
                  IsAutomatic = isautomatic,
                  AddMod1 = addmod1,
                  AddMod2 = addmod2,
                  AddMod3 = addmod3,
                  AddMod4 = addmod4,
                  AddMod5 = addmod5,
                  AddMod6 = addmod6,
                  Signature = signature,
                  Date = date,
                  SiteAdress = siteadress,
                  Q11 = q11,
                  Q12 = q12,
                  Q13 = q13,
                  Q14 = q14,
                  Q15 = q15,
                  Q16 = q16,
                  Q21 = q21,
                  Q22 = q22,
                  Q23 = q23,
                  Q24 = q24,
                  Q25 = q25,
                  Q26 = q26,
                  Q27 = q27,
                  Q31 = q31,
                  Q32 = q32,
                  Q33 = q33,
                  Q34 = q34,
                  Q41 = q41,
                  Q42 = q42,
                  Q43 = q43,
                  Q44 = q44,
                  Q45 = q45,
                  Q51 = q51,
                  Q61 = q61,
                  Q62 = q62,
                  Q63 = q63,
                  Q64 = q64,
                  Q65 = q65,
                  Q66 = q66,
                  Q67 = q67,
                  Q68 = q68,
                  Q69 = q69,
                  Q610 = q610,
                  Results = results,
                  Comments = comments

              });



            await jobsFirebase.AddJob(jobref);
        }



        public async Task<List<Lighting>> GetAllLightingAsync()
        {
            List<Lighting> Lightings = (await firebase
              .Child("Lighting")
              .OnceAsync<Lighting>()).Select(item => new Lighting
              {
                  Name = item.Object.Name,
                  Adress = item.Object.Adress,
                  Postcode = item.Object.Postcode,
                  TelNo = item.Object.TelNo,
                  EngineersName = item.Object.EngineersName,
                  JobRef = item.Object.JobRef,
                  ID = item.Object.ID,
                  RPC = item.Object.RPC,
                  OfficeAdress = item.Object.OfficeAdress,
                  OfficePostcode = item.Object.OfficePostcode,
                  OfficeTelNo = item.Object.OfficeTelNo,
                  ResponsiblePerson = item.Object.ResponsiblePerson,
                  SystemManufacturer = item.Object.SystemManufacturer,
                  ManufacturerTelNo = item.Object.ManufacturerTelNo,
                  ResponsibleEngineer = item.Object.ResponsibleEngineer,
                  EngineersTelNo = item.Object.EngineersTelNo,
                  ComissionDate = item.Object.ComissionDate,
                  Nonmaintained = item.Object.Nonmaintained,
                  NonmaintainedLMS = item.Object.NonmaintainedLMS,
                  Maintained = item.Object.Maintained,
                  Others = item.Object.Others,
                  Hours = item.Object.Hours,
                  IsAutomatic = item.Object.IsAutomatic,
                  AddMod1 = item.Object.AddMod1,
                  AddMod2 = item.Object.AddMod2,
                  AddMod3 = item.Object.AddMod3,
                  AddMod4 = item.Object.AddMod4,
                  AddMod5 = item.Object.AddMod5,
                  AddMod6 = item.Object.AddMod6,
                  Signature = item.Object.Signature,
                  Date = item.Object.Date,
                  SiteAdress = item.Object.SiteAdress,
                  Q11 = item.Object.Q11,
                  Q12 = item.Object.Q12,
                  Q13 = item.Object.Q13,
                  Q14 = item.Object.Q14,
                  Q15 = item.Object.Q15,
                  Q16 = item.Object.Q16,
                  Q21 = item.Object.Q21,
                  Q22 = item.Object.Q22,
                  Q23 = item.Object.Q23,
                  Q24 = item.Object.Q24,
                  Q25 = item.Object.Q25,
                  Q26 = item.Object.Q26,
                  Q27 = item.Object.Q27,
                  Q31 = item.Object.Q31,
                  Q32 = item.Object.Q32,
                  Q33 = item.Object.Q33,
                  Q34 = item.Object.Q34,
                  Q41 = item.Object.Q41,
                  Q42 = item.Object.Q42,
                  Q43 = item.Object.Q43,
                  Q44 = item.Object.Q44,
                  Q45 = item.Object.Q45,
                  Q51 = item.Object.Q51,
                  Q61 = item.Object.Q61,
                  Q62 = item.Object.Q62,
                  Q63 = item.Object.Q63,
                  Q64 = item.Object.Q64,
                  Q65 = item.Object.Q65,
                  Q66 = item.Object.Q66,
                  Q67 = item.Object.Q67,
                  Q68 = item.Object.Q68,
                  Q69 = item.Object.Q69,
                  Q610 = item.Object.Q610,
                  Results = item.Object.Results,
                  Comments = item.Object.Comments

              }).ToList();

            return Lightings;
        }

        public async Task<List<Lighting>> GetAllLightingByJobRef(int JobRef)
        {
            List<Lighting> Lightings = await GetAllLightingAsync();

            await firebase
            .Child("Lighting")
            .OnceAsync<Lighting>();
            return Lightings.Where(a => a.JobRef == JobRef).ToList();
        }

        public async Task<Lighting> GetAllLightingByID(string Id)
        {
            List<Lighting> Lightings = await GetAllLightingAsync();

            await firebase
            .Child("Lighting")
            .OnceAsync<Lighting>();
            return Lightings.Where(a => a.ID == Id).FirstOrDefault();
        }









        public async Task DeleteLightingByJobRef(int jobRef)
        {
            var toDeleteLighting = (await firebase
              .Child("Lighting")
              .OnceAsync<Lighting>()).Where(a => a.Object.JobRef == jobRef).ToList();
            foreach (var lighting in toDeleteLighting)
            {
                await firebase.Child("Lighting").Child(lighting.Key).DeleteAsync();
            }

        }



        public async Task DeleteLightingByID(string Id)
        {

            var toDeleteLighting = (await firebase
              .Child("Lighting")
              .OnceAsync<Lighting>()).Where(a => a.Object.ID == Id).FirstOrDefault();
            await firebase.Child("Lighting").Child(toDeleteLighting.Key).DeleteAsync();

        }



        public async Task UpdateLightingAsset(string ID, string name, string adress, string postcode, string telno, int jobref, string engineersname, string rpc,
            string officeadress, string officepostcode, string officetelno, string responsibleperson, string systemmanufacturer, string
            manufacturertelno, string responsibleengineer, string engineerstelno, string comissiondate, string nonmaintained, string nonmaintainedlms,
            string maintained, string others, int hours, bool isautomatic, string addmod1, string addmod2, string addmod3, string addmod4,
            string addmod5, string addmod6, string signature, string date, string siteadress, string q11, string q12, string q13, string q14,
            string q15, string q16, string q21, string q22, string q23, string q24, string q25, string q26, string q27, string q31, string q32, string q33,
            string q34, string q41, string q42, string q43, string q44, string q45, string q51, string q61, string q62, string q63, string q64,
            string q65, string q66, string q67, string q68, string q69, string q610, string results, string comments)
        {


            var toUpdateGas = (await firebase
              .Child("Lighting")
              .OnceAsync<Lighting>()).Where(a => a.Object.ID == ID).FirstOrDefault();

            await firebase
              .Child("Lighting")
              .Child(toUpdateGas.Key)
              .PutAsync(new Lighting()
              {
                  ID = ID,
                  Name = name,
                  Adress = adress,
                  Postcode = postcode,
                  TelNo = telno,
                  JobRef = jobref,
                  EngineersName = engineersname,
                  RPC = rpc,
                  OfficeAdress = officeadress,
                  OfficePostcode = officepostcode,
                  OfficeTelNo = officetelno,
                  ResponsiblePerson = responsibleperson,
                  SystemManufacturer = systemmanufacturer,
                  ManufacturerTelNo = manufacturertelno,
                  ResponsibleEngineer = responsibleengineer,
                  EngineersTelNo = engineerstelno,
                  ComissionDate = comissiondate,
                  Nonmaintained = nonmaintained,
                  NonmaintainedLMS = nonmaintainedlms,
                  Maintained = maintained,
                  Others = others,
                  Hours = hours,
                  IsAutomatic = isautomatic,
                  AddMod1 = addmod1,
                  AddMod2 = addmod2,
                  AddMod3 = addmod3,
                  AddMod4 = addmod4,
                  AddMod5 = addmod5,
                  AddMod6 = addmod6,
                  Signature = signature,
                  Date = date,
                  SiteAdress = siteadress,
                  Q11 = q11,
                  Q12 = q12,
                  Q13 = q13,
                  Q14 = q14,
                  Q15 = q15,
                  Q16 = q16,
                  Q21 = q21,
                  Q22 = q22,
                  Q23 = q23,
                  Q24 = q24,
                  Q25 = q25,
                  Q26 = q26,
                  Q27 = q27,
                  Q31 = q31,
                  Q32 = q32,
                  Q33 = q33,
                  Q34 = q34,
                  Q41 = q41,
                  Q42 = q42,
                  Q43 = q43,
                  Q44 = q44,
                  Q45 = q45,
                  Q51 = q51,
                  Q61 = q61,
                  Q62 = q62,
                  Q63 = q63,
                  Q64 = q64,
                  Q65 = q65,
                  Q66 = q66,
                  Q67 = q67,
                  Q68 = q68,
                  Q69 = q69,
                  Q610 = q610,
                  Results = results,
                  Comments = comments
              });


        }
    }
}
