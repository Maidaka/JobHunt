using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Service.Job.Repository.Models
{
    public static class DbInitializer
    {
        public static void Initialize(JobDbContext context)
        {
            context.Database.EnsureCreated();

            // if there are any users in db, database has already been initialized so just skip initialization
            if (!context.Companies.Any())
            {
                context.Companies.Add(new Company
                {
                    Id = 1,
                    Name = "Trucking Company Inc.",
                });

                context.Companies.Add(new Company
                {
                    Id = 2,
                    Name = "Maida Company",
                });
            }

            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe"
                });

                context.Users.Add(new User
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe"
                });
            }

            context.SaveChanges();
        }
    }
}
