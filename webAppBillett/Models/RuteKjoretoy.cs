using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Threading.Tasks;
namespace webAppBillett.Models
{
    public class RuteKjoretoy
    {
        public RuteKjoretoy()
        {

        }

     

        public virtual Rute rute{ get; set; }
        public virtual Kjoretoy kjoretoy { get; set; }

        public int maksAntall { get; set; }
        public int antReservert { get; set; }
    }
}