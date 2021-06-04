using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Service.Job.Repository.Models
{
    /// <summary>
    /// This class is EntityFramework context for User database
    /// </summary>
    public class JobDbContext : DbContext
    {
        /// <summary>
        /// Constructor used to initialize context with supplied configuraiton (DbContextOptions)
        /// </summary>
        /// <param name="options">Configuration for dbContext (such as connection string etc)</param>
        public JobDbContext(DbContextOptions<JobDbContext> options) : base(options)
        {
        }

        // List of databases (with DbSet)
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Method used to map classes in C# to database
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<Job>().ToTable("Job");
            modelBuilder.Entity<JobApplication>().ToTable("JobApplication");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
