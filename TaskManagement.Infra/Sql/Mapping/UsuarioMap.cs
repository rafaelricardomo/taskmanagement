using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Core.Entities;

namespace TaskManagement.Infra.Sql.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(p => p.DataInclusao)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(p => p.DataAlteracao)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
