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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bagasjeId { get; set; }

        public int billettId { get; set; }

        [Required]
        public bool harSykkel { get; set; }
        public virtual Billett billett{ get; set; }
        [Required]
        public bool harVåpen { get; set; }
        [Required]
        public bool harElApparat { get; set; }
        [Required]
        public bool harSproyteBeholder { get; set; }
        [Required]
        public bool harGassBeholder { get; set; }

        [Required]
        public int antKjæledyr { get; set; }
        
        [Required]
        public string infoInnhold { get; set; }

    }
}