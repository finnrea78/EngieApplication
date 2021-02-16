using System;
using System.Collections.Generic;
using System.Text;

namespace EngieApplication.Models
{
    public class RCD
    {

        /// <summary>
        /// Creator: Finn Rea
        /// Model of all attriutes required to create a RCD Asset
        /// </summary>
        public string Name {get;set;}
        public int WorkerId { get; set; }
        public int JobRef { get; set; }
        public string SiteAddress { get; set; }
        public string Date {get;set;}
       
        public string SwitchBoardReferance { get; set; }
        public string CircuitReference { get; set; }
        public bool FunctionalTest { get; set; }
        public int AnnualServiceX1 { get; set; }
        public int AnnualServiceX5 { get; set; }



    }
}
