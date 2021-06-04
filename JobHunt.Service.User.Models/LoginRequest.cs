using System;
using System.Collections.Generic;
using System.Text;

namespace JobHunt.Service.User.Models
{
    public class LoginRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
