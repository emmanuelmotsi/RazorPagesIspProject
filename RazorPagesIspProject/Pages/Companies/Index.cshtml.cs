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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesIspProject.Data.CompanyContext _context;

        public IndexModel(RazorPagesIspProject.Data.CompanyContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get;set; }

        public async Task OnGetAsync()
        {
            Company = await _context.Companies
                .Include(c => c.Applicant).ToListAsync();
        }
    }
}
