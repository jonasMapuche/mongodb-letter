using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.Models
{
    public class SemiFrase
    {
        public string Motivo { get; set; }
        public Celula Impulsos { get; set; }
        public int Compasso { get; set; }
        public Celula Repousos { get; set; }
    }
}
