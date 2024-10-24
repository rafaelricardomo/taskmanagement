using Microsoft.EntityFrameworkCore;
using TaskManagement.Core.Entities;

namespace TaskManagement.Infra.Sql.Repositories
{
    public abstract class Repository<T> where T : Entity
    {
        protected readonly TaskManagementContext _context;
        protected readonly DbSet<T> _dbSet;
        public Repository(TaskManagementContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
    }
}
