using System;
using System.Collections.Generic;
using System.Text;

namespace JobHunt.Service.Job.Models
{
    public class PostNewJobRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
    }
}
