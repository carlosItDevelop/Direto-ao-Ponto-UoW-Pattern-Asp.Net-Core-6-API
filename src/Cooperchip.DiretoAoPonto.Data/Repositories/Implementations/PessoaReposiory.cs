using Cooperchip.DiretoAoPonto.Data.Orm;
using Cooperchip.DiretoAoPonto.Data.Repositories.Abstraction;
using Cooperchip.DiretoAoPonto.Uow.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cooperchip.DiretoAoPonto.Data.Repositories.Implementations
{
    public class PessoaReposiory : IPessoaRepository
    {
        private readonly UoWDbContext _context;

        public PessoaReposiory(UoWDbContext context) => _context = context;

        public async Task AdicionarSeAoVoo(Pessoa pessoa) => await _context.Set<Pessoa>().AddAsync(pessoa);

        public async Task ExcluirPessoasDoVoo(Guid vooId)
        {
            var pessoas = await _context.Set<Pessoa>().AsNoTracking().Where(p=>p.VooId == vooId).ToListAsync();
            _context.Set<Pessoa>().RemoveRange(pessoas);
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task Rollback()
        {
            /*
             * Aqui você pode fazer log, avisar a alguém ou algum setor ou processo.
             * Caso você esteja usando ADO com Transaction ou algo similar, você
             * poderá executar o RollBack de verdade.
             * No nosso exemplo, aqui, basta finalizarmos a tarefa e deixar o método
             * como possibilidade de extensão para outros Devs.
             */
            return Task.CompletedTask;
        }
    }
}
