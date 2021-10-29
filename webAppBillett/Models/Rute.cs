﻿using System;

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

        [Required]
        public int fra { get; set; }
        [Required]
        public int til { get; set; }
        [Required]
        public double prisVoksen { get; set; }
        [Required]
        public double prisBarn { get; set; }

        public int makspersonBiler { get; set; }
        public int makspersonbilTilhenger { get; set; }

        public int makslastebil { get; set; }

        public int makslettLastebil { get; set; }

        public int maksmotorsykkel { get; set; }

        public int maksminibuss { get; set; }


        public int maksbuss { get; set; }

        public int maksmoped { get; set; }

        public int makstraktor { get; set; }
        public int makssnoScooter { get; set; }

        [ForeignKey("ruteId")]
        public virtual List<RuteForekomstDato> ruteForekomstDato { get; set; }
    }
}