using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesIspProject.Models
{
  
    public class ContactDetail
    {
        public int ID { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Nationality { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string EmailAddress { get; set; }

        // Navigation
        public Employee Employee { get; set; }
        public Member Member { get; set; }
    }
}
