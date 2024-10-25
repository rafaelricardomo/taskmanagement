using TaskManagement.Core.Entities;
using TaskManagement.Core.Enums;
using Xunit;

namespace TaskManagement.Tests.Core.Entities
{
    public class UsuarioTests
    {
        [Fact]
        public void Usuario_criar_valido()
        {
            var usuario = new Usuario("Nome teste 1", PerfilUsuarioEnum.Administrador);

            Assert.Equal("Nome teste 1", usuario.Nome);
            Assert.Equal(PerfilUsuarioEnum.Administrador, usuario.Perfil);
        }
    }
}
