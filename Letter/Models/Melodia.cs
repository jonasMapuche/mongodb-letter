using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Letter.Models
{
    public class Melodia
    {
        public string Nome { get; set; }
        public List<Periodo> Periodos { get; set; }
    }
}
