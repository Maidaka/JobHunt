using System;
using System.Collections.Generic;
using System.Text;

namespace JobHunt.Service.Job.Models
{
    public class GetCompanyJobsResponse
    {
        public IEnumerable<CompanyJob> Jobs { get; set; }
    }

    public class CompanyJob
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }
        public int NumberOfJobApplications { get; set; }
        public string CompanyName { get; set; }
        public bool HasUserApplied { get; set; }
    }
}
