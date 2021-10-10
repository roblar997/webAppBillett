using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAppBillett.Models
{
    public class Registrering
    {
        public Registrering()
        {
            // this.personer = new HashSet<Person>();
            // this.lugarer = new HashSet<Lugar>();
        }

       public ReiseInformasjon reiseInformasjon { get; set; }
        public  Betaling betaling { get; set; }
        public  List<Person> personer { get; set; }
        public  List<int> lugarId {get; set; }

    }
}