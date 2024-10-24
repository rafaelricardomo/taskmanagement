using TaskManagement.Core.Dtos;

namespace TaskManagement.Core.Interfaces
{
    public interface ITarefaService
    {
        Task CriarTarefa(Guid projetoId, TarefaDto tarefaDto);
        Task RemoverTarefa(Guid projetoId, Guid tarefaId);
        Task AlterarTarefa(Guid projetoId, Guid tarefaId, TarefaDto tarefaDto);
        Task<List<TarefaDto>> ListarTarefas(Guid projetoId);
        Task<TarefaDetalheDto> ObterTarefaDetalhe(Guid projetoId, Guid tarefaId);
        Task CriarComentarioTarefa(Guid projetoId, Guid tarefaId, ComentarioDto comentarioDto);
    }
}
