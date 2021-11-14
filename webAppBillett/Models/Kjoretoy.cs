using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Threading.Tasks;
namespace webAppBillett.Models
{
    public class Kjoretoy
    {
        public Kjoretoy()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int kjoretoyId { get; set; }
        public virtual List<RuteForekomstDatoTidKjoretoy> ruteForekomstDatoTidKjoretoy { get; set; }

        [ForeignKey("kjoretoyId")]
        public virtual List<BillettKjoretoy> BillettKjoretoy { get; set; }
        public string typeKjoretoy { get; set; }

        public string hoydeKlasse { get; set; }

        public string lengdeKlasse { get; set; }

        public int antattMaksVekt { get; set; }

        public double pris { get; set; }
        

    }
}