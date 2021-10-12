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

        [Required]
        public int fra { get; set; }

        [Required]
        public int til { get; set; }

        [Required]

        public DateTime avgangsDato { get; set; }
        [Required]

        public DateTime avgangsTid { get; set; }



    }
}