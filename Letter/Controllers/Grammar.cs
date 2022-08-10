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

            Sujeito sujeito = new Sujeito(substantivo, pronome, "");
            Predicado predicado = new Predicado(verbo, "", "", "", "", "", "");
            Oracao oracao = new Oracao(sujeito, predicado);
            Expressao expressao = new Expressao(oracao);
            Abstrato texto = new Abstrato(abstrato.nome, expressao);

            return texto;
        }
    }
}
