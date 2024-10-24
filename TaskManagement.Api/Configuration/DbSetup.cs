using Microsoft.EntityFrameworkCore;
using TaskManagement.Core.Interfaces;
using TaskManagement.Core.Services;
using TaskManagement.Infra.Sql;
using TaskManagement.Infra.Sql.Repositories;

namespace TaskManagement.Api.Configuration
{
    public static class DbSetup
    {
        public static void AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskManagementContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("TaskManagementContext")));
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IHistoricoRepository, HistoricoRepository>();
            services.AddScoped<IProjetoService, ProjetoService>();
            services.AddScoped<ITarefaService, TarefaService>();
            services.AddScoped<TaskManagementDbInitializer>();
        }
        public static void RunDbInitializer(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var initialiser = services.GetRequiredService<TaskManagementDbInitializer>();
            initialiser.Run();
        }
    }
}
