using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Threading.Tasks;
namespace webAppBillett.Models
{
    public class BillettKjoretoy
    {
        public BillettKjoretoy()
        {

        }

        public virtual Billett billett{ get; set; }
        public virtual Kjoretoy kjoretoy { get; set; }

        public bool harVåpen { get; set; }
        public bool harElAparat { get; set; }
        public bool harSproyteBeholder { get; set; }
        public bool harGassBeholder { get; set; }

        public int antKjæledyr { get; set; }

        public string infoInnhold { get; set; }

    }
}