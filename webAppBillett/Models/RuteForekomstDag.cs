using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace webAppBillett.Models
{
    public class RuteForekomstDag
    {
        public RuteForekomstDag()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int forekomstDagId { get; set; }

        [Required]
        public string avgangsDag { get; set; }

        [Required]
        public string avgangsMaaned { get; set; }

        [Required]
        public string avgangsAar { get; set; }

        [Required]
        public int ruteId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]

        [ForeignKey("forekomstDatoId")]
        public virtual List<RuteForekomstDatoTid> RuteForekomstDatoTid { get; set; }

        public bool erUtsolgt { get; set; }
    }
}