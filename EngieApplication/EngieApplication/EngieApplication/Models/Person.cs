using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace EngieApplication
{

    
    public class Person
    {



        /// <summary>
        /// Creator: Finn Rea
        /// Modifications: Denis Kostin
        /// Model of all attriutes required to create a Person/User
        /// Could Have used with initally naming this user
        /// </summary>
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Email{ get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Company { get; set; }
        public bool Admin { get; set; }
       

       
    }
}
