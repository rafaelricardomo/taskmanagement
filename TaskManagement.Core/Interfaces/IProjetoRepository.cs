using TaskManagement.Core.Entities;

namespace TaskManagement.Core.Interfaces
{
    public interface IProjetoRepository
    {
        Task<List<Projeto>> Listar();
        Task<Projeto> Obter(Guid id);
        Task Criar(Projeto projeto);
        Task Alterar(Projeto projeto);
        Task Remover(Guid id);
    }
}
