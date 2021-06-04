using JobHunt.Service.Job.Models;
using JobHunt.Service.Job.Models.Enums;
using JobHunt.Service.Job.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace JobHunt.Service.Company.Controllers
{
    [ApiController]
    [Route("api/job")]
    public class JobController : ControllerBase
    {
        private readonly JobDbContext _jobDbContext;

        public JobController(JobDbContext jobDbContext)
        {
            _jobDbContext = jobDbContext;
        }

        [HttpGet("search/{userId}")]
        public SearchJobsResponse SearchJobs(int userId)
        {
            var jobs = _jobDbContext
                 .Jobs
                 .Include(x => x.JobApplications)
                 .Include(x => x.Company)
                 .Where(x => x.Status == (int)JobStatus.Open);

            return new SearchJobsResponse
            {
                Jobs = jobs.Select(x => new CompanyJob
                {
                    CreatedAt = x.CreatedAt,
                    Description = x.Description,
                    Id = x.Id,
                    Status = x.Status,
                    CompanyName = x.Company.Name,
                    Title = x.Title,
                    NumberOfJobApplications = x.JobApplications.Count,
                    HasUserApplied = x.JobApplications.Any(x => x.UserId == userId)
                })
            };
        }

        [HttpPost("")]
        public PostNewJobResponse PostNewJob([FromBody] PostNewJobRequest request)
        {
            var job = new Job.Repository.Models.Job
            {
                CompanyId = request.CompanyId,
                CreatedAt = DateTime.UtcNow,
                Description = request.Description,
                Status = (int)JobStatus.Open,
                Title = request.Title
            };

            _jobDbContext.Jobs.Add(job);
            _jobDbContext.SaveChanges();

            return new PostNewJobResponse
            {
                Id = job.Id
            };
        }

        [HttpGet("company/{companyId}")]
        public GetCompanyJobsResponse GetCompanyJobs(int companyId)
        {
            var jobs = _jobDbContext
                .Jobs
                .Include(x => x.JobApplications)
                .Where(x => x.CompanyId == companyId);

            return new GetCompanyJobsResponse
            {
                Jobs = jobs.Select(x => new CompanyJob
                {
                    CreatedAt = x.CreatedAt,
                    Description = x.Description,
                    Id = x.Id,
                    Status = x.Status,
                    Title = x.Title,
                    NumberOfJobApplications = x.JobApplications.Count
                })
            };
        }

        [HttpGet("jobapplication/{companyId}")]
        public GetCompanyJobApplicationsResponse GetCompanyJobApplications(int companyId)
        {
            var jobApplications = _jobDbContext
                .JobApplications
                .Include(x => x.Job)
                .Include(x => x.User)
                .Where(x => x.Job.CompanyId == companyId);

            return new GetCompanyJobApplicationsResponse
            {
                JobApplications = jobApplications.Select(x => new CompanyJobApplication
                {
                    Id = x.Id,
                    JobId = x.JobId,
                    JobTitle = x.Job.Title,
                    Status = x.Status,
                    UserId = x.UserId,
                    UserFullName = x.User.FirstName + " " + x.User.LastName
                })
            };
        }

        [HttpGet("jobapplication/user/{userId}")]
        public GetCompanyJobApplicationsResponse GetUserJobApplications(int userId)
        {
            var jobApplications = _jobDbContext
                .JobApplications
                .Include(x => x.Job)
                .Include(x => x.Job.Company)
                .Where(x => x.UserId == userId);

            return new GetCompanyJobApplicationsResponse
            {
                JobApplications = jobApplications.Select(x => new CompanyJobApplication
                {
                    Id = x.Id,
                    JobId = x.JobId,
                    JobTitle = x.Job.Title,
                    JobDescription = x.Job.Description,
                    CompanyName = x.Job.Company.Name,
                    Status = x.Status,
                    UserId = x.UserId,
                    UserFullName = x.User.FirstName + " " + x.User.LastName
                })
            };
        }

        [HttpPost("jobapplication")]
        public CreateNewJobApplicationResponse CreateNewJobApplication([FromBody] CreateNewJobApplicationRequest request)
        {
            var jobApplication = new Job.Repository.Models.JobApplication
            {
                JobId = request.JobId,
                UserId = request.UserId,
                Status = (int)JobApplicationStatus.Submitted
            };

            _jobDbContext.JobApplications.Add(jobApplication);
            _jobDbContext.SaveChanges();

            return new CreateNewJobApplicationResponse
            {
                Id = jobApplication.Id
            };
        }

        [HttpGet("{jobId}/close")]
        public bool CloseJob(int jobId)
        {
            var job = _jobDbContext.Jobs.FirstOrDefault(x => x.Id == jobId);

            if (job == null)
            {
                return false;
            }

            job.Status = (int)JobStatus.Closed;

            _jobDbContext.SaveChanges();

            return true;
        }

        [HttpGet("jobapplication/{jobApplicationId}/approve")]
        public bool ApproveJobApplication(int jobApplicationId)
        {
            var jobApplication = _jobDbContext.JobApplications.FirstOrDefault(x => x.Id == jobApplicationId);

            if (jobApplication == null)
            {
                return false;
            }

            jobApplication.Status = (int)JobApplicationStatus.Approved;

            _jobDbContext.SaveChanges();

            return true;
        }

        [HttpGet("jobapplication/{jobApplicationId}/decline")]
        public bool DeclineJobApplication(int jobApplicationId)
        {
            var jobApplication = _jobDbContext.JobApplications.FirstOrDefault(x => x.Id == jobApplicationId);

            if (jobApplication == null)
            {
                return false;
            }

            jobApplication.Status = (int)JobApplicationStatus.Declined;

            _jobDbContext.SaveChanges();

            return true;
        }
    }
}
