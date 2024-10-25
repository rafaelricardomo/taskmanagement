using TaskManagement.Core.Dtos;
using Xunit;

namespace TaskManagement.Tests.Core.Dtos
{
    public class CriarProjetoDtoTests
    {
        [Fact]
        public void CriarProjetoDto_criar_valido()
        {
            var id = Guid.NewGuid();
            var dto = new CriarProjetoDto("Projeto teste novo");

            Assert.NotNull(dto);
            Assert.Equal("Projeto teste novo", dto.nome);
        }
    }
}
