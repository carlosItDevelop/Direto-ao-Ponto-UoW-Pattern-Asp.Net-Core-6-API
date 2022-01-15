using Cooperchip.DiretoAoPonto.Data.Orm;
using Cooperchip.DiretoAoPonto.Data.Repositories.V2.Abstrations;

namespace Cooperchip.DiretoAoPonto.Data.Repositories.V2.Implementations
{
    public class UnitOfW : IUnitOfW
    {
        private readonly UoWDbContext _context;

        public UnitOfW(UoWDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task Rollback()
        {
            await Task.CompletedTask;
        }
    }
}
