using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AddressSearch.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorResponseModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Exception { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
         
      
        {
            return JsonConvert.SerializeObject(this);

        }

    }
}