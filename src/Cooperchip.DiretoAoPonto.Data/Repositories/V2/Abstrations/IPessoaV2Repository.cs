using Cooperchip.DiretoAoPonto.Uow.Domain;

namespace Cooperchip.DiretoAoPonto.Data.Repositories.V2.Abstrations
{
    public interface IPessoaV2Repository
    {
        Task AdicionarPessoa(Pessoa pessoa);
    }

}
