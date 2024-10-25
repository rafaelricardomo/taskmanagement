using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Core.Entities;

namespace TaskManagement.Infra.Sql.Mapping
{
    public class ComentarioMap : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {            
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(p => p.DataInclusao)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(p => p.DataAlteracao)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.HasOne<Usuario>(t => t.Usuario);
        }
    }
}
