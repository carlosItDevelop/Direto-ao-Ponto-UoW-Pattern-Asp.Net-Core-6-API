using System.ComponentModel.DataAnnotations;

namespace Cooperchip.DiretoAoPonto.Uow.Models
{
    public class PessoaDTO
    {
        [Required]
        [Key]
        public Guid? Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nome { get; set; }

        [Required]
        public Guid? VooId { get; set; }
    }
}
