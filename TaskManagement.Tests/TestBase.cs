using TaskManagement.Core.Entities;
using TaskManagement.Core.Enums;

namespace TaskManagement.Tests
{
    public abstract class TestBase
    {
        protected Usuario ObterUsuario() =>
            new Usuario("Nome teste 1", PerfilUsuarioEnum.Administrador);

    }
}
