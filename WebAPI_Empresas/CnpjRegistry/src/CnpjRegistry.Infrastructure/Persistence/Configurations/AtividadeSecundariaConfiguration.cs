using CnpjRegistry.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CnpjRegistry.Infrastructure.Persistence.Configurations;

public class AtividadeSecundariaConfiguration : IEntityTypeConfiguration<AtividadeSecundaria>
{
    public void Configure(EntityTypeBuilder<AtividadeSecundaria> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        // TODO: Ajustar propriedades conforme necessário.
    }
}
