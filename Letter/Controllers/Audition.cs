using Letter.Models;
using Letter.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.Controllers
{
    public class Audition
    {
        public static readonly SongService _songsService = new SongService();

        public async Task<ActionResult<Melodia>> GetMagorChord(string nota)
        {
            int contador = 0;
            Registro registro = await _songsService.GetSongAsync(nota);
            contador = 13;
            List<Registro> reg = await _songsService.GetSongNextAsync(registro.nota.frequencia, contador);
            Melodia melodia = new Melodia();
            melodia.Nome = "Dó Maior";
            melodia.Periodos[0].Motivo = "pergunta";
            melodia.Periodos[0].Pentagramas[0].Clave = "sol";
            melodia.Periodos[0].Pentagramas[0].Armaduras = null;
            melodia.Periodos[0].Pentagramas[0].Ritimo = "4/4";
            melodia.Periodos[0].Pentagramas[0].Frases[0].Motivo = "pergunta";
            melodia.Periodos[0].Pentagramas[0].Frases[0].SemiFrases[0].Motivo = "pergunta";
            
            melodia.Periodos[0].Pentagramas[0].Frases[0].SemiFrases[0].Impulsos.Acordes[0].Nota = reg[0].nota.letra[0].nome;
            melodia.Periodos[0].Pentagramas[0].Frases[0].SemiFrases[0].Impulsos.Acordes[0].Nome = "minima";
            melodia.Periodos[0].Pentagramas[0].Frases[0].SemiFrases[0].Impulsos.Acordes[0].Linha = 1;
            melodia.Periodos[0].Pentagramas[0].Frases[0].SemiFrases[0].Impulsos.Acordes[0].Posicao = "inferior";
            melodia.Periodos[0].Pentagramas[0].Frases[0].SemiFrases[0].Impulsos.Acordes[0].Frequencia = reg[3].nota.frequencia;

            melodia.Periodos[0].Pentagramas[0].Frases[0].SemiFrases[0].Impulsos.Acordes[1].Nota = reg[2].nota.letra[0].nome;
            melodia.Periodos[0].Pentagramas[0].Frases[0].SemiFrases[0].Impulsos.Acordes[1].Nome = "minima";
            melodia.Periodos[0].Pentagramas[0].Frases[0].SemiFrases[0].Impulsos.Acordes[1].Espaco = 1;
            melodia.Periodos[0].Pentagramas[0].Frases[0].SemiFrases[0].Impulsos.Acordes[1].Posicao = "inferior";
            melodia.Periodos[0].Pentagramas[0].Frases[0].SemiFrases[0].Impulsos.Acordes[1].Frequencia = reg[3].nota.frequencia;


            return null;
        }

        public async Task<ActionResult<Melodia>> GetMinorChord(string nota)
        {
            await Task.Delay(500);
            return null;
        }

    }
}
