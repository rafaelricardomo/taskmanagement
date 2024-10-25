using TaskManagement.Core.Dtos;
using Xunit;

namespace TaskManagement.Tests.Core.Dtos
{
    public class CriarComentarioDtoTests
    {
        [Fact]
        public void CriarComentarioDto_criar_valido()
        {
            var dto = new CriarComentarioDto("Comentario teste");

            Assert.NotNull(dto);
            Assert.Equal("Comentario teste", dto.descricao);
        }
    }
}
