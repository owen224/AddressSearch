using Newtonsoft.Json;

namespace AddressSearch.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AddressSearchResponseModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("columns")]
        public string[] Columns { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("data")]
        public string[][] Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("total")]
        public long Total { get; set; }
    }
}


