using Cooperchip.DiretoAoPonto.Domain.Entities.Base;
using System.Text.Json.Serialization;

namespace Cooperchip.DiretoAoPonto.Domain.Entities
{
    public class Pessoa : EntityBase
    {
        // EF
        public Pessoa(){}

        public string? Nome { get; set; }
        public Guid? VooId { get; set; }

        [JsonIgnore]
        public Voo? Voo { get; set; }

    }    
}

