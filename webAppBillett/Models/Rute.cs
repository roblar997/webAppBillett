using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Threading.Tasks;
namespace webAppBillett.Models
{
    public class Rute
    {
        public Rute()
        {

        }

     
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ruteId { get; set; }


        public int fra { get; set; }

        public int til { get; set; }

        public float prisVoksen { get; set; }
        public float prisBarn { get; set; }

        [ForeignKey("ruteId")]
        public virtual List<RuteForekomstDato> ruteForekomstDato { get; set; }
    }
}