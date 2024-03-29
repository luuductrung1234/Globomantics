﻿using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Api.Repositories
{
    public interface IStatisticsRepo
    {
        Task<StatisticsModel> GetStatistics();
    }
}
