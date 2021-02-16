using System;
using System.Collections.Generic;
using System.Text;

namespace EngieApplication.Models
{
    public class Job
    {
        /// <summary>
        /// Creator: Finn Rea
        /// Model of all attriutes required to create a Job
        /// The JobRef is link in all assets like a many to one relation
        /// </summary>
        public int JobRef { get; set; }
        
        //public int WorkerID { get; set; }

    }
}
