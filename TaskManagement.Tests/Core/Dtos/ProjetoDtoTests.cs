using TaskManagement.Core.Dtos;
using Xunit;

namespace TaskManagement.Tests.Core.Dtos
{
    public class ProjetoDtoTests
    {
        [Fact]
        public void ProjetoDto_criar_valido()
        {
            var id = Guid.NewGuid();
            var dto = new ProjetoDto(id, "Projeto teste 2");

            Assert.NotNull(dto);
            Assert.Equal("Projeto teste 2", dto.nome);
            Assert.Equal(id, dto.id);
        }
    }
}
