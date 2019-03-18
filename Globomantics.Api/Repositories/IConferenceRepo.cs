using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Api.Repositories
{
    public interface IConferenceRepo
    {
        ConferenceModel Add(ConferenceModel model);

        IEnumerable<ConferenceModel> GetAll();

        ConferenceModel GetById(int id);
    }
}
