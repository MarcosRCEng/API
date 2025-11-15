using CnpjRegistry.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CnpjRegistry.Infrastructure.Persistence.Configurations;

public class AtividadePrincipalConfiguration : IEntityTypeConfiguration<AtividadePrincipal>
{
    public void Configure(EntityTypeBuilder<AtividadePrincipal> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        // TODO: Ajustar propriedades conforme necessário.
    }
}
