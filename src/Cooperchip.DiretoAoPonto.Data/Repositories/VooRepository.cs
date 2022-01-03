using Cooperchip.DiretoAoPonto.Data.Orm;

namespace UnitOfWorkExample.Data.Repositories
{
    public class VooRepository : IVooRepository
    {
        private readonly UowDbContext _context;

        public VooRepository(UowDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task DecrementarPessoa(Guid? vooId)
        {
            if(vooId == null)
                throw new Exception("Id do Voo não pode ser nulo.");

            var voo = await _context.Voo.FindAsync(vooId);

            if (voo == null)
                throw new Exception("Voo nao encontrado");

            if (!voo.TemDisponibilidade())
                throw new Exception("Não há mais vagas disponiveis para este Voo.");

            voo.DecrementaDisponibilidade();

            _context.Voo.Update(voo);
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
