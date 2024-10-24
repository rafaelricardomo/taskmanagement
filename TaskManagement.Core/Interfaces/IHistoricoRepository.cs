using TaskManagement.Core.Entities;

namespace TaskManagement.Core.Interfaces
{
    public interface IHistoricoRepository
    { 
        Task Criar(Historico historico);
    }
}
