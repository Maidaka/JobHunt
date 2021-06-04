using System;
using System.Collections.Generic;
using System.Text;

namespace JobHunt.Service.SharedModels.MessagePayloads
{
    public class NewCompanyRegisteredMessage
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
