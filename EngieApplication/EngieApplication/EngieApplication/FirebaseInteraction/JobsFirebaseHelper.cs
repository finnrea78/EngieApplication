using EngieApplication.Models;
using EngieApplication.Services;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngieApplication.FirebaseInteraction
{
    class JobsFirebaseHelper
    {



        /// <summary>
        /// Creator: Finn Rea
        /// This class is where all communication with the database for Jobs takes place.
        /// It contains all basic CRUD (Create, read, update and delete) functionality 
        /// for Job infomation. 
        /// A Job contains referance to assets contained within a job. 
        /// 
        /// </summary>



        FirebaseClient firebase = new FirebaseClient("https://engie-31a7e-default-rtdb.firebaseio.com/");

        public async Task<List<Job>> GetAllJobsAsync()
        {
            List<Job> Jobs = (await firebase
              .Child("Jobs")
              .OnceAsync<Job>()).Select(item => new Job
              {
                  JobRef = item.Object.JobRef,

                  //WorkerID = item.Object.WorkerID
              }).ToList();

            return Jobs;
        }

        public async Task<Job> GetJobByJobRef(int JobRef)
        {
            List<Job> jobs = await GetAllJobsAsync();

            await firebase
            .Child("Jobs")
            .OnceAsync<Job>();
            return jobs.Where(a => a.JobRef == JobRef).FirstOrDefault();
        }

        public async Task AddJob(int JobRef)
        {

            Job job = await GetJobByJobRef(JobRef);
            QrCode qrCode = new QrCode();

            // Checks to see if the Job already exists 


            if (job == null)
            {
                qrCode.GenerateQR(JobRef.ToString());
                // Generates bar code that will store the jobRef number
                await firebase
                  .Child("Jobs")
                  .PostAsync(new Job() { JobRef = JobRef });
               
            }

        }


        public async Task DeleteJob(int jobRef)
        {
            var toDeleteJob = (await firebase
              .Child("Jobs")
              .OnceAsync<Job>()).Where(a => a.Object.JobRef == jobRef).FirstOrDefault();
            await firebase.Child("Jobs").Child(toDeleteJob.Key).DeleteAsync();


            GasFirebaseHelper gasFirebaseHelper = new GasFirebaseHelper();
            RCDFirebaseHelper rCDFirebaseHelper = new RCDFirebaseHelper();
            LightingFirebaseHelper lightingFirebaseHelper = new LightingFirebaseHelper();


            await gasFirebaseHelper.DeleteGasByJobRef(jobRef);
            await rCDFirebaseHelper.DeleteRCDByJobRef(jobRef);
            await lightingFirebaseHelper.DeleteLightingByJobRef(jobRef);


        }






        // If I had more time I would have implemented methods for linking person whos managing a job to job
        // I didn't get chance to implement this due to time constrains  



        //public async Task AddWorkerToJobAsync(int jobRef, int personID)
        //{
        //    PersonJob personJobExists = await GetLinkedJobWorker(jobRef, personID);


        //    if (personJobExists == null)
        //    {
        //        await firebase
        //             .Child("PersonJob")
        //             .PostAsync(new PersonJob() { JobRef = jobRef, PersonID = personID });
        //    }
        //}

        //public async Task<PersonJob> GetLinkedJobWorker(int jobRef, int personID)
        //{
        //    List<PersonJob> personJobs = await GetAllPersonJob();

        //    await firebase
        //    .Child("PersonJob")
        //    .OnceAsync<PersonJob>();
        //    return personJobs.Where(a => a.JobRef == jobRef && a.PersonID == personID).FirstOrDefault();

        //}

        //public async Task<List<PersonJob>> GetAllPersonJob()
        //{
        //    List<PersonJob> connection = (await firebase
        //      .Child("PersonJob")
        //      .OnceAsync<PersonJob>()).Select(item => new PersonJob
        //      {
        //          JobRef = item.Object.JobRef,
        //          PersonID = item.Object.PersonID,
        //          //WorkerID = item.Object.WorkerID
        //      }).ToList();

        //    return connection;
        //}







    }
}
