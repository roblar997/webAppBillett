using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace webAppBillett.Models
{
    public class RuteForekomstAaar
    {
        public RuteForekomstAaar()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int forekomstAaarId { get; set; }

        [Required]
        public string avgangsAaar { get; set; }

        [Required]
        public int ruteId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]


        public virtual List<RuteForekomstMaaned> RuteForekomstMaaned { get; set; }
    
        public bool erUtsolgt { get; set; }
    }
}