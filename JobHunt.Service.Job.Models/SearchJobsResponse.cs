using System;
using System.Collections.Generic;
using System.Text;

namespace JobHunt.Service.Job.Models
{
    public class SearchJobsResponse
    {
        public IEnumerable<CompanyJob> Jobs { get; set; }
    }
}
