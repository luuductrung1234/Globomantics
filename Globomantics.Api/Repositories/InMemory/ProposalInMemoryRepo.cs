using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Api.Repositories.InMemory
{
    public class ProposalInMemoryRepo : IProposalRepo
    {
        private readonly List<ProposalModel> _proposals = new List<ProposalModel>();

        public ProposalInMemoryRepo()
        {
            _proposals.Add(new ProposalModel
            {
                Id = 1,
                ConferenceId = 1,
                Speaker = "Roland Guijt",
                Title = "Understanding ASP.NET Core Security"
            });
            _proposals.Add(new ProposalModel
            {
                Id = 2,
                ConferenceId = 2,
                Speaker = "John Reynolds",
                Title = "Starting Your Developer Career"
            });
            _proposals.Add(new ProposalModel
            {
                Id = 3,
                ConferenceId = 2,
                Speaker = "Stan Lipens",
                Title = "ASP.NET Core TagHelpers"
            });
        }

        public Task<IEnumerable<ProposalModel>> GetAllForConference(int conferenceId)
        {
            return Task.Run(() => _proposals.Where(p => p.ConferenceId == conferenceId));
        }

        public Task<ProposalModel> Add(ProposalModel model)
        {
            return Task.Run(() =>
            {
                model.Id = _proposals.Max(p => p.Id) + 1;
                _proposals.Add(model);
                return model;
            });
        }

        public Task<ProposalModel> Approve(int proposalId)
        {
            return Task.Run(() =>
            {
                var proposal = _proposals.First(p => p.Id == proposalId);
                proposal.Approved = true;
                return proposal;
            });
        }

        public Task<ProposalModel> GetById(int id)
        {
            return Task.Run(() => _proposals.Single(p => p.Id == id));
        }
    }
}
