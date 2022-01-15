using Cooperchip.DiretoAoPonto.Uow.Domain;
using System.ComponentModel.DataAnnotations;

namespace Cooperchip.DiretoAoPonto.UoW.Api.Models
{
    public class VooDTO
    {
        [Key]
        public Guid? Id { get; set; }

        [Required]
        [StringLength(40)]
        public string? Codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nota { get; set; }

        public int Capacidade { get; set; }
        public int Disponibilidade { get; set; }
    }
}
