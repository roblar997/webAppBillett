using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAppBillett.Models
{
    //----Regex hentet litt tilfeldig fra internett. 

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



        [RegularExpression(@"[0-9]{10,15}")]
        [Required]
        public string kortnummer { get; set; }
        [Required]
        public string utloper { get; set; }


        [Required]
        public string kortholderNavn { get; set; }

        [RegularExpression(@"[0-9]{4,4}")]
        [Required]
        public string postnr { get; set; }



        [Required]
        public string poststed { get; set; }


        
        [RegularExpression(@"[0-9]{8,15}")]
        [Required]
  
        public string telefon { get; set; }


        [Required]
        public string adresse { get; set; }

       

        [Required]

        public string email { get; set; }

        [RegularExpression(@"[0-9]{3,3}")]
        [Required]
        public int csv { get; set; }


        public double pris { get; set; }
    }
}