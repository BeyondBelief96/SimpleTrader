using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.FinancialModelingPrepAPI
{
    public class FinancialModelingPrepHttpClient : HttpClient
    {
        #region Constructor

        public FinancialModelingPrepHttpClient()
        {
            base.BaseAddress = new Uri("https://financialmodelingprep.com//api/v3/");
        }

        #endregion

        #region Methods

        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage response =
                await GetAsync($"{uri}?apikey=4a679c22083aca0dddb2285d59efcf70");
            string jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }

        #endregion
    }
}
