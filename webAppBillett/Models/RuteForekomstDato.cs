using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace webAppBillett.Models
{
    public class RuteForekomstDato
    {
        public RuteForekomstDato()
        {

        }


        [Key, Column(Order = 0)]
        public int ruteId { get; set; }

        [Key, Column(Order = 1)]
        public string avgangsDato { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<RuteForekomstDatoTid> RuteForekomstDatoTid { get; set; }
    }
}