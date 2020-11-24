using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesIspProject.Models
{
    public class CompanyMember
    {
        // PK/FK - Pure Join Table (PJT).
        public int CompanyID { get; set; }
        public int MemberID { get; set; }

        // Navigation
        public Company Company { get; set; }
        public Member Member { get; set; }
    }
}
