using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesIspProject.Models
{
    public class CompanyEmployee
    {
        // PK - FK
        public int CompanyID { get; set; }
        public int EmployeeID { get; set; }

        // Navigation properties
        // An employee type record is for one students and one course'
        public Company Company { get; set; }
        public Employee Employee { get; set; }
    }
}
