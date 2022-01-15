namespace Cooperchip.DiretoAoPonto.Data.Repositories.V2.Abstrations
{
    public interface IUnitOfW
    {
        Task<bool> Commit();
        Task Rollback();
    }
}
