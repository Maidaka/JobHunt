using System;
using System.Collections.Generic;
using System.Text;

namespace JobHunt.Service.Job.Models
{
    public class CreateNewJobApplicationRequest
    {
        public int UserId { get; set; }

        public int JobId { get; set; }
    }
}
