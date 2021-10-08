using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
//
namespace webAppBillett.Models
{
    public class Rom
    {

        [Key, Column(Order = 0)]
        public int lugarId { get; set; }

        [Key, Column(Order = 1)]
        public string romNr { get; set; }

      

    }
}