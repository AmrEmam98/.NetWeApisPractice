using LinkedInProjectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkedInProjectApi
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<CompanyModel> Companies  { get; set; }
        public DbSet<EmployeeCompany> EmployeeCompanies  { get; set; }
        public DbSet<SkillModel> Skills { get; set; }
        public DbSet<EmployeeSkills> EmpSkills { get; set; }



        


    }
}
