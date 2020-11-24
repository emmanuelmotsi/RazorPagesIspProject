using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesIspProject.Data;
using RazorPagesIspProject.Models;

namespace RazorPagesIspProject.Pages.Companies
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesIspProject.Data.CompanyContext _context;

        public DetailsModel(RazorPagesIspProject.Data.CompanyContext context)
        {
            _context = context;
        }

        public Company Company { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company = await _context.Companies
                .Include(c => c.Applicant).FirstOrDefaultAsync(m => m.ID == id);

            if (Company == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
