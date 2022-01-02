
using Cooperchip.DiretoAoPonto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cooperchip.DiretoAoPonto.Data.Mapping
{
    public class VooMap : IEntityTypeConfiguration<Voo>
    {
        public void Configure(EntityTypeBuilder<Voo> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(n => n.Codigo)
                .HasMaxLength(40)
                .HasColumnType("varchar")
                .IsRequired();


            builder.HasMany(x => x.Pessoas).WithOne(x => x.Voo).HasForeignKey(x => x.VooId);
        }
    }

}
