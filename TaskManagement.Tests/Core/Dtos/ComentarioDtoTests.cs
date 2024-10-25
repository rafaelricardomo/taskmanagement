using TaskManagement.Core.Dtos;
using Xunit;

namespace TaskManagement.Tests.Core.Dtos
{
    public class ComentarioDtoTests
    {
        [Fact]
        public void ComentarioDto_criar_valido()
        {
            var id = Guid.NewGuid();
            var dto = new ComentarioDto(id,"Comentario teste");

            Assert.NotNull(dto);
            Assert.Equal("Comentario teste", dto.descricao);
            Assert.Equal(id, dto.id);
        }
    }
}
