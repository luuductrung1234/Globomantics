using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Api.Repositories
{
    public class ConferenceInMemoryRepo : IConferenceRepo
    {
        private readonly List<ConferenceModel> _conferences = new List<ConferenceModel>();

        public ConferenceInMemoryRepo()
        {
            _conferences.Add(new ConferenceModel { Id = 1, Name = "NDC", Location = "Oslo", Start = new DateTime(2017, 6, 12), AttendeeTotal = 2132 });
            _conferences.Add(new ConferenceModel { Id = 2, Name = "IT/DevConnections", Location = "San Francisco", Start = new DateTime(2017, 10, 18), AttendeeTotal = 3210 });
        }
        public Task<IEnumerable<ConferenceModel>> GetAll()
        {
            return Task.Run(() => _conferences.AsEnumerable());
        }

        public Task<ConferenceModel> GetById(int id)
        {
            return Task.Run(() => _conferences.First(c => c.Id == id));
        }

        public Task<ConferenceModel> Add(ConferenceModel model)
        {
            return Task.Run(() =>
            {
                model.Id = _conferences.Max(c => c.Id) + 1;
                _conferences.Add(model);

                return model;
            });
        }
    }
}
