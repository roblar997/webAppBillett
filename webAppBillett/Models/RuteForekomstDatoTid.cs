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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int forekomstDatoTidId { get; set; }

        public int ruteId { get; set; }


        public string avgangsDato { get; set; }

        public string avgangsTid { get; set; }


        public string ankomstDato { get; set; }


        public string ankomstTid { get; set; }


        public int forekomstDatoId { get; set; }

    }
}