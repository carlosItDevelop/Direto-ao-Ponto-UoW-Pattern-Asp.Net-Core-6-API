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

        public void DecrementaDisponibilidade()
        {
            Disponibilidade -= 1;
        }

        public bool TemDisponibilidade()
        {
            return Disponibilidade > 0;
        }
    }
}


/*
            if(vooId == null)
                throw new Exception("Id do Voo não pode ser nulo.");

            var voo = await _context.Voo.FindAsync(vooId);

            if (voo == null)
                throw new Exception("Voo nao encontrado");

            if (voo.Disponibilidade <= 0)
                throw new Exception("Não há mais vagas disponiveis para este Voo.");

            voo.Disponibilidade -= 1; 
 */