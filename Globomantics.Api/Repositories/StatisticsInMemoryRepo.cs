using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Api.Repositories
{
    public class StatisticsInMemoryRepo : IStatisticsRepo
    {
        private readonly IConferenceRepo conferenceRepo;

        public StatisticsInMemoryRepo(IConferenceRepo conferenceRepo)
        {
            this.conferenceRepo = conferenceRepo;
        }

        public StatisticsModel GetStatistics()
        {
            var conferences = conferenceRepo.GetAll();
            return new StatisticsModel
            {
                NumberOfAttendees = conferences.Sum(c => c.AttendeeTotal),
                AverageConferenceAttendees = (int)conferences.Average(c => c.AttendeeTotal)
            };
        }
    }
}
