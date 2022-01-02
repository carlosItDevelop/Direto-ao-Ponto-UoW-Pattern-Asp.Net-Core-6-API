using Cooperchip.DiretoAoPonto.Domain.Entities.Base;

namespace Cooperchip.DiretoAoPonto.Domain.Entities
{
    public class Voo : EntityBase
    {
        // EF
        public Voo(){}

        public string? Codigo { get; set; }
        public string? Nota { get; set; }
        public int Capacidade { get; set; }
        public int Disponibilidade { get; set; }

        // Ef Relations
        public IEnumerable<Pessoa>? Pessoas { get; set; }
    }
}
