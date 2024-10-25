using TaskManagement.Core.Entities;
using TaskManagement.Core.Interfaces;

namespace TaskManagement.Infra.Sql
{
    public class TaskManagementDbInitializer(
        TaskManagementContext context,
        IUsuarioRepository usuarioRepository)
    {

        private void CreateUser()
        {
            var administrador = new Usuario(
                nameof(Core.Enums.PerfilUsuarioEnum.Administrador), 
                Core.Enums.PerfilUsuarioEnum.Administrador
                );
            
            usuarioRepository.Criar(administrador).Wait();

            var gerente = new Usuario(
               nameof(Core.Enums.PerfilUsuarioEnum.Gerente), 
                Core.Enums.PerfilUsuarioEnum.Gerente
                );

            usuarioRepository.Criar(gerente).Wait();

            var dev = new Usuario(
                nameof(Core.Enums.PerfilUsuarioEnum.Desenvolvedor),
                Core.Enums.PerfilUsuarioEnum.Desenvolvedor
                );

            usuarioRepository.Criar(dev).Wait();
        }
        public void Run()
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            CreateUser();
        }
    }
}
