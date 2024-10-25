using TaskManagement.Core.Entities;
using TaskManagement.Core.Enums;
using Xunit;

namespace TaskManagement.Tests.Core.Entities
{
    public class ComentarioTests  : TestBase
    {
       
        [Fact]
        public void Comentario_criar_valido()
        {
            var comentario = new Comentario("Comentário de teste", ObterUsuario());

            Assert.NotNull(comentario);
            Assert.Equal("Comentário de teste", comentario.Descricao);
            Assert.NotNull(comentario.Usuario);
        }
    }
}
