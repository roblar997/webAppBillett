using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAppBillett.Models
{
    public class FilterLugar
    {
        public FilterLugar()
        {

        }


        [Range(0, 100000)]
        [Required]
        public int prisMin { get; set; }

        [Range(0, 100000)]
        [Required]
        public int prisMaks {get; set; }

        [Range(0, 100000)]
        [Required]
        public int antall { get; set; }

        [Required]
        public bool harWc { get; set; }
        [Required]
        public bool harDysj { get; set; }
        [Required]
        public bool harWifi { get; set; }

        public int fra { get; set; }

        public int til { get; set; }

        public string avgangsDato { get; set; }

        public string avgangsTid { get; set; }



    }
}