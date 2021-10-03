using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace webAppBillett.Models
{
    public class Rute
    {
        public Rute()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ruteId { get; set; }

        public string fra { get; set; }

        public string til { get; set; }

        [ForeignKey("ruteId")]
        

        public virtual List<RuteForekomstDato> ruteForekomstDato { get; set; }
    }
}