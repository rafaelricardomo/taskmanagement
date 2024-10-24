using Microsoft.EntityFrameworkCore;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Interfaces;

namespace TaskManagement.Infra.Sql.Repositories
{
    public class ProjetoRepository : Repository<Projeto>, IProjetoRepository
    {
        public ProjetoRepository(TaskManagementContext context) : base(context)
        {
        }
        public async Task Alterar(Projeto projeto)
        {
            await _context.SaveChangesAsync();
        }

        public async Task Criar(Projeto projeto)
        {
            _dbSet.Add(projeto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Projeto>> Listar()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Projeto> Obter(Guid id)
        {
            var projeto = _dbSet
                .Include(p => p.Tarefas)
                .ThenInclude(p => p.Comentarios)
                .Where(x => x.Id == id);
            return await projeto?.FirstOrDefaultAsync();
        }

        public async Task Remover(Guid id)
        {
            var projeto = await _dbSet?.FirstOrDefaultAsync(x => x.Id == id);
            _dbSet.Remove(projeto);
            await _context.SaveChangesAsync();
        }
    }
}
