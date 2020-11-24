using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesIspProject.Models
{
    public enum CompanyType
    {
        [Display(Name = "Private Limited")]
        PVT,
        [Display(Name = "Private Business Corporation")]
        PBC
    }
    public class Company
    {
        public int ID { get; set; }
        public string Number { get; set; }
        [Required]
        [Column(TypeName  = "nvarchar(max)")]
        public CompanyType CompanyType { get; set; }
        public string MainBusiness { get; set; }
        public string Name { get; set; }
        [Required]
        public string PhysicalAddress { get; set; }
        [Required]
        public string EmailAddress { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfIncorporation { get; set; }

        // FK
        public int ApplicantID { get; set; }

        // Navigation properties
        public ICollection<CompanyEmployee> CompanyEmployees { get; set; }
        public ICollection<Member> CompanyMembers { get; set; }
        public ICollection<NameOption> NameOptions { get; set; }
        public Applicant Applicant { get; set; }

    }   
}
