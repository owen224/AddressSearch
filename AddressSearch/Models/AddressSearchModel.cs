using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressSearch.Models
{
   /// <summary>
   /// 
   /// </summary>
    public class AddressSearchModel
        
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string SearchRequired { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string SearchTerm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public bool IsWelsh { get; set; }


    }
}
