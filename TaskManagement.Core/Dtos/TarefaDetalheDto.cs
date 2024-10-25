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
