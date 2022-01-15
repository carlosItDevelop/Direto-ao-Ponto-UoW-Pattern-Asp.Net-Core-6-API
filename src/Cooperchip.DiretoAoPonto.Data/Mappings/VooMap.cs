using Cooperchip.DiretoAoPonto.Uow.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cooperchip.DiretoAoPonto.Data.Mappings
{
    public class VooMap : IEntityTypeConfiguration<Voo>
    {
        public void Configure(EntityTypeBuilder<Voo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Codigo)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnType("varchar");

            builder.Property(x => x.Nota)
                .HasMaxLength(100)
                .HasColumnType("varchar");

            // Relationship
            builder.HasMany(x => x.Pessoas).WithOne(x => x.Voo).HasForeignKey(fk=>fk.VooId);

        }
    }
}
