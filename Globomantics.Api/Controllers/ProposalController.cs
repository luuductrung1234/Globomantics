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
    [ApiController]
    public class ProposalController : ControllerBase
    {
        private readonly IConferenceRepo _conferenceRepo;
        private readonly IProposalRepo _proposalRepo;

        public ProposalController(IConferenceRepo conferenceRepo,
            IProposalRepo proposalRepo)
        {
            this._conferenceRepo = conferenceRepo;
            this._proposalRepo = proposalRepo;
        }

        [HttpGet("{conferenceId}", Name = "GetAll")]
        public async Task<IActionResult> GetAll(int conferenceId)
        {
            var proposals = await _proposalRepo.GetAllForConference(conferenceId);

            if (!proposals.Any())
                return new NoContentResult();

            return new ObjectResult(proposals);
        }

        [HttpGet(Name = "GetById")]
        public async Task<ProposalModel> GetById(int id)
        {
            return await _proposalRepo.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ProposalModel model)
        {
            var addedProposal = await _proposalRepo.Add(model);
            return CreatedAtRoute("GetById", new { id = addedProposal.Id },
                addedProposal);
        }

        [HttpPut("{proposalId}")]
        public async Task<IActionResult> Approve(int proposalId)
        {
            try
            {
                return new ObjectResult(await _proposalRepo.Approve(proposalId));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}
