using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAppBillett.Models
{
    public class Betaling
    {
        public Betaling()
        {
            // this.personer = new HashSet<Person>();
            // this.lugarer = new HashSet<Lugar>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int betalingsId { get; set; }

        public int kortnummer { get; set; }

        public string utloper { get; set; }

        public int csv { get; set; }

    
    }
}