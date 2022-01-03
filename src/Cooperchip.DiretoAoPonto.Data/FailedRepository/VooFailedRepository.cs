using Cooperchip.DiretoAoPonto.Data.FailedRepository.Abstraction;
using Cooperchip.DiretoAoPonto.Data.Orm;

namespace Cooperchip.DiretoAoPonto.Data.FailedRepository
{
    public class VooFailedRepository : IVooFailedRepository
    {
        private readonly UowDbContext _context;

        public VooFailedRepository(UowDbContext context)
        {
            _context = context;
        }

        public async Task DecrementarPessoa(Guid? vooId)
        {
            if (vooId == null)
                throw new Exception("Id do Voo não pode ser nulo.");

            var voo = await _context.Voo.FindAsync(vooId);

            if (voo == null)
                throw new Exception("Voo nao encontrado");

            if (!voo.TemDisponibilidade())
                throw new Exception("Não há mais vagas disponiveis para este Voo.");

            voo.DecrementaDisponibilidade();

            _context.Voo.Update(voo);
            _context.SaveChanges();
        }

    }
}
