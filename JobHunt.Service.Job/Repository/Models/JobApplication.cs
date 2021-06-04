using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Service.Job.Repository.Models
{
    public class JobApplication
    {
        public int Id { get; set; }

        public int JobId { get; set; }
        public virtual Job Job { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int Status { get; set; }
    }
}
