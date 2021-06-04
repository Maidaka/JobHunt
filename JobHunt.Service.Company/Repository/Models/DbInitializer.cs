using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Service.Company.Repository.Models
{
    public static class DbInitializer
    {
        public static void Initialize(CompanyDbContext context)
        {
            context.Database.EnsureCreated();

            // if there are any users in db, database has already been initialized so just skip initialization
            if (context.Companies.Any())
            {
                return;
            }

            context.Companies.Add(new Company
            {
                Description = null,
                Name = "Trucking Company Inc.",
                Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                Username = "trucking.co"
            });

            context.SaveChanges();
        }
    }
}
