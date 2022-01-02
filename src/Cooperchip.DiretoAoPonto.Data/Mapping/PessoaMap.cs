using Cooperchip.DiretoAoPonto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cooperchip.DiretoAoPonto.Data.Mapping
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(n => n.Nome).HasMaxLength(50)
                .IsRequired();

            builder.Property(pk => pk.VooId)
                .IsRequired();


            //builder.HasOne(x => x.Voo).WithMany(x => x.Pessoas).HasForeignKey(x => x.VooId);
        }
    }
}
