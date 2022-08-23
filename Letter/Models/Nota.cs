using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.Models
{
    public class Nota
    {
        public List<Letra> letra { get; set; }
        public int nivel { get; set; }
        public float frequencia { get; set; }
    }
}
