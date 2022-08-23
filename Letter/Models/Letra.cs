using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.Models
{
    public class Letra
    {
        public String sigla { get; set; }
        public String nome { get; set; }
        public String acidente { get; set; }
        public String posicao { get; set; }
        public Boolean linha { get; set; }
        public int ordem { get; set; }
    }
}
