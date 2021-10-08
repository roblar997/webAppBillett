using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAppBillett.Models
{
    public class Person
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int personId { get; set; }

        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}")]
        [Required]
        public String fornavn { get; set; }//

        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}")]
        [Required]
        public String etternavn { get; set; }



        [RegularExpression(@"[0-9]{8,15}")]
        [Required]
        public String telefon { get; set; }

        public virtual List<BillettPerson> billett { get; set; }
    }
}