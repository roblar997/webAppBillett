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

        public int prisMin { get; set; }
        public int prisMaks {get; set; }
        public int antall { get; set; }

        public bool harWc { get; set; }
        public bool harDysj { get; set; }
        public bool harWifi { get; set; }





    }
}