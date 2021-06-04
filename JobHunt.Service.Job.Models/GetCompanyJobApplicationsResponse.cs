using System;
using System.Collections.Generic;
using System.Text;

namespace JobHunt.Service.Job.Models
{
    public class GetCompanyJobApplicationsResponse
    {
        public IEnumerable<CompanyJobApplication> JobApplications { get; set; }
    }

    public class CompanyJobApplication
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string CompanyName { get; set; }
        public int Status { get; set; }
    }
}
