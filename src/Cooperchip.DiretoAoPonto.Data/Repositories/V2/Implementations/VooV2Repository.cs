using Cooperchip.DiretoAoPonto.Data.Orm;
using Cooperchip.DiretoAoPonto.Data.Repositories.V2.Abstrations;
using Cooperchip.DiretoAoPonto.Uow.Domain;

namespace Cooperchip.DiretoAoPonto.Data.Repositories.V2.Implementations
{
    public class VooV2Repository : IVooV2Repository
    {
        private readonly UoWDbContext _context;

        public VooV2Repository(UoWDbContext context)
        {
            _context = context;
        }

        public async Task DecrementarPessoa(Guid? vooId)
        {
            if (vooId == null)
                throw new Exception("Id do Voo não pode ser nulo.");

            var voo = await _context.Set<Voo>().FindAsync(vooId);

            if (voo == null)
                throw new Exception("Voo nao encontrado");

            if (!voo.TemDisponibilidade())
                throw new Exception("Não há mais vagas disponiveis para este Voo.");

            voo.DecremenentaDisponibilidade();

            _context.Set<Voo>().Update(voo);
        }

    }
}
