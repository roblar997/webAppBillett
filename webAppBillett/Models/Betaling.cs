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
        public string kortholderNavn { get; set; }
        public string postnr { get; set; }
        public string poststed { get; set; }
        public string telefon { get; set; }
        public string adresse { get; set; }
        public string email { get; set; }
        public int csv { get; set; }

        public double pris { get; set; }
    }
}