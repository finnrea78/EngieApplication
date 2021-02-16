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
    class RCDFirebaseHelper
    {

        /// <summary>
        /// Creator: Finn Rea
        /// This class is where all communication with the database for RCD asset takes place.
        /// It contains all basic CRUD (Create, read, update and delete) functionality 
        /// for RCD infomation. 
        /// </summary>


        FirebaseClient firebase = new FirebaseClient("https://engie-31a7e-default-rtdb.firebaseio.com/");

        JobsFirebaseHelper jobsFirebase = new JobsFirebaseHelper();

        public async Task AddRCDAsset(string name, int workerId, int jobRef, string siteAddress, string date,
            string switchBoardReferance, string circuitReference, bool functionalTest, int annualServiceX1, int annualServiceX5)
        {
            await firebase
              .Child("RCD")
              .PostAsync(new RCD()
              {
                  Name = name,
                  WorkerId = workerId,
                  JobRef = jobRef,
                  SiteAddress = siteAddress,
                  Date = date,

                  SwitchBoardReferance = switchBoardReferance,
                  CircuitReference = circuitReference,
                  FunctionalTest = functionalTest,
                  AnnualServiceX1 = annualServiceX1,
                  AnnualServiceX5 = annualServiceX5
              });


            await jobsFirebase.AddJob(jobRef);


        }




        public async Task<List<RCD>> GetAllRCDsAsync()
        {
            List<RCD> RCDs = (await firebase
              .Child("RCD")
              .OnceAsync<RCD>()).Select(item => new RCD
              {
                  Name = item.Object.Name,
                  WorkerId = item.Object.WorkerId,
                  JobRef = item.Object.JobRef,
                  SiteAddress = item.Object.SiteAddress,
                  Date = item.Object.Date,
                  SwitchBoardReferance = item.Object.SwitchBoardReferance,
                  CircuitReference = item.Object.CircuitReference,
                  FunctionalTest = item.Object.FunctionalTest,
                  AnnualServiceX1 = item.Object.AnnualServiceX1,
                  AnnualServiceX5 = item.Object.AnnualServiceX5
              }).ToList();

            return RCDs;
        }

        public async Task<List<RCD>> GetAllRCDsByJobRef(int jobRef)
        {
            List<RCD> rCDs = await GetAllRCDsAsync();

            await firebase
            .Child("RCD")
            .OnceAsync<RCD>();
            return rCDs.Where(a => a.JobRef == jobRef).ToList();
        }

        public async Task<RCD> GetAllRCDsBySwitchBoardRef(string switchBoard)
        {
            List<RCD> rCDs = await GetAllRCDsAsync();

            await firebase
            .Child("RCD")
            .OnceAsync<RCD>();
            return rCDs.Where(a => a.SwitchBoardReferance == switchBoard).FirstOrDefault();
        }






        public async Task UpdateRCD(string name, int workerId, int jobRef, string siteAddress, string date,
            string switchBoardReferance, string circuitReference, bool functionalTest, int annualServiceX1, int annualServiceX5)
        {
            var toUpdateRCD = (await firebase
              .Child("RCD")
              .OnceAsync<RCD>()).Where(a => a.Object.SwitchBoardReferance == switchBoardReferance).FirstOrDefault();

            await firebase
              .Child("RCD")
              .Child(toUpdateRCD.Key)
              .PutAsync(new RCD()
              {
                  Name = name,
                  WorkerId = workerId,
                  JobRef = jobRef,
                  SiteAddress = siteAddress,
                  Date = date,
                  SwitchBoardReferance = switchBoardReferance,
                  CircuitReference = circuitReference,
                  FunctionalTest = functionalTest,
                  AnnualServiceX1 = annualServiceX1,
                  AnnualServiceX5 = annualServiceX5
              });
        }



        public async Task DeleteRCDByJobRef(int jobRef)
        {

            //List<Gas> allGastoDelete = await GetAllGasByJobRef(jobRef);


            var toDeleteRCD = (await firebase
              .Child("RCD")
              .OnceAsync<RCD>()).Where(a => a.Object.JobRef == jobRef).ToList();
            foreach (var rcd in toDeleteRCD)
            {
                await firebase.Child("RCD").Child(rcd.Key).DeleteAsync();
            }

        }


        public async Task DeleteRCDBySwitchBoardRef(string switchBoardRef)
        {

            var toDeleteRCD = (await firebase
              .Child("RCD")
              .OnceAsync<RCD>()).Where(a => a.Object.SwitchBoardReferance == switchBoardRef).FirstOrDefault();
            await firebase.Child("RCD").Child(toDeleteRCD.Key).DeleteAsync();

        }







    }
}
