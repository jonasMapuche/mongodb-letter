using Letter.Models;
using Letter.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Letter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        public static readonly SongService _songsService = new SongService();

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Cosntruction of harmonic structures!");
        }

        [HttpGet("noten")]
        public async Task<List<Registro>> GetAll()
        {
            return await _songsService.GetAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Registro>> Get(string id)
        {
            var registro = await _songsService.GetAsync(id);
            if (registro is null)
                return NotFound();
            return registro;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post(Nota nota)
        {
            Registro registro = new Registro();
            registro.frequencia = nota.frequencia;
            registro.nota = nota;
            await _songsService.CreateAsync(registro);
            return CreatedAtAction(nameof(Get), new { id = registro.Id }, nota);
        }

        /*
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(Nota nota)
        {
            Registro registro = await _songsService.GetNotaAsync(nota.nome);
            if (registro is null)
            {
                return NotFound();
            }
            await _songsService.UpdateAsync(registro);
            return NoContent();
        }
 
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string nota)
        {
            Registro registro = await _songsService.GetNotaAsync(nota);
            if (registro is null)
            {
                return NotFound();
            }
            await _songsService.RemoveAsync(registro.Id);
            return NoContent();
        }
        */
    }
}
