using JobHunt.Service.Job.Repository.Models;
using JobHunt.Service.SharedModels.MessagePayloads;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Service.Job.Consumers
{
    public class NewUserRegisteredConsumer : IConsumer<NewUserRegisteredMessage>
    {
        private readonly JobDbContext _jobDbContext;

        public NewUserRegisteredConsumer(JobDbContext jobDbContext)
        {
            _jobDbContext = jobDbContext;
        }

        public async Task Consume(ConsumeContext<NewUserRegisteredMessage> context)
        {
            var newUser = new Job.Repository.Models.User
            {
                FirstName = context.Message.FirstName,
                LastName = context.Message.LastName,
                Id = context.Message.UserId
            };

            _jobDbContext.Users.Add(newUser);
            await _jobDbContext.SaveChangesAsync();
        }
    }
}
