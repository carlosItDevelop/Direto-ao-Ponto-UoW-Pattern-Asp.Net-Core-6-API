namespace Cooperchip.DiretoAoPonto.Data.FailedRepository
{
    public interface IVooFailedRepository
    {
        Task DecrementarVaga(Guid? vooId);
    }
}
