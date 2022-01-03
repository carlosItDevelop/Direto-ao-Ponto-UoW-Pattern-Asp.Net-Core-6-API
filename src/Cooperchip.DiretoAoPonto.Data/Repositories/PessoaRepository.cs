using Cooperchip.DiretoAoPonto.Data.Orm;
using Cooperchip.DiretoAoPonto.Data.Repositories.Abstractions;
using Cooperchip.DiretoAoPonto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task ExcluirPessoasDoVoo(Guid vooId)
        {
            var p = await _context.Set<Pessoa>().AsNoTracking().Where(x=>x.VooId == vooId).ToListAsync();
            _context.Set<Pessoa>().RemoveRange(p);
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
