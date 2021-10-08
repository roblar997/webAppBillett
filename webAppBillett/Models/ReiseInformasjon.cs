using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAppBillett.Models
{
    public class ReiseInformasjon
    {
        public ReiseInformasjon()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int reiseId { get; set; }
        [Required]
        public int fra { get; set; }
        [Required]
        public int til { get; set; }
        [Required]
        public string avgangsDato { get; set; }
        [Required]
        public string avgangsTid { get; set; }


        [RegularExpression(@"[0-9]{4}")]
        [Required]
        public int antVoksen { get; set; }


        [RegularExpression(@"[0-9]{4}")]
        [Required]
        public int antBarn { get; set; }



    }
}
