using TaskManagement.Core.Dtos;
using TaskManagement.Core.Enums;
using Xunit;

namespace TaskManagement.Tests.Core.Dtos
{
    public class AlterarTarefaDtoTests
    {
        [Fact]
        public void AlterarTarefaDto_criar_valido()
        {
            var id = Guid.NewGuid();
            var dto = new AlterarTarefaDto(id, 
                "Tarefa teste alt", 
                "Descrição tarefa",
                DateTime.Today,
                StatusEnum.EmAndamento);

            Assert.NotNull(dto);
            Assert.Equal("Tarefa teste alt", dto.titulo);
            Assert.Equal("Descrição tarefa", dto.descricao);
            Assert.Equal(DateTime.Today, dto.vencimento);
            Assert.Equal(StatusEnum.EmAndamento, dto.status);
            Assert.Equal(id, dto.id);
        }
    }
}
