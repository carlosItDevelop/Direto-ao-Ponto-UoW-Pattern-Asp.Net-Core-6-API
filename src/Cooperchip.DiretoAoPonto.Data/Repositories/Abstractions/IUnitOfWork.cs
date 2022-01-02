namespace UnitOfWorkExample.Data.Repositories.Abstractions
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        Task Rollback();
    }
}
