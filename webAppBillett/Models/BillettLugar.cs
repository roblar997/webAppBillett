﻿using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
//
namespace webAppBillett.Models
{
    public class BillettLugar
    {

        [Key, Column(Order = 0)]
        public int billettId { get; set; }

        [Key, Column(Order = 1)]
        public int lugarId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Billett billett { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Lugar lugar { get; set; }

        //For å hindre at en bestiller lugarer som allerede er tatt
        public int fra { get; set; }
        public int til { get; set; }
        public string avgangsDato { get; set; }

        public string avgangsTid { get; set; }

    }
}