using System;
using System.Collections.Generic;
using System.Text;

namespace JobHunt.Service.SharedModels.MessagePayloads
{
    public class NewUserRegisteredMessage
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
