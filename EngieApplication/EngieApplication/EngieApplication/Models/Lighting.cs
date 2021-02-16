using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace EngieApplication.Models
{
    public class Lighting
    {
        /// <summary>
        /// Creator: Kacper Stawski
        /// Model of all attriutes required to create a Lighting Asset
        /// </summary>
        /// 
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Postcode { get; set; }
        public string TelNo { get; set; }
        public int JobRef { get; set; }
        public string ID { get; set; }

        public string EngineersName { get; set; }
        public string RPC { get; set; }
        public string OfficeAdress { get; set; }
        public string OfficePostcode { get; set; }
        public string OfficeTelNo { get; set; }

        public string ResponsiblePerson { get; set; }

        public string SystemManufacturer { get; set; }
        public string ManufacturerTelNo { get; set; }
        public string ResponsibleEngineer { get; set; }
        public string EngineersTelNo { get; set; }

        public string ComissionDate { get; set; }

        public string Nonmaintained { get; set; }
        //Non-maintained luminaires maintained signs
        public string NonmaintainedLMS { get; set; }
        public string Maintained { get; set; }
        public string Others { get; set; }

        public int Hours;
        public bool IsAutomatic { get; set; }

        public String AddMod1 { get; set; }
        public String AddMod2 { get; set; }
        public String AddMod3 { get; set; }
        public String AddMod4 { get; set; }
        public String AddMod5 { get; set; }
        public String AddMod6 { get; set; }

        public String Signature { get; set; }
        public String Date { get; set; }

        public string SiteAdress { get; set; }

        //Question 1.1 e.g.
        public string Q11 { get; set; }
        public string Q12 { get; set; }
        public string Q13 { get; set; }
        public string Q14 { get; set; }
        public string Q15 { get; set; }
        public string Q16 { get; set; }

        public string Q21 { get; set; }
        public string Q22 { get; set; }
        public string Q23 { get; set; }
        public string Q24 { get; set; }
        public string Q25 { get; set; }
        public string Q26 { get; set; }
        public string Q27 { get; set; }

        public string Q31 { get; set; }
        public string Q32 { get; set; }
        public string Q33 { get; set; }
        public string Q34 { get; set; }

        public string Q41 { get; set; }
        public string Q42 { get; set; }
        public string Q43 { get; set; }
        public string Q44 { get; set; }
        public string Q45 { get; set; }

        public string Q51 { get; set; }

        public string Q61 { get; set; }
        public string Q62 { get; set; }
        public string Q63 { get; set; }
        public string Q64 { get; set; }
        public string Q65 { get; set; }
        public string Q66 { get; set; }
        public string Q67 { get; set; }
        public string Q68 { get; set; }
        public string Q69 { get; set; }
        public string Q610 { get; set; }
        public string Results { get; set; }
        public string Comments { get; set; }


    }
}
