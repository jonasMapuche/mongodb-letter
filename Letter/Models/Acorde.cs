using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.Models
{
    public class Acorde
    {
        public int Ordem { get; set; }
        public string Nota { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public string Acidente { get; set; }
        public bool PontoAumento { get; set; }
        public bool PontoDiminuicao { get; set; }
        public int Linha { get; set; }
        public int Espaco { get; set; }
        public string Posicao { get; set; }
        public float Frequencia { get; set; }
        public bool Acento { get; set; } 
    }
}
