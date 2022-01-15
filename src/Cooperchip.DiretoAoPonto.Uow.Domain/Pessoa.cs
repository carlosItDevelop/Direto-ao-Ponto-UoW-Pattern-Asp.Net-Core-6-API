using Cooperchip.DiretoAoPonto.Uow.Domain.Base;
using System.Text.Json.Serialization;

namespace Cooperchip.DiretoAoPonto.Uow.Domain
{
    public class Pessoa : EntityBase
    {
        public Pessoa()
        {

        }

        public string? Nome { get; set; }
        public Guid? VooId { get; set; }

        [JsonIgnore]
        public Voo? Voo { get; set; }

    }
}