using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Globomantics.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Globomantics.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepo repo;

        public StatisticsController(IStatisticsRepo repo)
        {
            this.repo = repo;
        }
        public StatisticsModel Get()
        {
            return repo.GetStatistics();
        }
    }
}