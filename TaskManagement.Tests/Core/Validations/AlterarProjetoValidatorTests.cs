using TaskManagement.Core.Dtos;
using TaskManagement.Core.Validations;
using Xunit;

namespace TaskManagement.Tests.Core.Validations
{
    public class AlterarProjetoValidatorTests
    {
        [Fact]
        public void AlterarProjetoValidator_validar_valido()
        {
            var dto = new AlterarProjetoDto(Guid.NewGuid(), "Projeto teste alt");
            var validator = new AlterarProjetoValidator().Validate(dto);
            Assert.NotNull(validator);
            Assert.True(validator.IsValid);
        }

        [Fact]
        public void AlterarProjetoValidator_validar_invalido()
        {
            var dto = new AlterarProjetoDto(Guid.NewGuid(), null);
            var validator = new AlterarProjetoValidator().Validate(dto);
            Assert.NotNull(validator);
            Assert.False(validator.IsValid);
        }
    }
}
