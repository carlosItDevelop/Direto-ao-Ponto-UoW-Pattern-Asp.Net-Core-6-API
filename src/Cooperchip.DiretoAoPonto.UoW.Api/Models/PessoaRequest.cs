using System.ComponentModel.DataAnnotations;

namespace Cooperchip.DiretoAoPonto.UoW.Api.Models
{
    public class PessoaRequest
    {
        [StringLength(50, ErrorMessage = "O campo {0} tem no máximo {1} caracteres!")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string? Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public Guid? VooId { get; set; }
    }
}
