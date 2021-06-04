using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Service.Company.Repository.Models
{
    /// <summary>
    /// This class is EntityFramework context for User database
    /// </summary>
    public class CompanyDbContext : DbContext
    {
        /// <summary>
        /// Constructor used to initialize context with supplied configuraiton (DbContextOptions)
        /// </summary>
        /// <param name="options">Configuration for dbContext (such as connection string etc)</param>
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
        }

        // List of databases (with DbSet)
        public DbSet<Company> Companies { get; set; }

        /// <summary>
        /// Method used to map classes in C# to database
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().ToTable("Company");
        }
    }
}
