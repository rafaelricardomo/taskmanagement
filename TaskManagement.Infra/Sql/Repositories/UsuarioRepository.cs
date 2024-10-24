using Microsoft.EntityFrameworkCore;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Interfaces;

namespace TaskManagement.Infra.Sql.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(TaskManagementContext context) : base(context)
        {
        }

        public async Task Criar(Usuario usuario)
        {
            _dbSet.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> Obter()
        {
            var usuario = await _dbSet.FirstOrDefaultAsync();
            return usuario;
        }
    }
}
