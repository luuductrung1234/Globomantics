using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Services.Api
{
    public class ConferenceApiService : IConferenceService
    {
        private readonly HttpClient _client;

        //public ConferenceApiService(IHttpClientFactory htttClientFactory)
        //{
        //    _client = htttClientFactory.CreateClient("GlobomanticsApi");
        //}

        public ConferenceApiService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://localhost:5000");
            _client = httpClient;
        }

        public async Task<IEnumerable<ConferenceModel>> GetAll()
        {
            List<ConferenceModel> result;
            var response = await _client.GetAsync("/api/conference");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<List<ConferenceModel>>();
            else
                throw new HttpRequestException(response.ReasonPhrase);

            return result;
        }

        public async Task<ConferenceModel> GetById(int id)
        {
            var result = new ConferenceModel();
            var response = await _client.GetAsync($"/api/conference/{id}");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<ConferenceModel>();

            return result;
        }

        public async Task<StatisticsModel> GetStatistics()
        {
            var result = new StatisticsModel();
            var response = await _client.GetAsync($"/api/statistics");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<StatisticsModel>();

            return result;
        }

        public async Task Add(ConferenceModel model)
        {
            await _client.PostAsJsonAsync("/api/conference", model);
        }
    }
}
