using JobHunt.Service.User.Models;
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
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly string _baseUserApiUrl = "https://localhost:44354";

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
                var response = await httpClient.PostAsync(_baseUserApiUrl + "/api/user/login", httpContent);

                // Read response as JSON string
                var responseContent = await response.Content.ReadAsStringAsync();

                // Convert JSON string representation into instance of response
                return JsonConvert.DeserializeObject<LoginResponse>(responseContent);
            }
        }

        [HttpPost("register")]
        public async Task<RegisterUserResponse> Register([FromBody] RegisterUserRequest request)
        {
            // Create Http client (to send HTTP requests)
            using (var httpClient = new HttpClient())
            {
                // Convert request instance to a JSON string representation
                string json = JsonConvert.SerializeObject(request);
                var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                // Send POST request to URL
                var response = await httpClient.PostAsync(_baseUserApiUrl + "/api/user/register", httpContent);

                // Read response as JSON string
                var responseContent = await response.Content.ReadAsStringAsync();

                // Convert JSON string representation into instance of response
                return JsonConvert.DeserializeObject<RegisterUserResponse>(responseContent);
            }
        }

        [HttpGet("{userId}")]
        public async Task<GetUserDataResponse> GetUserData(int userId)
        {
            // Create Http client (to send HTTP requests)
            using (var httpClient = new HttpClient())
            {
                // Send GET request to URL
                var response = await httpClient.GetAsync(_baseUserApiUrl + "/api/user/" + userId);

                // Read response as JSON string
                var responseContent = await response.Content.ReadAsStringAsync();

                // Convert JSON string representation into instance of response
                return JsonConvert.DeserializeObject<GetUserDataResponse>(responseContent);
            }
        }
    }
}
