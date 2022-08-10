using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.Models
{
    public class Abstrato
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public String nome { get; set; }
        public List<Expressao> expressao { get; set; }

        public Abstrato() { }

        public Abstrato(String nome, Expressao expressao)
        {
            this.nome = nome;
            this.expressao = new List<Expressao>();
            this.expressao.Add(expressao);
        }
    }
}
