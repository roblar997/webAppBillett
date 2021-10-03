using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace webAppBillett.Models
{
    public class RuteForekomst
    {
        public RuteForekomst()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int forekomstId { get; set; }

        public string avgangsTid { get; set; }

        public string ankomstTid{ get; set; }

        public string avgangsDato { get; set; }

        public string ankomstDato { get; set; }


    }
}