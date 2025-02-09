using DemoEntityFramework.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DemoEntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration configuration;
        public ApplicationDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQL Server connection string.
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("myConnection"));
        }
    }
}
