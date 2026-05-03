using FCG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCG.Infra.Mapping;

public class PromocaoMapping : IEntityTypeConfiguration<Promocao>
{
    public void Configure(EntityTypeBuilder<Promocao> builder)
    {
        builder.ToTable("Promocoes");

        builder.HasOne(x => x.Jogo)
            .WithMany(x => x.Promocoes)
            .HasForeignKey(x => x.IdJogo);

        builder.Property(x => x.PercentualDesconto)
            .HasColumnType("decimal(5, 2)")
            .IsRequired();

        builder.Property(x => x.DataInicio)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(x => x.DataFim)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(x => x.Ativa)
            .IsRequired();

    }
}
