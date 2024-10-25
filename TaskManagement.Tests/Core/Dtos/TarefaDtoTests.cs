using TaskManagement.Core.Dtos;
using TaskManagement.Core.Enums;
using Xunit;

namespace TaskManagement.Tests.Core.Dtos
{
    public class TarefaDtoTests
    {
        [Fact]
        public void TarefaDto_criar_valido()
        {
            var id = Guid.NewGuid();
            var dto = new TarefaDto(id, 
                "Tarefa teste alt", 
                "Descrição tarefa",
                DateTime.Today,
                PrioridadeEnum.Alta,
                StatusEnum.EmAndamento);

            Assert.NotNull(dto);
            Assert.Equal("Tarefa teste alt", dto.titulo);
            Assert.Equal("Descrição tarefa", dto.descricao);
            Assert.Equal(DateTime.Today, dto.vencimento);
            Assert.Equal(StatusEnum.EmAndamento, dto.status);
            Assert.Equal(PrioridadeEnum.Alta, dto.prioridade);
            Assert.Equal(id, dto.id);
        }
    }
}
