using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using prova.Models;
using prova.Services;

namespace prova.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicosController : ControllerBase
    {
        private readonly ServicoService _servicoService;

        public ServicosController(ServicoService servicoService)
        {
            _servicoService = servicoService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create([FromBody] Servico novoServico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var servicoCriado = _servicoService.AdicionarServico(novoServico);
            return CreatedAtAction(nameof(GetById), new { id = _servicoCriado.Id }, servicoCriado);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var servico = _servicoService.ObterServicoPorId(id);
            if (servico == null)
            {
                return NotFound();
            }

            return Ok(servico);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id, [FromBody] Servico servicoAtualizado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var atualizado = _servicoService.AtualizarServico(id, servicoAtualizado);
            if (!atualizado)
            {
                return NotFound("Serviço não encontrado.");
            }

            return NoContent();
        }
    }
}

