using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAppBillett.Models
{
    public class Lugar
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int lugarId { get; set; }


        public String bildeURL { get; set; }
        public String beskrivelse { get; set; }
        public int antall { get; set; }
        public String tittel { get; set; }

        public double pris { get; set; }

        public virtual List<BillettLugar> billettLugar { get; set; }


         public bool harWc { get; set; }

        public bool harDysj { get; set; }

         public bool harWifi { get; set; }



    }
}