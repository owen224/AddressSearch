using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressSearch.Controllers
{
    [Produces("application/json")]
    [Route("api/AddressSearch")]
    public class AddressSearchController : Controller
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<string> Get(string Language, string SearchTerm, string SearchRequired)
        {
            string result =
                "http://ishare.caerdydd.gov.uk/getdata.aspx?service=LocationSearch&RequestType=LocationSearch&location=CF5%204AN&pagesize=2000&startnum=1&mapsource=Cardiff_Live/welsh_myhouse"; 
            return new string[] { "value1", "value2" };
        }
    }
}