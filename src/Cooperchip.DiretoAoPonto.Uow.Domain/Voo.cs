using Cooperchip.DiretoAoPonto.Uow.Domain.Base;

namespace Cooperchip.DiretoAoPonto.Uow.Domain
{
    public class Voo : EntityBase
    {
        public Voo()
        {
            Pessoas = new List<Pessoa>();
        }

        public string? Codigo { get; set; }
        public string? Nota { get; set; }
        public int Capacidade { get; set; }
        public int Disponibilidade { get; set; }

        // EF Retionship
        public ICollection<Pessoa>? Pessoas { get; set; }  

        public void DecremenentaDisponibilidade()
        {
            Disponibilidade -= 1;
        }


        public bool TemDisponibilidade()
        {
            return Disponibilidade > 0;
        }

    }
}
