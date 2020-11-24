using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesIspProject.Models
{
    public enum Qualification
    {
        ACCA, CA, CIMA, SAAA
    }
    public enum EmployeeType
    {
        Secretary,
        Director,
        [Display(Name = "Accounting Officer")]
        AccountingOfficer
    }
    public class Employee
    {
        public int ID { get; set; }       
        [Column(TypeName = "nvarchar(max)")]
        public EmployeeType? EmployeeType { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public Qualification? Qualification { get; set; }

        // FK
        public int ContactDetailID { get; set; }
        public ContactDetail ContactDetail { get; set; }

        // Navigation
        public ICollection<CompanyEmployee> CompanyEmployees { get; set; }

    }
}


