using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesIspProject.Models.CompanyPersons
{
    public class AccountingOfficerVm
    {
        public int ID { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public Qualification Qualification { get; set; }
        public string PhysicalAddress { get; set; }


    }
}
