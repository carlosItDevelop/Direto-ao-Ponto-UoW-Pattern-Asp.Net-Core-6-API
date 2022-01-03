using Cooperchip.DiretoAoPonto.Domain.Entities;

namespace Cooperchip.DiretoAoPonto.Data.FailedRepository.Abstraction
{
    public interface IPessoaFailedRepository
    {
        Task AdicionarPessoa(Pessoa pessoa);
    }
}
