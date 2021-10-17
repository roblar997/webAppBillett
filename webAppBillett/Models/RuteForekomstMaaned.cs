using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace webAppBillett.Models
{
    public class RuteForekomstMaaned
    {
        public RuteForekomstMaaned()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int forekomstMaanedId { get; set; }

        [Required]
        public string avgangsDag { get; set; }

        [Required]
        public string avgangsMaaned { get; set; }



        [Required]
        public int ruteId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]

        public virtual List<RuteForekomstDag> RuteForekomstDag { get; set; }

        public bool erUtsolgt { get; set; }
    }
}