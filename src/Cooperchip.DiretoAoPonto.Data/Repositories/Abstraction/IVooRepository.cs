using Cooperchip.DiretoAoPonto.Uow.Domain;
using System.Linq.Expressions;

namespace Cooperchip.DiretoAoPonto.Data.Repositories.Abstraction
{
    public interface IVooRepository : IUnitOfWork
    {
        Task DecrementarVaga(Guid? vooId);
        Task UpdateVoo(Voo voo);
        Task <Voo> SelecionarPorId(Guid? id);
        Task<IEnumerable<Voo>> SelecionarTodos(Expression<Func<Voo, bool>> quando = null);
        Task CriarVoo(Voo voo);
    }
}
