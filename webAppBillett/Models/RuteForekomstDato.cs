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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int forekomstId { get; set; }

        public string avgangsDato { get; set; }
        public int ruteId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]

        [ForeignKey("forekomstId")]
        public virtual List<RuteForekomstDatoTid> RuteForekomstDatoTid { get; set; }
    }
}