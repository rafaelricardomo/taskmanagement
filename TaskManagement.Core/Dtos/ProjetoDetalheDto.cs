namespace TaskManagement.Core.Dtos
{
    public record ProjetoDetalheDto(Guid id, string nome, List<TarefaDto> tarefas);
}
