﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.Models
{
    public class Periodo
    {
        public string Motivo { get; set; }
        public List<Pentagrama> Pentagramas { get; set; }
    }
}
