using Cooperchip.DiretoAoPonto.Data.FailedRepository.Abstraction;
using Cooperchip.DiretoAoPonto.Data.Orm;
using Cooperchip.DiretoAoPonto.Domain.Entities;

namespace Cooperchip.DiretoAoPonto.Data.FailedRepository
{
    public class PessoaFailedRepository : IPessoaFailedRepository
    {
        private readonly UowDbContext _context;

        public PessoaFailedRepository(UowDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarPessoa(Pessoa pessoa)
        {
            await _context.Pessoa.AddAsync(pessoa);
            await _context.SaveChangesAsync();
        }

    }
}
