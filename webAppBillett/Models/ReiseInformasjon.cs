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
        public string reisetype { get; set; }
        public int fra { get; set; }
        public int til { get; set; }

        public string avgangsDato { get; set; }
        public string avgangsTid { get; set; }
        public int antVoksen { get; set; }

        public int antBarn { get; set; }



    }
}
