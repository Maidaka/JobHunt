using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Service.Company.Repository.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
