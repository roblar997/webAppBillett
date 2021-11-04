﻿using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Threading.Tasks;
namespace webAppBillett.Models
{
    public class BillettKjoretoy
    {
        public BillettKjoretoy()
        {

        }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Billett billett{ get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Kjoretoy kjoretoy { get; set; }

        [Key, Column(Order = 0)]
        public int billettId { get; set; }


        [Key, Column(Order = 1)]
        public int kjoretoyId { get; set; }


        public bool harVåpen { get; set; }
        public bool harElApparat { get; set; }
        public bool harSproyteBeholder { get; set; }
        public bool harGassBeholder { get; set; }

        public int antKjæledyr { get; set; }

        public string infoInnhold { get; set; }

    }
}