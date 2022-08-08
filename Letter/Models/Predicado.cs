using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.Models
{
    public class Predicado
    {
        public List<string> verbo { get; set; }
        public List<string> preposicao { get; set; }
        public List<string> adverbio { get; set; }
        public List<string> adjetivo { get; set; }
        public List<string> interjeicao { get; set; }
        public List<string> numeral { get; set; }
        public List<string> conjuncao { get; set; }
    }
}
