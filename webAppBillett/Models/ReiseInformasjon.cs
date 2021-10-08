﻿using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAppBillett.Models
{
    public class ReiseInformasjon
    {
        const int INF = 999999;

        public ReiseInformasjon()
        {

        }
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Range(1, INF)]
        public int reiseId { get; set; }


        [Required]
        [Range(1, INF)]
        public int fra { get; set; }

 
        [Required]
        [Range(1, INF)]
        public int til { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public string avgangsDato { get; set; }


        [Required]
        [DataType(DataType.Time)]
        public string avgangsTid { get; set; }


        [Required]
        [Range(1, 10)]
        public int antVoksen { get; set; }


        [Required]
        [Range(1,10)]

        public int antBarn { get; set; }



    }
}
