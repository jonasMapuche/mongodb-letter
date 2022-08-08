using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.Models
{
    public class Sujeito
    {
        public List<string> substantivo { get; set; }
        public List<string> pronome { get; set; }
        public List<string> artigo { get; set; }
    }
}
