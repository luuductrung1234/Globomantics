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
    public class ConferenceController : ControllerBase
    {
        private readonly IConferenceRepo _repo;

        public ConferenceController(IConferenceRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var conferences = await _repo.GetAll();
            if (!conferences.Any())
                return new NoContentResult();

            return new ObjectResult(conferences);
        }

        [HttpPost]
        public async Task<ConferenceModel> Add(ConferenceModel conference)
        {
            return await _repo.Add(conference);
        }
    }
}