using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Api.Repositories
{
    public class StatisticsInMemoryRepo : IStatisticsRepo
    {
        private readonly IConferenceRepo _conferenceRepo;

        public StatisticsInMemoryRepo(IConferenceRepo conferenceRepo)
        {
            _conferenceRepo = conferenceRepo;
        }

        public async Task<StatisticsModel> GetStatistics()
        {
            var conferences = await _conferenceRepo.GetAll();
            return new StatisticsModel
            {
                NumberOfAttendees = conferences.Sum(c => c.AttendeeTotal),
                AverageConferenceAttendees = (int)conferences.Average(c => c.AttendeeTotal)
            };
        }
    }
}
