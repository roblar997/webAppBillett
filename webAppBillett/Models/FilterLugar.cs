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
        [Required]
        public int prisMin { get; set; }
        [Required]
        public int prisMaks {get; set; }
        [Required]
        public int antall { get; set; }
        [Required]
        public bool harWc { get; set; }
        [Required]
        public bool harDysj { get; set; }
        [Required]
        public bool harWifi { get; set; }





    }
}