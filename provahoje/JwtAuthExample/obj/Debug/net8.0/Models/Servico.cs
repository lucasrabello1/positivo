using System.ComponentModel.DataAnnotations;

namespace prova.Models
{
    public class Servico
    {
        [Required]
        public string Nome { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser um valor positivo.")]
        public decimal Preco { get; set; }

        public bool Status { get; set; }
    }
}
