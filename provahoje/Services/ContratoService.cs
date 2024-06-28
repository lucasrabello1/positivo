using prova.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace prova.Services
{
    public class ContratoService
    {
        private readonly List<Contrato> _contratos = new List<Contrato>();

        public ContratoService()
        {
            
            _contratos.AddRange(new List<Contrato>
            {
                new Contrato { Id = 1, ClienteId = 1, ServicoId = 1, PrecoCobrado = 100.0m, DataContratacao = DateTime.Now.AddDays(-10) },
                new Contrato { Id = 2, ClienteId = 1, ServicoId = 2, PrecoCobrado = 150.0m, DataContratacao = DateTime.Now.AddDays(-5) },
                new Contrato { Id = 3, ClienteId = 2, ServicoId = 1, PrecoCobrado = 120.0m, DataContratacao = DateTime.Now.AddDays(-3) },
                new Contrato { Id = 4, ClienteId = 2, ServicoId = 3, PrecoCobrado = 200.0m, DataContratacao = DateTime.Now.AddDays(-2) }
            });
        }

        public List<Contrato> ObterContratosPorCliente(int clienteId)
        {
            return _contratos.Where(c => c.ClienteId == clienteId).ToList();
        }
    }
}
