using System;
using System.Collections.Generic;
using System.Text;

namespace JobHunt.Service.User.Models
{
    public class LoginResponse
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public int Id { get; set; }
    }
}
