using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using prova.Services;
using prova.Models; 
using System;
using System.Collections.Generic;

namespace prova.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class ClientesController : ControllerBase
    {
        private readonly ContratoService _contratoService;

        public ClientesController(ContratoService contratoService)
        {
            _contratoService = contratoService ?? throw new ArgumentNullException(nameof(contratoService));
        }
        [HttpGet("{clienteId}/servicos")]
        [ProducesResponseType(typeof(List<Contrato>), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetServicosContratados(int clienteId)
        {
            var contratos = _contratoService.ObterContratosPorCliente(clienteId);
            if (contratos == null || contratos.Count == 0)
            {
                return NotFound($"Nenhum contrato encontrado para o cliente com ID {clienteId}.");
            }

            return Ok(contratos);
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using prova.Data;
using prova.Models;
using System.Collections.Generic;
using System.Linq;

namespace prova.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{clienteId}/servicos")]
        public IActionResult GetServicosContratados(int clienteId)
        {
            var contratos = _context.Contratos
                .Where(c => c.ClienteId == clienteId)
                .ToList();

            if (contratos == null || contratos.Count == 0)
            {
                return NotFound($"Nenhum contrato encontrado para o cliente com ID {clienteId}.");
            }

            return Ok(contratos);
        }
    }
}
