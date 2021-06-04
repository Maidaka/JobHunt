using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Service.Job.Repository.Models
{
    public class Job
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Status { get; set; }

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<JobApplication> JobApplications { get; set; }
    }
}
