using TaskManagement.Core.Dtos;
using TaskManagement.Core.Validations;
using Xunit;

namespace TaskManagement.Tests.Core.Validations
{
    public class CriarComentarioValidatorTests
    {
        [Fact]
        public void CriarComentarioValidator_validar_valido()
        {
            var dto = new CriarComentarioDto("Comentario teste novo");
            var validator = new CriarComentarioValidator().Validate(dto);
            Assert.NotNull(validator);
            Assert.True(validator.IsValid);
        }

        [Fact]
        public void CriarComentarioValidator_validar_invalido()
        {
            var dto = new CriarComentarioDto(null);
            var validator = new CriarComentarioValidator().Validate(dto);
            Assert.NotNull(validator);
            Assert.False(validator.IsValid);
        }
    }
}
