using JobHunt.Service.Company.Models;
using JobHunt.Service.Job.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JobHunt.Api.Controllers
{
    [ApiController]
    [Route("api/job")]
    public class JobController : ControllerBase
    {
        private readonly string _baseJobApiUrl = "https://localhost:44358";

        [HttpGet("search/{userId}")]
        public async Task<SearchJobsResponse> SearchJobs(int userId)
        {
            // Create Http client (to send HTTP requests)
            using (var httpClient = new HttpClient())
            {
                // Send GET request to URL
                var response = await httpClient.GetAsync(_baseJobApiUrl + "/api/job/search/" + userId);

                // Read response as JSON string
                var responseContent = await response.Content.ReadAsStringAsync();

                // Convert JSON string representation into instance of response
                return JsonConvert.DeserializeObject<SearchJobsResponse>(responseContent);
            }
        }

        [HttpPost("")]
        public async Task<PostNewJobResponse> PostNewJob([FromBody] PostNewJobRequest request)
        {
            // Create Http client (to send HTTP requests)
            using (var httpClient = new HttpClient())
            {
                // Convert request instance to a JSON string representation
                string json = JsonConvert.SerializeObject(request);
                var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                // Send POST request to URL
                var response = await httpClient.PostAsync(_baseJobApiUrl + "/api/job", httpContent);

                // Read response as JSON string
                var responseContent = await response.Content.ReadAsStringAsync();

                // Convert JSON string representation into instance of response
                return JsonConvert.DeserializeObject<PostNewJobResponse>(responseContent);
            }
        }

        [HttpGet("company/{companyId}")]
        public async Task<GetCompanyJobsResponse> GetCompanyJobs(int companyId)
        {
            // Create Http client (to send HTTP requests)
            using (var httpClient = new HttpClient())
            {
                // Send GET request to URL
                var response = await httpClient.GetAsync(_baseJobApiUrl + "/api/job/company/" + companyId);

                // Read response as JSON string
                var responseContent = await response.Content.ReadAsStringAsync();

                // Convert JSON string representation into instance of response
                return JsonConvert.DeserializeObject<GetCompanyJobsResponse>(responseContent);
            }
        }

        [HttpGet("jobapplication/{companyId}")]
        public async Task<GetCompanyJobApplicationsResponse> GetCompanyJobApplications(int companyId)
        {
            // Create Http client (to send HTTP requests)
            using (var httpClient = new HttpClient())
            {
                // Send GET request to URL
                var response = await httpClient.GetAsync(_baseJobApiUrl + "/api/job/jobapplication/" + companyId);

                // Read response as JSON string
                var responseContent = await response.Content.ReadAsStringAsync();

                // Convert JSON string representation into instance of response
                return JsonConvert.DeserializeObject<GetCompanyJobApplicationsResponse>(responseContent);
            }
        }

        [HttpGet("jobapplication/user/{userId}")]
        public async Task<GetCompanyJobApplicationsResponse> GetUserJobApplications(int userId)
        {
            // Create Http client (to send HTTP requests)
            using (var httpClient = new HttpClient())
            {
                // Send GET request to URL
                var response = await httpClient.GetAsync(_baseJobApiUrl + "/api/job/jobapplication/user/" + userId);

                // Read response as JSON string
                var responseContent = await response.Content.ReadAsStringAsync();

                // Convert JSON string representation into instance of response
                return JsonConvert.DeserializeObject<GetCompanyJobApplicationsResponse>(responseContent);
            }
        }

        [HttpPost("jobapplication")]
        public async Task<CreateNewJobApplicationResponse> CreateNewJobApplication([FromBody] CreateNewJobApplicationRequest request)
        {
            // Create Http client (to send HTTP requests)
            using (var httpClient = new HttpClient())
            {
                // Convert request instance to a JSON string representation
                string json = JsonConvert.SerializeObject(request);
                var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                // Send POST request to URL
                var response = await httpClient.PostAsync(_baseJobApiUrl + "/api/job/jobapplication", httpContent);

                // Read response as JSON string
                var responseContent = await response.Content.ReadAsStringAsync();

                // Convert JSON string representation into instance of response
                return JsonConvert.DeserializeObject<CreateNewJobApplicationResponse>(responseContent);
            }
        }

        [HttpGet("{jobId}/close")]
        public async Task<bool> CloseJob(int jobId)
        {
            // Create Http client (to send HTTP requests)
            using (var httpClient = new HttpClient())
            {
                // Send GET request to URL
                var response = await httpClient.GetAsync(_baseJobApiUrl + "/api/job/" + jobId + "/close");

                // Read response as JSON string
                var responseContent = await response.Content.ReadAsStringAsync();

                // Convert JSON string representation into instance of response
                return JsonConvert.DeserializeObject<bool>(responseContent);
            }
        }

        [HttpGet("jobapplication/{jobApplicationId}/approve")]
        public async Task<bool> ApproveJobApplication(int jobApplicationId)
        {
            // Create Http client (to send HTTP requests)
            using (var httpClient = new HttpClient())
            {
                // Send GET request to URL
                var response = await httpClient.GetAsync(_baseJobApiUrl + "/api/job/jobapplication/" + jobApplicationId + "/approve");

                // Read response as JSON string
                var responseContent = await response.Content.ReadAsStringAsync();

                // Convert JSON string representation into instance of response
                return JsonConvert.DeserializeObject<bool>(responseContent);
            }
        }

        [HttpGet("jobapplication/{jobApplicationId}/decline")]
        public async Task<bool> DeclineJobApplication(int jobApplicationId)
        {
            // Create Http client (to send HTTP requests)
            using (var httpClient = new HttpClient())
            {
                // Send GET request to URL
                var response = await httpClient.GetAsync(_baseJobApiUrl + "/api/job/jobapplication/" + jobApplicationId + "/decline");

                // Read response as JSON string
                var responseContent = await response.Content.ReadAsStringAsync();

                // Convert JSON string representation into instance of response
                return JsonConvert.DeserializeObject<bool>(responseContent);
            }
        }
    }
}
