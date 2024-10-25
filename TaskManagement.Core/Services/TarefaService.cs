using TaskManagement.Core.Dtos;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Interfaces;

namespace TaskManagement.Core.Services
{
    public class TarefaService(
        IProjetoRepository projetoRepository,
        IHistoricoRepository historicoRepository,
        IUsuarioRepository usuarioRepository
        ) : ITarefaService
    {
       

        public async Task AlterarTarefa(Guid projetoId, Guid tarefaId, AlterarTarefaDto tarefaDto)
        {
            var projeto = await projetoRepository.Obter(projetoId);
            if (projeto == null) return;

            var tarefaAnterior = projeto.ClonarTarefa(tarefaId);

            projeto.AtualizarTarefa(
                tarefaId,
                tarefaDto.titulo,
                tarefaDto.descricao,
                tarefaDto.status
            );

            var tarefaAtual = projeto.ObterTarefa(tarefaId);

            await projetoRepository.Alterar(projeto);

            var usuario = await usuarioRepository.Obter();
            await EnviarHistorico(tarefaAnterior, tarefaAtual, usuario);
        }

        public async Task CriarComentarioTarefa(Guid projetoId, Guid tarefaId, CriarComentarioDto comentarioDto)
        {
            var projeto = await projetoRepository.Obter(projetoId);
            if (projeto == null) return;

            var tarefaAnterior = projeto.ClonarTarefa(tarefaId);

            var usuario = await usuarioRepository.Obter();

            projeto.ComentarTarefa(
                tarefaId,
                comentarioDto.descricao,
                usuario
            );

            var tarefaAtual = projeto.ObterTarefa(tarefaId);

            await projetoRepository.Alterar(projeto);

            await EnviarHistorico(tarefaAnterior, tarefaAtual, usuario);
        }


        public async Task CriarTarefa(Guid projetoId, CriarTarefaDto tarefaDto)
        {
            var projeto = await projetoRepository.Obter(projetoId);
            if (projeto == null) return;

            if (projeto.AtingiuLimiteTarefas)
                throw new InvalidOperationException("Projeto atingiu limite de tarefas");


            projeto.AdicionarTarefa(
                tarefaDto.titulo,
                tarefaDto.descricao,
                tarefaDto.vencimento,
                tarefaDto.prioridade
                );

            var tarefaAnterior = projeto.ClonarTarefa(Guid.Empty);
            var tarefaAtual = projeto.ObterTarefa(Guid.Empty);

            await projetoRepository.Alterar(projeto);

            var usuario = await usuarioRepository.Obter();
            await EnviarHistorico(tarefaAnterior, tarefaAtual, usuario);

        }

        public async Task<List<TarefaDto>?> ListarTarefas(Guid projetoId)
        {
            var projeto = await projetoRepository.Obter(projetoId);
            if (projeto == null) return null;

            return projeto.Tarefas?.Select(t =>
                new TarefaDto(t.Id,
                            t.Titulo,
                            t.Descricao,
                            t.Vencimento,
                            t.Prioridade,
                            t.Status)
                ).ToList() ?? new List<TarefaDto>();
        }

        public async Task<TarefaDetalheDto?> ObterTarefaDetalhe(Guid projetoId, Guid tarefaId)
        {
            var projeto = await projetoRepository.Obter(projetoId);
            if (projeto == null) return null;

            var tarefa = projeto.Tarefas?.FirstOrDefault(t => t.Id == tarefaId);
            if (tarefa == null) return null;

            return new TarefaDetalheDto(
                tarefa.Id,
                tarefa.Titulo,
                tarefa.Descricao,
                tarefa.Vencimento,
                tarefa.Prioridade,
                tarefa.Status,
                tarefa.Comentarios.Select(c =>
                    new ComentarioDto(
                        c.Id, 
                        c.Descricao
                        )
                ).ToList() ?? new List<ComentarioDto>()
                );
        }

        public async Task RemoverTarefa(Guid projetoId, Guid tarefaId)
        {
            var projeto = await projetoRepository.Obter(projetoId);
            if (projeto == null) return;

            projeto.RemoverTarefa(tarefaId);

            await projetoRepository.Alterar(projeto);
        }

        private async Task EnviarHistorico(Tarefa tarefaAnterior, Tarefa tarefaAtual, Usuario usuario)
        {           
            if (tarefaAnterior == null || tarefaAtual == null || usuario == null) return;

            var historico = new Historico(
                "Histórico de tarefas",
                tarefaAnterior,
                tarefaAtual,
                usuario
                );

            await historicoRepository.Criar(historico);
        }
    }
}
