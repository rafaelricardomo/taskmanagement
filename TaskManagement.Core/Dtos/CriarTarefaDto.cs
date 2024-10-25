using TaskManagement.Core.Enums;

namespace TaskManagement.Core.Dtos
{
    public record CriarTarefaDto(string titulo, string descricao, DateTime vencimento, PrioridadeEnum prioridade);
}
