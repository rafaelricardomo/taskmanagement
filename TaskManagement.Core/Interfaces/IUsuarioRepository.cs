using TaskManagement.Core.Entities;

namespace TaskManagement.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Obter();
        Task Criar(Usuario usuario);
    }
}
