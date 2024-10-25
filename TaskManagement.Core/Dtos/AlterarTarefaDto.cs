using TaskManagement.Core.Enums;

namespace TaskManagement.Core.Dtos
{
    public record AlterarTarefaDto(Guid id,string titulo, string descricao, DateTime vencimento, StatusEnum status);
}
