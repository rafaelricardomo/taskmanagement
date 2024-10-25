using TaskManagement.Core.Dtos;
using TaskManagement.Core.Enums;
using TaskManagement.Core.Validations;
using Xunit;

namespace TaskManagement.Tests.Core.Validations
{
    public class AlterarTarefaValidatorTests
    {
        [Fact]
        public void AlterarTarefaValidator_validar_valido()
        {
            var dto = new AlterarTarefaDto(
                Guid.NewGuid(),
                "Tarefa teste",
                "Descrição tarefa",
                DateTime.Today.AddDays(1),
               StatusEnum.EmAndamento
               );
            var validator = new AlterarTarefaValidator().Validate(dto);
            Assert.NotNull(validator);
            Assert.True(validator.IsValid);
        }

        [Fact]
        public void AlterarTarefaValidator_validar_titulo_invalido()
        {
            var dto = new AlterarTarefaDto(
                Guid.NewGuid(),
                null,
                "Descrição tarefa",
              DateTime.Today.AddDays(1),
               StatusEnum.EmAndamento
               );

            var validator = new AlterarTarefaValidator().Validate(dto);
            Assert.NotNull(validator);
            Assert.False(validator.IsValid);
        }

        [Fact]
        public void AlterarTarefaValidator_validar_descricao_invalido()
        {
            var dto = new AlterarTarefaDto(
                Guid.NewGuid(),
                "Tarefa teste",
                null,
               DateTime.Today.AddDays(1),
               StatusEnum.EmAndamento
               );
            var validator = new AlterarTarefaValidator().Validate(dto);
            Assert.NotNull(validator);
            Assert.False(validator.IsValid);
        }

        [Fact]
        public void AlterarTarefaValidator_validar_vencimento_invalido()
        {
            var dto = new AlterarTarefaDto(
                Guid.NewGuid(),
                "Tarefa teste",
                "Descrição tarefa",
                DateTime.Today.AddDays(-1),
               StatusEnum.EmAndamento
               );
            var validator = new AlterarTarefaValidator().Validate(dto);
            Assert.NotNull(validator);
            Assert.False(validator.IsValid);
        }

        [Fact]
        public void AlterarTarefaValidator_validar_status_invalido()
        {
            var dto = new AlterarTarefaDto(
                Guid.NewGuid(),
                "Tarefa teste",
                "Descrição tarefa",
                DateTime.Today.AddDays(1),
               (StatusEnum)50
               );
            var validator = new AlterarTarefaValidator().Validate(dto);
            Assert.NotNull(validator);
            Assert.False(validator.IsValid);
        }
    }
}
