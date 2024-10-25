using TaskManagement.Core.Dtos;
using TaskManagement.Core.Enums;
using Xunit;

namespace TaskManagement.Tests.Core.Dtos
{
    public class ProjetoDetalheDtoTests
    {
        private List<TarefaDto> ObterTarefas() =>
            new List<TarefaDto> { 
                new TarefaDto(
                Guid.NewGuid(),
                "Tarefa teste alt",
                "Descrição tarefa",
                DateTime.Today,
                PrioridadeEnum.Alta,
                StatusEnum.EmAndamento
                    )
            };
        
        [Fact]
        public void ProjetoDetalheDto_criar_valido()
        {
            var id = Guid.NewGuid();
            var dto = new ProjetoDetalheDto(id, 
                "Tarefa teste alt",
                ObterTarefas()
                );

            Assert.NotNull(dto);
            Assert.Equal("Tarefa teste alt", dto.nome);           
            Assert.Equal(id, dto.id);
            Assert.NotNull(dto.tarefas);
            Assert.True(dto.tarefas.Any());
        }
    }
}
