using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesIspProject.Models.CompanyPersons
{
    public class SecretaryVm
    {
        public int ID { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Nationality { get; set; }
        public string IdentityNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public EmployeeType EmployeeType { get; } = EmployeeType.Secretary;
    }
}
