namespace Cooperchip.DiretoAoPonto.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }
        public Guid? Id { get; set; }
    }
}
