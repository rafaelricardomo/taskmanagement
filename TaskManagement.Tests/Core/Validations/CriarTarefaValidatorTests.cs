using TaskManagement.Core.Dtos;
using TaskManagement.Core.Enums;
using TaskManagement.Core.Validations;
using Xunit;

namespace TaskManagement.Tests.Core.Validations
{
    public class CriarTarefaValidatorTests
    {
        [Fact]
        public void CriarTarefaValidator_validar_valido()
        {
            var dto = new CriarTarefaDto(
                "Tarefa teste",
                "Descrição tarefa",
                DateTime.Today.AddDays(1),
                PrioridadeEnum.Media);
            var validator = new CriarTarefaValidator().Validate(dto);
            Assert.NotNull(validator);
            Assert.True(validator.IsValid);
        }

        [Fact]
        public void CriarTarefaValidator_validar_titulo_invalido()
        {
            var dto = new CriarTarefaDto(
                null,
                "Descrição tarefa",
               DateTime.Today.AddDays(1),
                PrioridadeEnum.Media);

            var validator = new CriarTarefaValidator().Validate(dto);
            Assert.NotNull(validator);
            Assert.False(validator.IsValid);
        }

        [Fact]
        public void CriarTarefaValidator_validar_descricao_invalido()
        {
            var dto = new CriarTarefaDto(
                "Tarefa teste",
                null,
               DateTime.Today.AddDays(1),
                PrioridadeEnum.Media);
            var validator = new CriarTarefaValidator().Validate(dto);
            Assert.NotNull(validator);
            Assert.False(validator.IsValid);
        }

        [Fact]
        public void CriarTarefaValidator_validar_vencimento_invalido()
        {
            var dto = new CriarTarefaDto(
                "Tarefa teste",
                "Descrição tarefa",
                DateTime.Today.AddDays(-1),
                PrioridadeEnum.Media);
            var validator = new CriarTarefaValidator().Validate(dto);
            Assert.NotNull(validator);
            Assert.False(validator.IsValid);
        }

        [Fact]
        public void CriarTarefaValidator_validar_prioridade_invalido()
        {
            var dto = new CriarTarefaDto(
                "Tarefa teste",
                "Descrição tarefa",
                DateTime.Today.AddDays(1),
                (PrioridadeEnum)10);
            var validator = new CriarTarefaValidator().Validate(dto);
            Assert.NotNull(validator);
            Assert.False(validator.IsValid);
        }
    }
}
