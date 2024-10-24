using TaskManagement.Core.Dtos;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Interfaces;

namespace TaskManagement.Core.Services
{
    public class ProjetoService(
        IProjetoRepository projetoRepository
        ) : IProjetoService
    {
        public async Task AlterarProjeto(Guid projetoId, ProjetoDto projetoDto)
        {
            var projeto = await projetoRepository.Obter(projetoId);
            if (projeto == null) return;

            projeto.Atualizar(projetoDto.nome);
            await projetoRepository.Alterar(projeto);
        }

        public async Task CriarProjeto(ProjetoDto projetoDto)
        {
            var projeto = new Projeto(projetoDto.nome);
            await projetoRepository.Criar(projeto);
        }

        public async Task<List<ProjetoDto>> ListarProjetos()
        {
            var projetos = await projetoRepository.Listar();

            return projetos.Select(p => new ProjetoDto(p.Id, p.Nome)).ToList();
        }

        public async Task<ProjetoDetalheDto> ObterProjetoDetalhe(Guid projetoId)
        {
            var projeto = await projetoRepository.Obter(projetoId);
            if (projeto == null) return null;

            return new ProjetoDetalheDto(
                projeto.Id,
                projeto.Nome,
                projeto.Tarefas?.Select(t =>
                new TarefaDto(t.Id,
                            t.Titulo,
                            t.Descricao,
                            t.Vencimento,
                            t.Prioridade,
                            t.Status)
                ).ToList() ?? new List<TarefaDto>()
                );
        }

       
        public async Task RemoverProjeto(Guid projetoId)
        {
            var projeto = await projetoRepository.Obter(projetoId);
            if (projeto == null || projeto.PossuiTarefasPendentes) return;

            await projetoRepository.Remover(projetoId);
        }

      
    }
}
