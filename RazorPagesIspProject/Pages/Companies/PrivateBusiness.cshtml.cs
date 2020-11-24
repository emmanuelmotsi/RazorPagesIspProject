using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesIspProject.Data;
using RazorPagesIspProject.Models;
using RazorPagesIspProject.Models.CompanyPersons;

namespace RazorPagesIspProject.Pages.Companies
{
    public class PrivateBusinessModel : PageModel
    {
        public readonly CompanyContext _context;
        [BindProperty]
        public Company Company { get; set; }
        [BindProperty]
        public MemberVm[] MemberVm { get; set; }
        [BindProperty]
        public NameOption[] NameOptions { get; set; }
        [BindProperty]
        public AccountingOfficerVm AccountingOfficerVm { get; set; }
        [BindProperty]
        public ApplicantVm ApplicantVm { get; set; }

        public PrivateBusinessModel(CompanyContext context)
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

            var members = new List<Member>();
            foreach (var m in MemberVm)
            {
                members.Add(new Member
                {
                    Contribution = m.Contribution,
                    CashValue = m.CashValue,
                    SharePercentage = m.SharePercentage,
                    ContactDetail = new ContactDetail
                    {
                        Forename = m.Forename,
                        Surname = m.Surname,
                        Nationality = m.Nationality,
                        IdentityNumber = m.IdentityNumber
                    },
                });
            }
            var employee = new Employee
            {
                EmployeeType = EmployeeType.AccountingOfficer,
                Qualification = AccountingOfficerVm.Qualification,
                ContactDetail = new ContactDetail
                {
                    Forename = AccountingOfficerVm.Forename,
                    Surname = AccountingOfficerVm.Surname,
                    PhysicalAddress = AccountingOfficerVm.PhysicalAddress
                }
            };
            Company.CompanyType = CompanyType.PBC;
            Company.NameOptions = NameOptions;
            Company.Applicant = new Applicant
            {
                FirstName = ApplicantVm.FirstName,
                LastName = ApplicantVm.LastName,
                EmailAddress = ApplicantVm.EmailAddress,
                PhoneNumber = ApplicantVm.PhoneNumber
            };

            _context.Employees.Add(employee);
            _context.Members.AddRange(members);
            _context.Companies.Add(Company);

            List<CompanyMember> companyMember_Fks = new List<CompanyMember>();
            foreach (var m in members)
            {
                companyMember_Fks.Add(new CompanyMember
                {
                    Company = Company,
                    Member = m,
                });
            }

            CompanyEmployee companyEmployee_Fks = new CompanyEmployee
            {
                Company = Company,
                Employee = employee
            };

            _context.CompanyMembers.AddRange(companyMember_Fks);
            _context.CompanyEmployees.Add(companyEmployee_Fks);

            // can i call this method once and it will take care of the foreign keys?????
            await _context.SaveChangesAsync();
            return RedirectToPage("./index");
        }
    }
}
