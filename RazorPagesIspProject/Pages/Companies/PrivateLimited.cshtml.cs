using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesIspProject.Data;
using RazorPagesIspProject.Models;
using RazorPagesIspProject.Models.CompanyPersons;

namespace RazorPagesIspProject.Pages.Companies
{

    public class PrivateLimitedModel : PageModel
    {
        private readonly CompanyContext _context;
        [BindProperty]
        public Company Company { get; set; }
        [BindProperty]
        public DirectorVm[] DirectorVm { get; set; }
        [BindProperty]
        public SubcriberVm[] SubcriberVm { get; set; }
        [BindProperty]
        public SecretaryVm SecretaryVm { get; set; }
        [BindProperty]
        public ApplicantVm ApplicantVm { get; set; }
        [BindProperty]
        public NameOption[] NameOptions { get; set; }
        public PrivateLimitedModel(CompanyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Employees entry
            List<Employee> employees = new List<Employee>();
            foreach (var directorVm in DirectorVm)
            {
                employees.Add(new Employee
                {
                    EmployeeType = directorVm.EmployeeType,
                    ContactDetail = new ContactDetail
                    {
                        Forename = directorVm.Forename,
                        Surname = directorVm.Surname,
                        Nationality = directorVm.Nationality,
                        IdentityNumber = directorVm.IdentityNumber,
                        PhysicalAddress = directorVm.PhysicalAddress
                    }
                });
            }

            // Subscriber entry
            var subscribers = new List<Member>();
            foreach (var subscriberVm in SubcriberVm)
            {
                subscribers.Add(new Member
                {
                    ContactDetail = new ContactDetail
                    {
                        Forename = subscriberVm.Forename,
                        Surname = subscriberVm.Surname,
                        PhysicalAddress = subscriberVm.PhysicalAddress
                    },
                    SharesTaken = subscriberVm.SharesTaken,
                    Occupation = subscriberVm.Occupation
                });
            }

            // Company entry
            Company.CompanyType = CompanyType.PVT;
            Company.NameOptions = NameOptions;
            Company.Applicant = new Applicant
            {
                FirstName = ApplicantVm.FirstName,
                LastName = ApplicantVm.LastName,
                PhoneNumber = ApplicantVm.PhoneNumber,
                EmailAddress = ApplicantVm.EmailAddress
            };

            _context.Employees.AddRange(employees);
            _context.Members.AddRange(subscribers);
            _context.Companies.Add(Company);


            //Join tables entry
            List<CompanyEmployee> companyEmployees_Fks = new List<CompanyEmployee>();
            List<CompanyMember> companySubscribers_Fks = new List<CompanyMember>();
            foreach (var e in employees)
            {
                companyEmployees_Fks.Add(new CompanyEmployee
                {
                    Company = Company,
                    Employee = e
                }); ;
            }

            foreach (var s in subscribers)
            {
                companySubscribers_Fks.Add(new CompanyMember
                {
                    Company = Company,
                    Member = s
                });
            }
            _context.CompanyEmployees.AddRange(companyEmployees_Fks);
            _context.CompanyMembers.AddRange(companySubscribers_Fks);

            await _context.SaveChangesAsync();
            return RedirectToPage("/Applications");
        }
    }
}
