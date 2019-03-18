using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Api.Repositories
{
    public interface IStatisticsRepo
    {
        Task<StatisticsModel> GetStatistics();
    }
}
