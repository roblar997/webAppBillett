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

        public string avgang { get; set; }

        public string ankomst{ get; set; }


    }
}