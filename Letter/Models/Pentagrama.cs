using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.Models
{
    public class Pentagrama
    {
        public string Clave { get; set; }
        public List<Armadura> Armaduras { get; set; }
        public string Ritimo { get; set; }
        public List<Frase> Frases { get; set; }
    }
}
