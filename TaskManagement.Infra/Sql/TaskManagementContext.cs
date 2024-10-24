using Microsoft.EntityFrameworkCore;
using TaskManagement.Core.Entities;
using TaskManagement.Infra.Sql.Mapping;

namespace TaskManagement.Infra.Sql
{
    public class TaskManagementContext : DbContext
    {
        public TaskManagementContext(DbContextOptions<TaskManagementContext> options)
          : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProjetoMap().Configure(modelBuilder.Entity<Projeto>());
            new UsuarioMap().Configure(modelBuilder.Entity<Usuario>());
            new TarefaMap().Configure(modelBuilder.Entity<Tarefa>());
            new HistoricoMap().Configure(modelBuilder.Entity<Historico>());
            new HistoricoDetalheMap().Configure(modelBuilder.Entity<HistoricoDetalhe>());
            new ComentarioMap().Configure(modelBuilder.Entity<Comentario>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
