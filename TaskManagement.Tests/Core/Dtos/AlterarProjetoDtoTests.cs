using TaskManagement.Core.Dtos;
using Xunit;

namespace TaskManagement.Tests.Core.Dtos
{
    public class AlterarProjetoDtoTests
    {
        [Fact]
        public void AlterarProjetoDto_criar_valido()
        {
            var id = Guid.NewGuid();
            var dto = new AlterarProjetoDto(id, "Projeto teste alt");

            Assert.NotNull(dto);
            Assert.Equal("Projeto teste alt", dto.nome);
            Assert.Equal(id, dto.id);
        }
    }
}
