namespace Cooperchip.DiretoAoPonto.Data.FailedRepository.Abstraction
{
    public interface IVooFailedRepository
    {
        Task DecrementarPessoa(Guid? vooId);
    }
}
