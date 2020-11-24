using Microsoft.EntityFrameworkCore;
using RazorPagesIspProject.Models;

namespace RazorPagesIspProject.Data
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyMember> CompanyMembers { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CompanyEmployee> CompanyEmployees { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<NameOption> NameOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>().ToTable("Applicant");
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<CompanyMember>().ToTable("CompanyMember");
            modelBuilder.Entity<ContactDetail>().ToTable("ContactDetail");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<CompanyEmployee>().ToTable("CompanyEmployee");
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<NameOption>().ToTable("NameOption");

            // Composite keys
            modelBuilder.Entity<CompanyEmployee>()
                .HasKey(ce => new { ce.CompanyID, ce.EmployeeID });
            modelBuilder.Entity<CompanyMember>()
                .HasKey(cm => new { cm.CompanyID, cm.MemberID });

        }
    }
}
