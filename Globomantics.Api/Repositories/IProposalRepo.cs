using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Api.Repositories
{
    public interface IProposalRepo
    {
        Task<ProposalModel> Add(ProposalModel model);

        Task<ProposalModel> Approve(int proposalId);

        Task<IEnumerable<ProposalModel>> GetAllForConference(int conferenceId);

        Task<ProposalModel> GetById(int id);
    }
}
