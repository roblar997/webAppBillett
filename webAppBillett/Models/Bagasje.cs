using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Threading.Tasks;
namespace webAppBillett.Models
{
    public class Bagasje
    {
        public Bagasje()
        {

        }

        [Key]
        public int bagasjeId { get; set; }

        public int billettId { get; set; }

        public bool harSykkel { get; set; }
        public virtual Billett billett{ get; set; }
        public bool harVåpen { get; set; }
        public bool harElApparat { get; set; }
        public bool harSproyteBeholder { get; set; }
        public bool harGassBeholder { get; set; }


        public int antKjæledyr { get; set; }

        public string infoInnhold { get; set; }

    }
}