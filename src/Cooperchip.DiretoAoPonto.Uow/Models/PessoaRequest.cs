using System.ComponentModel.DataAnnotations;

namespace Cooperchip.DiretoAoPonto.Uow.Models
{
    public class PessoaRequest
    {
        [MaxLength(50)]
        public string? Nome { get; set; }

        [Required]
        public Guid? VooId { get; set; }
    }
}
