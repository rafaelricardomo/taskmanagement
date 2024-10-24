using TaskManagement.Core.Enums;

namespace TaskManagement.Core.Dtos
{
    public record TarefaDto(Guid id,string titulo, string descricao, DateTime vencimento, PrioridadeEnum prioridade, StatusEnum status);
}
