using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TESTAPI;

namespace TESTAPI
{
    public class DataClient
    {
        private HttpClient _client;
        private static string _address;
        private static string _apiKey;

        public DataClient()
        {
            _client = new HttpClient();
            _address = Constants.adress;
            _client.BaseAddress = new Uri(_address);
        }

        public async Task<List<CountryInfo>> GetPageData(string newQuestion)
        {
            var apiUrl = $"{_address}{newQuestion}";
            Console.WriteLine(apiUrl);
            var response = await _client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CountryInfo>>(content);
            return result;
        }
    }
}
