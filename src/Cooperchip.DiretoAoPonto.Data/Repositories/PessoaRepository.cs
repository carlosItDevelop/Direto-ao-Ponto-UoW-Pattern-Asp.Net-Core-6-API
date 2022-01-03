using Cooperchip.DiretoAoPonto.Data.Orm;
using Cooperchip.DiretoAoPonto.Data.Repositories.Abstractions;
using Cooperchip.DiretoAoPonto.Domain.Entities;

namespace UnitOfWorkExample.Data.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly UowDbContext _context;

        public PessoaRepository(UowDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarPessoa(Pessoa pessoa)
        {
            await _context.Set<Pessoa>().AddAsync(pessoa);
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
