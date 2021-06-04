using System;
using System.Collections.Generic;
using System.Text;

namespace JobHunt.Service.User.Models
{
    public class RegisterUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
    }
}
