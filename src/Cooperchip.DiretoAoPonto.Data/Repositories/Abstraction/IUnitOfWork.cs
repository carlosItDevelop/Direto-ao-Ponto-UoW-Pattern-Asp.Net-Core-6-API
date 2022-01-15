namespace Cooperchip.DiretoAoPonto.Data.Repositories.Abstraction
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        Task Rollback();
    }
}
