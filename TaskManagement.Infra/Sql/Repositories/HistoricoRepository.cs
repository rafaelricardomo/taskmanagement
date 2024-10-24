using TaskManagement.Core.Entities;
using TaskManagement.Core.Interfaces;

namespace TaskManagement.Infra.Sql.Repositories
{
    public class HistoricoRepository : Repository<Historico>, IHistoricoRepository
    {
        public HistoricoRepository(TaskManagementContext context) : base(context)
        {
        }

        public async Task Criar(Historico historico)
        {
            _dbSet.Add(historico);
            await _context.SaveChangesAsync();
        }

    }
}
