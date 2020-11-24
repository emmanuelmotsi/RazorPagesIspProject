using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesIspProject.Models.CompanyPersons
{
    public class MemberVm
    {
        public int ID { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Nationality { get; set; }
        public string IdentityNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string Contribution { get; set; } // to pbc assets i.e. car, cash..
        [Column(TypeName = "money")]
        public decimal? CashValue { get; set; } // monetary value of contribution
        [Column(TypeName = "decimal(5, 2)")]
        public decimal SharePercentage { get; set; } // also interest parcentage'

    }
}
