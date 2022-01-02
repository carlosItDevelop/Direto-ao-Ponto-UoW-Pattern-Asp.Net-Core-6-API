using Cooperchip.DiretoAoPonto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cooperchip.DiretoAoPonto.Data.Orm
{
    public class UowDbContext : DbContext
    {
        public UowDbContext(){}

        public UowDbContext(DbContextOptions<UowDbContext> options) 
            : base(options){}

        public DbSet<Pessoa>? Pessoa { get; set; }
        public DbSet<Voo>? Voo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // onde não tiver setado varchar e a propriedade for do tipo string fica valendo varchar(valor)
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
            {
                //property.Relational().ColumnType = "varchar(100)"; .Net 2.2
                property.SetColumnType("varchar(100)");
            }

            // Todo: Busca os Mapppings de uma vez só
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UowDbContext).Assembly);

            // Todo: remover exclusão em cascata
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientNoAction;

            base.OnModelCreating(modelBuilder);
        }
    }
}
