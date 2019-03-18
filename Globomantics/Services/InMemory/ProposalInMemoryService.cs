using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Services.InMemory
{
    public class ProposalInMemoryService : IProposalService
    {
        private readonly List<ProposalModel> _proposals = new List<ProposalModel>();

        public ProposalInMemoryService()
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

        public Task Add(ProposalModel model)
        {
            model.Id = _proposals.Max(p => p.Id) + 1;
            _proposals.Add(model);
            return Task.CompletedTask;
        }

        public Task<ProposalModel> Approve(int proposalId)
        {
            return Task.Run(() =>
            {
                var proposal = _proposals.FirstOrDefault(p => p.Id == proposalId);
                if (proposal != null)
                {
                    proposal.Approved = true;
                }
                return proposal;
            });
        }

        public Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            return Task.Run(() =>
            {
                return _proposals.Where(p => p.ConferenceId == conferenceId).AsEnumerable();
            });
        }
    }
}
