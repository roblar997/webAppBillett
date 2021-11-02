using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Threading.Tasks;
namespace webAppBillett.Models
{
    public class RuteForekomstDatoTidKjoretoy
    {
        public RuteForekomstDatoTidKjoretoy()
        {

        }

     

        public virtual RuteForekomstDatoTid ruteforekomstDatoTid{ get; set; }
        public virtual Kjoretoy kjoretoy { get; set; }
        [Key, Column(Order = 0)]
        public int ruteForekomstDatoTidId { get; set; }
        [Key, Column(Order = 1)]
        public int kjoretoyId { get; set; }

        public int maksAntall { get; set; }
        public int antReservert { get; set; }
    }
}