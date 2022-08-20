using Letter.Models;
using Letter.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LetterController : ControllerBase
    {
        public static readonly LetterService _lettersService = new LetterService();
        public static readonly Grammar _grammar = new Grammar();
        public static readonly VersionService _version = new VersionService();

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on lessons!");
        }

        [HttpGet("abstrato")]
        public async Task<List<Aula>> GetAll()
        {
            return await _lettersService.GetAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Aula>> Get(string id)
        {
            var aula = await _lettersService.GetAsync(id);
            if (aula is null)
                return NotFound();
            return aula;
        }

        [HttpGet("sentence/simple/{id}")]
        public async Task<ActionResult<Abstrato>> GetSentenceSimple(String id)
        {
            var abstrato = await _grammar.GetSentenceSimple(id);
            if (abstrato is null)
                return NotFound();
            return abstrato;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post(Aula aula)
        {
            await _lettersService.CreateAsync(aula);
            return CreatedAtAction(nameof(Get), new { id = aula.Id }, aula);
        }

        [HttpGet("version")]
        public async Task<GitUserUrl> GetVersion()
        {
            return await _version.GetVersionAsync();
        }

        [HttpGet("post")]
        public async Task<ActionResult> PostVersion(String versao)
        {
            await _version.AddAulaAsync(versao);
            return Ok("Version " + versao + "!");
        }
    }
}
