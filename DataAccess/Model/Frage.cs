﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Frage
    {
        [Key]
        public int FrageId { get; set; }
        [Required]
        public string Bezeichnung { get; set; }

        public virtual List<Antwort> Antworten { get; set; }
        
        public Sparte Sparte { get; set; }
    }
}
