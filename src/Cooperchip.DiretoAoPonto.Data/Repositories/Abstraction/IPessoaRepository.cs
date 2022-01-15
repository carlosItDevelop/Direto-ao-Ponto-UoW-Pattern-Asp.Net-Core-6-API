using Cooperchip.DiretoAoPonto.Uow.Domain;

namespace Cooperchip.DiretoAoPonto.Data.Repositories.Abstraction
{
    public interface IPessoaRepository : IUnitOfWork
    {
        Task AdicionarSeAoVoo(Pessoa pessoa);
        Task ExcluirPessoasDoVoo(Guid vooId);
    }
}
