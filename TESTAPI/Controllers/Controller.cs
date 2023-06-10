using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Logging;
using TESTAPI;
using System.Drawing.Printing;

namespace TESTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WikipediaController : ControllerBase
    {
        private readonly DataClient _cityInfo;


        public WikipediaController(DataClient dataClient)
        {
            _cityInfo = dataClient;
        }

        [HttpGet]
        [Route("getcountry")]
        public async Task<List<CountryInfo>> GetCountryData(string newQuestion)
        {
            var info = await _cityInfo.GetPageData(newQuestion);
            return info;
        }
    }
}