using System.Threading.Tasks;
using UnitOfWorkExample.Data.Repositories.Abstractions;

namespace UnitOfWorkExample.Data.Repositories
{
    public interface IVooRepository : IUnitOfWork
    {
        Task DecrementarPessoa(Guid? vooId);
    }
}
