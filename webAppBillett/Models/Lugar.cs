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

        [Required]
        public String bildeURL { get; set; }
        [Required]
        public String beskrivelse { get; set; }
        [Required]
        public int antall { get; set; }
        [Required]
        public int lugarType { get; set; }
        [Required]
        public String tittel { get; set; }
        [Required]
        public String romNr { get; set; }
        [Required]
        public double pris { get; set; }

        public virtual List<Reservasjon> reservasjon { get; set; }
        [Required]
        public bool harWc { get; set; }
        [Required]
        public bool harDysj { get; set; }
        [Required]
        public bool harWifi { get; set; }



    }
}