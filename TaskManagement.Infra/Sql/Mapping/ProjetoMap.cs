using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Core.Entities;

namespace TaskManagement.Infra.Sql.Mapping
{
    public class ProjetoMap : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
               .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(p => p.DataInclusao)
               .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(p => p.DataAlteracao)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany<Tarefa>(t => t.Tarefas);
        }
    }
}
