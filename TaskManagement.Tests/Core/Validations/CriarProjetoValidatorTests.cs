using TaskManagement.Core.Dtos;
using TaskManagement.Core.Validations;
using Xunit;

namespace TaskManagement.Tests.Core.Validations
{
    public class CriarProjetoValidatorTests
    {
        [Fact]
        public void CriarProjetoValidator_validar_valido()
        {
            var dto = new CriarProjetoDto("Projeto teste novo");
            var validator = new CriarProjetoValidator().Validate(dto);
            Assert.NotNull(validator);
            Assert.True(validator.IsValid);
        }

        [Fact]
        public void CriarProjetoValidator_validar_invalido()
        {
            var dto = new CriarProjetoDto(null);
            var validator = new CriarProjetoValidator().Validate(dto);
            Assert.NotNull(validator);
            Assert.False(validator.IsValid);
        }
    }
}
