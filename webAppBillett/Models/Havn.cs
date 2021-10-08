using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace webAppBillett.Models
{
    public class Havn
    {
        public Havn()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int havnId { get; set; }
        [Required]
        public string navn { get; set; }


        [ForeignKey("fra")]
        public virtual List<Rute> ruteFra{ get; set; }

        [ForeignKey("til")]
        public virtual List<Rute> ruteTil { get; set; }
    }
}