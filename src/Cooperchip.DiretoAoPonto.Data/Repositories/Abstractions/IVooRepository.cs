using Cooperchip.DiretoAoPonto.Domain.Entities;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnitOfWorkExample.Data.Repositories.Abstractions;

namespace Cooperchip.DiretoAoPonto.Data.Repositories.Abstractions
{
    public interface IVooRepository : IUnitOfWork
    {
        Task DecrementarPessoa(Guid? vooId);
        Task UpdateVoo(Voo voo);
        Task<Voo> SelecionarPorId(Guid id);
        Task<IEnumerable<Voo>> SelecionarTodos(Expression<Func<Voo, bool>> quando = null);
        Task CriarVoo(Voo voo);
    }
}
