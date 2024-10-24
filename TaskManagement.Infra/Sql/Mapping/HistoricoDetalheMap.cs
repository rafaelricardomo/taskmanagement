using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Entities;

namespace TaskManagement.Infra.Sql.Mapping
{
    public class HistoricoDetalheMap : IEntityTypeConfiguration<HistoricoDetalhe>
    {
        public void Configure(EntityTypeBuilder<HistoricoDetalhe> builder)
        {
            builder.HasKey(p=>p.Id);

            builder.Property(p => p.ValorNovo)
               .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(p => p.ValorAntigo)
              .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(p => p.Campo)
              .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(p => p.DataInclusao)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(p => p.DataAlteracao)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
