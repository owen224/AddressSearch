using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AddressSearch.Api.Filters;
using AddressSearch.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace AddressSearch.Controllers
{
    /// <summary>
    /// </summary>
    [Produces("application/json")]
    [Route("api/AddressSearch")]
    public class AddressSearchController : Controller

    {
        /// <summary>
        /// Address search
        /// </summary>
        /// <param name="addressSearch"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(AddressSearchResponseModel), 200)]
        [ModelValidation]
        [Authorize]
        public AddressSearchResponseModel Post([FromBody]AddressSearchModel addressSearch)
        {


            AddressSearchResponseModel result;
            string language = string.Empty;
            if (addressSearch.IsWelsh)
            {
                language = "welsh_";
            }
            using (WebClient wc = new WebClient())
            {
                result = JsonConvert.DeserializeObject<AddressSearchResponseModel>(wc.DownloadString($"http://ishare.cardiff.gov.uk/getdata.aspx?service=LocationSearch&RequestType=LocationSearch&location={addressSearch.SearchTerm}&pagesize=2000&startnum=1&mapsource=Cardiff_Live/{language}myhouse"));
            }
           
            return result;


         

        }
    }
}
