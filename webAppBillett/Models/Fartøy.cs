using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Threading.Tasks;
namespace webAppBillett.Models
{
    public class Fartøy
    {
        public Fartøy()
        {

        }

        [Key]
        public int fartøyId { get; set; }

        public string navn { get; set; }
        public string kjenningsSignal { get; set; }

        public int imoNr { get; set; }

        public int csrNr { get; set; }


        [ForeignKey("fartøyId")]
        public virtual List<RuteForekomstDatoTid> ruteforekomstdatotid { get; set; }
    }
}