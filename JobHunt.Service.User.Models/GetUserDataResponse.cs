using System;
using System.Collections.Generic;
using System.Text;

namespace JobHunt.Service.User.Models
{
    public class GetUserDataResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Bio { get; set; }
    }
}
