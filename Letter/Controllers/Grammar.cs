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
            Aula aula = await _lettersService.GetSentenceSimpleAsync(lesson);

            String pronome = aula.conteudo.pronome[0].ToString();

            String verbo = aula.conteudo.verbo[0].ToString();

            String substantivo = aula.conteudo.substantivo[0].ToString();

            Sujeito sujeito = new Sujeito("", pronome, "");
            Predicado predicado = new Predicado(verbo, "", "", "", "", "", "", substantivo, "", "");
            Oracao oracao = new Oracao(sujeito, predicado);
            Expressao expressao = new Expressao(oracao);
            Abstrato frase = new Abstrato(aula.nome, expressao);

            return frase;
        }
    }
}
