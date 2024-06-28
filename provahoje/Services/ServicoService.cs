using prova.Models;

namespace prova.Services
{
    public class ServicoService
    {
        private readonly List<Servico> _servicos = new List<Servico>();

        public Servico AdicionarServico(Servico novoServico)
        {
            novoServico.Id = _servicos.Count + 1; 
            _servicos.Add(novoServico);
            return novoServico;
        }

        public Servico ObterServicoPorId(int id)
        {
            return id > 0 && id <= _servicos.Count ? _servicos[id - 1] : null; 
        }

        public bool AtualizarServico(int id, Servico servicoAtualizado)
        {
            var servicoExistente = ObterServicoPorId(id);
            if (servicoExistente == null)
            {
                return false;
            }

            servicoExistente.Nome = servicoAtualizado.Nome;
            servicoExistente.Preco = servicoAtualizado.Preco;
            servicoExistente.Status = servicoAtualizado.Status;
            return true;
        }
    }
}


