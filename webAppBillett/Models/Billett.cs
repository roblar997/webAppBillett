using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAppBillett.Models
{
    public class Billett
    {
        public Billett()
        {
            // this.personer = new HashSet<Person>();
            // this.lugarer = new HashSet<Lugar>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int billettId { get; set; }

        public double pris { get; set; }



        public virtual List<BillettPerson> billettPerson { get; set; }
        public virtual List<Reservasjon> reservasjoner { get; set; }

        [ForeignKey("reiseId")]
        public virtual List<ReiseInformasjon> ReiseInformasjon { get; set; }


        [ForeignKey("betalingsId")]
        public virtual List<Betaling > betaling { get; set; }
    }
}