namespace Cooperchip.DiretoAoPonto.Api.Configurations.AppSettings
{
    public class VooSettings
    {
        public const string SectionName = nameof(VooSettings);


        public Guid Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nota { get; set; } = null;
        public int Capacidade { get; set; }
        public int Disponibilidade { get; set; }
    }
}

