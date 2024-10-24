using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Core.Entities;

namespace TaskManagement.Infra.Sql.Mapping
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Titulo)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(p => p.Vencimento)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(p => p.Status)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(p => p.Prioridade)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(p => p.Descricao)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(p => p.DataInclusao)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(p => p.DataAlteracao)
                .UsePropertyAccessMode(PropertyAccessMode.Field);


            builder.HasMany<Comentario>(t => t.Comentarios);
        }
    }
}
