using Letter.Models;
using Letter.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.Controllers
{
    public class Grammar
    {
        public static readonly LetterService _lettersService = new LetterService();

        public async Task<ActionResult<Abstrato>> GetSentenceSimple(string lesson)
        {
            Abstrato abstrato = await _lettersService.GetSentenceSimpleAsync(lesson);

            String pronome = abstrato.expressao[0].oracao[0].sujeito.pronome[0].ToString();

            String verbo = abstrato.expressao[0].oracao[0].predicado.verbo[0].ToString();

            String substantivo = abstrato.expressao[0].oracao[0].sujeito.substantivo[0].ToString();

            Abstrato texto = new Abstrato();
            Expressao expressao = new Expressao();
            Oracao oracao = new();
            Sujeito sujeito = new();
            Predicado predicado = new Predicado();

            sujeito.pronome.Add(pronome);
            sujeito.substantivo.Add(substantivo);
            predicado.verbo.Add(verbo);
            oracao.sujeito = sujeito;
            oracao.predicado = predicado;
            expressao.oracao.Add(oracao);
            texto.nome = abstrato.nome;
            texto.expressao.Add(expressao);

            return texto;
        }
    }
}
