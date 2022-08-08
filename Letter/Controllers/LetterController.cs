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

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on lessons!");
        }

        [HttpGet("abstrato")]
        public async Task<List<Abstrato>> GetAll()
        {
            return await _lettersService.GetAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Abstrato>> Get(string id)
        {
            var abstrato = await _lettersService.GetAsync(id);
            if (abstrato is null)
                return NotFound();
            return abstrato;
        }

        [HttpGet("sentence/simple")]
        public async Task<ActionResult<Abstrato>> GetSentenceSimple()
        {
            var abstrato = await _grammar.GetSentenceSimple("lesson1");
            if (abstrato is null)
                return NotFound();
            return abstrato;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post(Abstrato abstrato)
        {
            await _lettersService.CreateAsync(abstrato);
            return CreatedAtAction(nameof(Get), new { id = abstrato.Id }, abstrato);
        }
    }
}
