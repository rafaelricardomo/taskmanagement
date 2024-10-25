using TaskManagement.Core.Dtos;
using TaskManagement.Core.Enums;
using Xunit;

namespace TaskManagement.Tests.Core.Dtos
{
    public class TarefaDetalheDtoTests
    {
        private List<ComentarioDto> ObterComentarios() =>
            new List<ComentarioDto> { new ComentarioDto(Guid.NewGuid(), "Comentario teste") };
        
        [Fact]
        public void TarefaDetalheDto_criar_valido()
        {
            var id = Guid.NewGuid();
            var dto = new TarefaDetalheDto(id, 
                "Tarefa teste alt", 
                "Descrição tarefa",
                DateTime.Today,
                PrioridadeEnum.Alta,
                StatusEnum.EmAndamento,
                ObterComentarios()
                );

            Assert.NotNull(dto);
            Assert.Equal("Tarefa teste alt", dto.titulo);
            Assert.Equal("Descrição tarefa", dto.descricao);
            Assert.Equal(DateTime.Today, dto.vencimento);
            Assert.Equal(StatusEnum.EmAndamento, dto.status);
            Assert.Equal(PrioridadeEnum.Alta, dto.prioridade);
            Assert.Equal(id, dto.id);
            Assert.NotNull(dto.comentarios);
            Assert.True(dto.comentarios.Any());
        }
    }
}
