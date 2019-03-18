using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Shared.Models;

namespace Globomantics.Services
{
    public class ConferenceInMemoryService : IConferenceService
    {
        private readonly List<ConferenceModel> conferences = new List<ConferenceModel>();
        private readonly IOptions<GlobomanticsOptions> _options;

        public ConferenceInMemoryService(IOptions<GlobomanticsOptions> options)
        {
            _options = options;

            if (_options.Value.ConferenceInitNumber > 2)
            {
                for (int i = 1; i <= _options.Value.ConferenceInitNumber; i++)
                {
                    conferences.Add(new ConferenceModel { Id = i, Name = $"Sample Conference {i}", Location = $"Sample Location {i}", Start = DateTime.Now, AttendeeTotal = 1000 });
                }
            }
            else
            {
                conferences.Add(new ConferenceModel { Id = 1, Name = "NDC", Location = "Oslo", Start = DateTime.Now, AttendeeTotal = 2132 });
                conferences.Add(new ConferenceModel { Id = 2, Name = "IT/DevConnections", Location = "LA", Start = DateTime.Now, AttendeeTotal = 3210 });
            }
        }

        public Task Add(ConferenceModel model)
        {
            model.Id = conferences.Max(c => c.Id) + 1;
            conferences.Add(model);

            return Task.CompletedTask;
        }

        public Task<IEnumerable<ConferenceModel>> GetAll()
        {
            return Task.Run(() =>
            {
                return conferences.AsEnumerable();
            });
        }

        public Task<ConferenceModel> GetById(int id)
        {
            return Task.Run(() =>
            {
                return conferences.FirstOrDefault(c => c.Id == id);
            });
        }

        public Task<StatisticsModel> GetStatistics()
        {
            return Task.Run(() =>
            {
                return new StatisticsModel
                {
                    NumberOfAttendees = conferences.Sum(c => c.AttendeeTotal),
                    AverageConferenceAttendees = (int)conferences.Average(c => c.AttendeeTotal)
                };
            });
        }
    }
}
