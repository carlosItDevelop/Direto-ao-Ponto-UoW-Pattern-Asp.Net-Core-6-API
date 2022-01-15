using Cooperchip.DiretoAoPonto.Data.Orm;
using Cooperchip.DiretoAoPonto.Data.Repositories.V2.Abstrations;
using Cooperchip.DiretoAoPonto.Uow.Domain;

namespace Cooperchip.DiretoAoPonto.Data.Repositories.V2.Implementations
{
    public class PessoaV2Repository : IPessoaV2Repository
    {
        private readonly UoWDbContext _context;
        public PessoaV2Repository(UoWDbContext context) => _context = context;

        public async Task AdicionarPessoa(Pessoa pessoa) => await _context.Set<Pessoa>().AddAsync(pessoa);
    }

}
