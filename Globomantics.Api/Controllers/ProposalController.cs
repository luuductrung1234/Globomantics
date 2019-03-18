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
    public class ProposalController : ControllerBase
    {
        private readonly IProposalRepo _proposalRepo;

        public ProposalController(IConferenceRepo conferenceRepo,
            IProposalRepo proposalRepo)
        {
            _proposalRepo = proposalRepo;
        }

        [HttpGet("{conferenceId}")]
        public IActionResult GetAll(int conferenceId)
        {
            var proposals = _proposalRepo.GetAllForConference(conferenceId);

            if (!proposals.Any())
                return new NoContentResult();

            return new ObjectResult(proposals);
        }

        [HttpGet("{id}", Name = "GetById")]
        public ProposalModel GetById(int id)
        {
            return _proposalRepo.GetById(id);
        }

        [HttpPost]
        public IActionResult Add(ProposalModel model)
        {
            var addedProposal = _proposalRepo.Add(model);
            return CreatedAtRoute("GetById", new { id = addedProposal.Id },
                addedProposal);
        }

        [HttpPut("{proposalId}")]
        public IActionResult Approve(int proposalId)
        {
            try
            {
                return new ObjectResult(_proposalRepo.Approve(proposalId));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}