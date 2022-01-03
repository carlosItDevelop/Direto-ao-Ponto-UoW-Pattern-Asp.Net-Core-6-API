using Cooperchip.DiretoAoPonto.Domain.Entities;
using UnitOfWorkExample.Data.Repositories.Abstractions;

namespace Cooperchip.DiretoAoPonto.Data.Repositories.Abstractions
{
    public interface IPessoaRepository : IUnitOfWork
    {
        Task AdicionarPessoa(Pessoa pessoa);
        Task ExcluirPessoasDoVoo(Guid vooId);
    }
}
