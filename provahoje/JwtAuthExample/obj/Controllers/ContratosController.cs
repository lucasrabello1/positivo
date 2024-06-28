using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using prova.Models;
using prova.Services;

namespace prova.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratosController : ControllerBase
    {
        private readonly ContratoService _contratoService;

        public ContratosController(ContratoService contratoService)
        {
            _contratoService = contratoService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create([FromBody] Contrato novoContrato)
        {
          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            var contratoRegistrado = _contratoService.RegistrarContrato(novoContrato.ClienteId, novoContrato.ServicoId, novoContrato.PrecoCobrado);
            return CreatedAtAction(nameof(GetById), new { id = contratoRegistrado.Id }, contratoRegistrado);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var contrato = _contratoService.ObterContratoPorId(id);
            if (contrato == null)
            {
                return NotFound();
            }

            return Ok(contrato);
        }
    }
}
