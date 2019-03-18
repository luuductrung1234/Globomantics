using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Globomantics.Controllers
{
    public class ProposalController : Controller
    {
        private readonly IConferenceService _conferenceService;
        private readonly IProposalService _proposalService;

        public ProposalController(IConferenceService conferenceService, IProposalService proposalService)
        {
            _conferenceService = conferenceService;
            _proposalService = proposalService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int conferenceId)
        {
            var conference = await _conferenceService.GetById(conferenceId);
            ViewBag.Title = $"Proposals For Conference {conference.Name} {conference.Location}";
            ViewBag.ConferenceId = conferenceId;

            return View(await _proposalService.GetAll(conferenceId));
        }

        [HttpGet]
        public IActionResult Add(int conferenceId)
        {
            ViewBag.Title = "Add Proposal";
            return View(new ProposalModel { ConferenceId = conferenceId });
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProposalModel proposal)
        {
            if (ModelState.IsValid)
            {
                await _proposalService.Add(proposal);
            }

            return RedirectToAction("Index", new { conferenceId = proposal.ConferenceId });
        }

        public async Task<IActionResult> Approve(int proposalId)
        {
            var proposal = await _proposalService.Approve(proposalId);
            return RedirectToAction("Index", new { conferenceId = proposal.ConferenceId });
        }
    }
}