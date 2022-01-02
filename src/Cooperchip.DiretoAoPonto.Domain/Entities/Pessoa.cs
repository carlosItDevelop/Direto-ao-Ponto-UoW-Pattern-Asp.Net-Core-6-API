﻿using Cooperchip.DiretoAoPonto.Domain.Entities.Base;

namespace Cooperchip.DiretoAoPonto.Domain.Entities
{
    public class Pessoa : EntityBase
    {
        // EF
        public Pessoa(){}

        public string? Nome { get; set; }
        public Guid? VooId { get; set; }
        public Voo? Voo { get; set; }
    }    
}
