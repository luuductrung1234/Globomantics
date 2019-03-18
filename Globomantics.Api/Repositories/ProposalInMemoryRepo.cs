﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Api.Repositories
{
    public class ProposalInMemoryRepo : IProposalRepo
    {
        private readonly List<ProposalModel> proposals = new List<ProposalModel>();

        public ProposalInMemoryRepo()
        {
            proposals.Add(new ProposalModel
            {
                Id = 1,
                ConferenceId = 1,
                Speaker = "Roland Guijt",
                Title = "Understanding ASP.NET Core Security"
            });
            proposals.Add(new ProposalModel
            {
                Id = 2,
                ConferenceId = 2,
                Speaker = "John Reynolds",
                Title = "Starting Your Developer Career"
            });
            proposals.Add(new ProposalModel
            {
                Id = 3,
                ConferenceId = 2,
                Speaker = "Stan Lipens",
                Title = "ASP.NET Core TagHelpers"
            });
        }

        public IEnumerable<ProposalModel> GetAllForConference(int conferenceId)
        {
            return proposals.Where(p => p.ConferenceId == conferenceId);
        }

        public ProposalModel Add(ProposalModel model)
        {
            model.Id = proposals.Max(p => p.Id) + 1;
            proposals.Add(model);
            return model;
        }

        public ProposalModel Approve(int proposalId)
        {
            var proposal = proposals.First(p => p.Id == proposalId);
            proposal.Approved = true;
            return proposal;
        }

        public ProposalModel GetById(int id)
        {
            return proposals.Single(p => p.Id == id);
        }
    }
}
