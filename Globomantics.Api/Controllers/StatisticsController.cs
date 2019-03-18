using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Globomantics.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Globomantics.Api.Controllers
{
    [Route("api/[controller]")]
    public class StatisticsController : Controller
    {
        private readonly IStatisticsRepo _repo;

        public StatisticsController(IStatisticsRepo repo)
        {
            _repo = repo;
        }
        public async Task<StatisticsModel> Get()
        {
            return await _repo.GetStatistics();
        }
    }
}
