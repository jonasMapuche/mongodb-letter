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

        public Predicado() { }

        public Predicado(String verbo, String preposicao, String adverbio, String adjetivo, String interjeicao, String numeral, String conjuncao)
        {
            this.verbo = new List<string>();
            this.preposicao = new List<string>();
            this.adverbio = new List<string>();
            this.adjetivo = new List<string>();
            this.interjeicao = new List<string>();
            this.numeral = new List<string>();
            this.conjuncao = new List<string>();
            this.verbo.Add(verbo);
            this.preposicao.Add(preposicao);
            this.adjetivo.Add(adjetivo);
            this.adverbio.Add(adverbio);
            this.interjeicao.Add(interjeicao);
            this.numeral.Add(numeral);
            this.conjuncao.Add(conjuncao);
        }
    }
}

