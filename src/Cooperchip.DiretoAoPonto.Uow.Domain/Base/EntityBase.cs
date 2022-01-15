namespace Cooperchip.DiretoAoPonto.Uow.Domain.Base
{
    public class EntityBase
    {
        public EntityBase()
        {
            Id =  Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
