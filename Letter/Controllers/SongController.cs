using Letter.Models;
using Letter.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        public static readonly SongService _songsService = new SongService();

        [HttpGet("noten")]
        public async Task<List<Musica>> GetAll()
        {
            return await _songsService.GetAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Musica>> Get(string id)
        {
            var musica = await _songsService.GetAsync(id);
            if (musica is null)
                return NotFound();
            return musica;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post(Musica musica)
        {
            await _songsService.CreateAsync(musica);
            return CreatedAtAction(nameof(Get), new { id = musica.Id }, musica);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(Musica musica)
        {
            Musica melodiaLocal = await _songsService.GetAsync(musica.Id);
            if (melodiaLocal is null)
            {
                return NotFound();
            }
            await _songsService.UpdateAsync(musica);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            Musica musica = await _songsService.GetAsync(id);
            if (musica is null)
            {
                return NotFound();
            }
            await _songsService.RemoveAsync(musica.Id);
            return NoContent();
        }
    }
}
