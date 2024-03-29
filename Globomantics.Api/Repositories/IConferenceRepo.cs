﻿using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Api.Repositories
{
    public interface IConferenceRepo
    {
        Task<ConferenceModel> Add(ConferenceModel model);

        Task<IEnumerable<ConferenceModel>> GetAll();

        Task<ConferenceModel> GetById(int id);
    }
}
