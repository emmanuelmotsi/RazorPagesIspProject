using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesIspProject.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string Occupation { get; set; }
        public int? SharesTaken { get; set; } // for subcriber
        [Column(TypeName = "nvarchar(max)")]
        public string Contribution { get; set; } // to pbc assets i.e. car, cash..
        [Column(TypeName = "money")]
        public decimal? CashValue { get; set; } // monetary value of contribution
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? SharePercentage { get; set; } // also interest parcentage'

        public int ContactDetailID { get; set; }
        public ContactDetail ContactDetail { get; set; }
        // Navigation
        public ICollection<CompanyMember> CompanyMembers { get; set; }
    }
}
