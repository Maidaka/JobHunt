using JobHunt.Service.Company.Models;
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
    [Route("api/company")]
    public class CompanyController : ControllerBase
    {
        private readonly string _baseCompanyApiUrl = "https://localhost:44368";

        [HttpPost("login")]
        public async Task<LoginResponse> Login([FromBody] LoginRequest request)
        {
            // Create Http client (to send HTTP requests)
            using (var httpClient = new HttpClient())
            {
                // Convert request instance to a JSON string representation
                string json = JsonConvert.SerializeObject(request);
                var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                // Send POST request to URL
                var response = await httpClient.PostAsync(_baseCompanyApiUrl + "/api/company/login", httpContent);

                // Read response as JSON string
                var responseContent = await response.Content.ReadAsStringAsync();

                // Convert JSON string representation into instance of response
                return JsonConvert.DeserializeObject<LoginResponse>(responseContent);
            }
        }

        [HttpPost("register")]
        public async Task<RegisterCompanyResponse> Register([FromBody] RegisterCompanyRequest request)
        {
            // Create Http client (to send HTTP requests)
            using (var httpClient = new HttpClient())
            {
                // Convert request instance to a JSON string representation
                string json = JsonConvert.SerializeObject(request);
                var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                // Send POST request to URL
                var response = await httpClient.PostAsync(_baseCompanyApiUrl + "/api/company/register", httpContent);

                // Read response as JSON string
                var responseContent = await response.Content.ReadAsStringAsync();

                // Convert JSON string representation into instance of response
                return JsonConvert.DeserializeObject<RegisterCompanyResponse>(responseContent);
            }
        }
    }
}
