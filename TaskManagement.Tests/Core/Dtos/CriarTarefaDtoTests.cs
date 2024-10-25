using TaskManagement.Core.Dtos;
using TaskManagement.Core.Enums;
using Xunit;

namespace TaskManagement.Tests.Core.Dtos
{
    public class CriarTarefaDtoTests
    {
        [Fact]
        public void CriarTarefaDto_criar_valido()
        {
          
            var dto = new CriarTarefaDto( 
                "Tarefa teste", 
                "Descrição tarefa",
                DateTime.Today,
                PrioridadeEnum.Media);

            Assert.NotNull(dto);
            Assert.Equal("Tarefa teste", dto.titulo);
            Assert.Equal("Descrição tarefa", dto.descricao);
            Assert.Equal(DateTime.Today, dto.vencimento);
            Assert.Equal(PrioridadeEnum.Media, dto.prioridade);
           
        }
    }
}
