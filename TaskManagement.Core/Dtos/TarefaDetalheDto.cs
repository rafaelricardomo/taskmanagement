using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Enums;

namespace TaskManagement.Core.Dtos
{
    public record TarefaDetalheDto(
        Guid id, 
        string titulo,
        string descricao,
        DateTime vencimento,
        PrioridadeEnum prioridade,
        StatusEnum status,
        List<ComentarioDto> comentarios
        );
}
