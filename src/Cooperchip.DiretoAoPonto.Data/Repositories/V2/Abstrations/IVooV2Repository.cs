namespace Cooperchip.DiretoAoPonto.Data.Repositories.V2.Abstrations
{
    public interface IVooV2Repository
    {
        Task DecrementarPessoa(Guid? vooId);
    }
}
