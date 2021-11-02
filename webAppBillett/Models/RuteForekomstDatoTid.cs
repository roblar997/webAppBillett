using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace webAppBillett.Models
{
    public class RuteForekomstDatoTid
    {
        public RuteForekomstDatoTid()
        {

        }

        [Key]
        public int ruteForekomstDatoTidId { get; set; }

        public int ruteId { get; set; }

        public string avgangsDato { get; set; }
        public string avgangsTid { get; set; }
        public virtual List<RuteForekomstDatoTidKjoretoy> ruteForekomstDatoTidKjoretoys { get; set; }

        [Required]
        public string ankomstDato { get; set; }

        [Required]
        public string ankomstTid { get; set; }
        [Required]

        public int forekomstDatoId { get; set; }

   
        public bool erUtsolgt { get; set; }
    }
}