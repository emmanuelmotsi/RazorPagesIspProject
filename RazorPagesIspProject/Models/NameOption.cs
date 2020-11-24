using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesIspProject.Models
{
    public class NameOption
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        // FK
        public int CompanyID { get; set; }

        // Navigation
        public Company Company { get; set; }

    }
}
