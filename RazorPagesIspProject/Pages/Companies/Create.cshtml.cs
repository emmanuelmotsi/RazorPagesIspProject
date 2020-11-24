using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesIspProject.Data;
using RazorPagesIspProject.Models;

namespace RazorPagesIspProject.Pages.Companies
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesIspProject.Data.CompanyContext _context;

        public CreateModel(RazorPagesIspProject.Data.CompanyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "EmailAddress");
            return Page();
        }

        [BindProperty]
        public Company Company { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Companies.Add(Company);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
