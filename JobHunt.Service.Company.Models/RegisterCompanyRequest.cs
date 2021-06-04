using System;
using System.Collections.Generic;
using System.Text;

namespace JobHunt.Service.Company.Models
{
    public class RegisterCompanyRequest
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
    }
}
