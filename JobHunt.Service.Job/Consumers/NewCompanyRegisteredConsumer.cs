using JobHunt.Service.Job.Repository.Models;
using JobHunt.Service.SharedModels.MessagePayloads;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Service.Job.Consumers
{
    public class NewCompanyRegisteredConsumer : IConsumer<NewCompanyRegisteredMessage>
    {
        private readonly JobDbContext _jobDbContext;

        public NewCompanyRegisteredConsumer(JobDbContext jobDbContext)
        {
            _jobDbContext = jobDbContext;
        }

        public async Task Consume(ConsumeContext<NewCompanyRegisteredMessage> context)
        {
            var newCompany = new Repository.Models.Company
            {
                Id = context.Message.CompanyId,
                Name = context.Message.CompanyName
            };

            _jobDbContext.Companies.Add(newCompany);
            await _jobDbContext.SaveChangesAsync();
        }
    }
}
