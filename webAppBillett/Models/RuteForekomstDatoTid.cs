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

        [Key, Column(Order = 0)]
        public int ruteId { get; set; }

        [Key, Column(Order = 1)]
        public string avgangsDato { get; set; }

        [Key, Column(Order = 2)]
        public string avgangsTid { get; set; }


        public string ankomstDato { get; set; }


        public string ankomstTid { get; set; }



    }
}