using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EngieApplication
{
    class FireBaseHelper
    {

        /// <summary>
        /// Creator: Finn Rea
        /// Modifications: Denis Kostin
        /// This class is where all communication with the database for accounts takes place.
        /// It contains all basic CRUD (Create, read, update and delete) functionality 
        /// for account infomation. 
        /// 
        /// </summary>



        FirebaseClient firebase = new FirebaseClient("https://engie-31a7e-default-rtdb.firebaseio.com/" );
        
        public async Task<List<Person>> GetAllPersons()
        {
            
             List<Person> people = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Select(item => new Person
              {
                  Name = item.Object.Name,
                  PersonId = item.Object.PersonId,
                  Email = item.Object.Email,
                  Salt = item.Object.Salt,
                  Password = item.Object.Password,
                  PhoneNumber = item.Object.PhoneNumber,
                  Company = item.Object.Company,
                  Admin = item.Object.Admin
              }).ToList();
            return people;
        }

        public async Task AddPerson(int personId, string name, string email, string PhoneNumber, string Password, string Salt, string Company, bool Admin)
        {

            

            await firebase
              .Child("Persons")
              .PostAsync(new Person() { PersonId = personId, Name = name, Email = email, PhoneNumber = PhoneNumber, Password = Password, Salt = Salt, Company = Company, Admin = Admin });


            
        }

        public async Task<Person> GetPerson(string name)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Persons")
              .OnceAsync<Person>();
            return allPersons.Where(a => a.Name == name).FirstOrDefault();
        }

        public async Task<Person> GetPersonEmail(string email)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Persons")
              .OnceAsync<Person>();
            return allPersons.Where(a => a.Email == email).FirstOrDefault();
        }
        public async Task<Person> GetPersonID(int ID)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Persons")
              .OnceAsync<Person>();
            return allPersons.Where(a => a.PersonId == ID).FirstOrDefault();
        }
        public async Task<Person> GetAdmin(bool admin)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Persons")
              .OnceAsync<Person>();
            return allPersons.Where(a => a.Admin == admin).FirstOrDefault();
        }


        public async Task UpdatePerson(int personId, string name, string email, string phone, string company, string Password, string Salt, bool admin)
        {
            var toUpdatePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();

            await firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
              .PutAsync(new Person() { PersonId = personId, Name = name, Email = email, PhoneNumber=phone,Company=company, Password = Password, Salt = Salt, Admin = admin});
        }

        public async Task DeletePerson(int personId)
        {
            var toDeletePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();
            await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

        }
    }
}
