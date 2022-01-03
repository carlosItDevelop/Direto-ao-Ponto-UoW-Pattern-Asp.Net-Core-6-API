using System.Threading.Tasks;
using UnitOfWorkExample.Data.Repositories.Abstractions;

namespace Cooperchip.DiretoAoPonto.Data.Repositories.Abstractions
{
    public interface IVooRepository : IUnitOfWork
    {
        Task DecrementarPessoa(Guid? vooId);
    }
}
