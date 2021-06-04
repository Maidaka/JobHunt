using JobHunt.Service.Company.Models;
using JobHunt.Service.Company.Repository.Models;
using JobHunt.Service.SharedModels.MessagePayloads;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JobHunt.Service.Company.Controllers
{
    [ApiController]
    [Route("api/company")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyDbContext _companyDbContext;
        private readonly IBus _bus;

        public CompanyController(CompanyDbContext companyDbContext, IBus bus)
        {
            _companyDbContext = companyDbContext;
            _bus = bus;
        }

        [HttpPost("login")]
        public LoginResponse Login([FromBody] LoginRequest request)
        {
            var company = _companyDbContext.Companies.FirstOrDefault(x => x.Username == request.Username);

            if (company == null)
            {
                return null;
            }

            string hashedPassword = GenerateHash(request.Password);
          
            if (hashedPassword != company.Password)
            {
                return null;
            }

            return new LoginResponse
            {
                Name = company.Name,
                Id = company.Id
            };
        }

        [HttpPost("register")]
        public async Task<RegisterCompanyResponse> RegisterCompany(RegisterCompanyRequest request)
        {
            var company = new Repository.Models.Company
            {
                Name = request.Name,
                Description = request.Description,
                Password = GenerateHash(request.Password),
                Username = request.Username
            };

            _companyDbContext.Companies.Add(company);
            _companyDbContext.SaveChanges();

            // Send NewCompanyRegisteredMessage to the queue
            var message = new NewCompanyRegisteredMessage
            {
                CompanyId = company.Id,
                CompanyName = company.Name
            };
            var uri = new Uri("rabbitmq://localhost/newCompanyRegisteredQueue");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(message);

            return new RegisterCompanyResponse
            {
                Id = company.Id
            };
        }

        private string GenerateHash(string input)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
