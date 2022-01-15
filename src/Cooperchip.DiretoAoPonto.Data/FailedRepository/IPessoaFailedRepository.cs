using Cooperchip.DiretoAoPonto.Uow.Domain;

namespace Cooperchip.DiretoAoPonto.Data.FailedRepository
{
    public interface IPessoaFailedRepository
    {
        Task AdicionarSeAoVoo(Pessoa pessoa);
    }
}
