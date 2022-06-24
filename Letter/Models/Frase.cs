using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.Models
{
    public class Frase
    {
        public string Motivo { get; set; }
        public List<SemiFrase> SemiFrases { get; set; }
    }
}
