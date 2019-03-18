using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Services.Api
{
    public class ProposalApiService : IProposalService
    {
        private readonly HttpClient _client;

        //public ProposalApiService(IHttpClientFactory httpClientFactory)
        //{
        //    _client = httpClientFactory.CreateClient("GlobomanticsApi");
        //}

        public ProposalApiService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://localhost:5000");
            _client = httpClient;
        }

        public async Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            var result = new List<ProposalModel>();

            var response = await _client.GetAsync($"/api/proposal/{conferenceId}");

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<List<ProposalModel>>();
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }

        public async Task Add(ProposalModel model)
        {
            await _client.PostAsJsonAsync("/api/proposal", model);
        }

        public async Task<ProposalModel> Approve(int proposalId)
        {
            var response = await _client.PutAsync($"/api/proposal/{proposalId}",
                null);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<ProposalModel>();
            }
            throw new ArgumentException($"Error retrieving proposal {proposalId}" +
                $" Response: {response.ReasonPhrase}");
        }
    }
}
