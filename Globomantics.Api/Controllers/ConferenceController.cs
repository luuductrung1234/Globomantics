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
        private readonly IConferenceRepo repo;

        public ConferenceController(IConferenceRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult GetAll()
        {
            var conferences = repo.GetAll();
            if (!conferences.Any())
                return new NoContentResult();

            return new ObjectResult(conferences);
        }

        [HttpPost]
        public ConferenceModel Add(ConferenceModel conference)
        {
            return repo.Add(conference);
        }
    }
}