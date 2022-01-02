using Cooperchip.DiretoAoPonto.Domain.Entities;
using UnitOfWorkExample.Data.Repositories.Abstractions;

namespace UnitOfWorkExample.Data.Repositories
{
    public interface IPessoaRepository : IUnitOfWork
    {
        Task AdicionarPessoa(Pessoa pessoa);
    }
}
