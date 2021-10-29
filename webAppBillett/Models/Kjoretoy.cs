using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Threading.Tasks;
namespace webAppBillett.Models
{
    public class Kjoretoy
    {
        public Kjoretoy()
        {

        }

     

        public string typeKjoretoy { get; set; }
        
        public int antattMaksVekt { get; set; }

    }
}