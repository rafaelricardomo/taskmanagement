using TaskManagement.Core.Dtos;

namespace TaskManagement.Core.Interfaces
{
    public interface IProjetoService
    {
        Task<ProjetoDetalheDto?> ObterProjetoDetalhe(Guid projetoId);
        Task<List<ProjetoDto>> ListarProjetos();
        Task CriarProjeto(CriarProjetoDto projeto);
        Task RemoverProjeto(Guid projetoId);
        Task AlterarProjeto(Guid projetoId, AlterarProjetoDto projeto);

    }
}
