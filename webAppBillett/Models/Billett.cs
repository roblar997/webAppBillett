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



        [ForeignKey("betalingsId")]
        public virtual List<Betaling > betaling { get; set; }

        const int INF = 999999;




        [Required]
        [Range(1, INF)]
        public int fra { get; set; }


        [Required]
        [Range(1, INF)]
        public int til { get; set; }



        [Required]
        public string avgangsDato { get; set; }


        [Required]

        public string avgangsTid { get; set; }


        [Required]
        [Range(0, 10)]
        public int antVoksen { get; set; }


        [Required]
        [Range(0, 10)]

        public int antBarn { get; set; }

    }
}