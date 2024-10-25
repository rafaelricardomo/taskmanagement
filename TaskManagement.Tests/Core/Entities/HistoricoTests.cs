using TaskManagement.Core.Entities;
using TaskManagement.Core.Enums;
using Xunit;

namespace TaskManagement.Tests.Core.Entities
{
    public class HistoricoTests : TestBase
    {
        private Tarefa ObterTarefa() => new Tarefa(
                "Tarefa 1",
                "Descrição da tarefa",
                DateTime.Today.AddDays(10),
                PrioridadeEnum.Baixa
                );


        private (Tarefa anterior, Tarefa atual) ObterTarefasComComentarios()
        {
            var tarefaAnterior = ObterTarefa();
            tarefaAnterior.Comentar("Comentando teste", ObterUsuario());
            var tarefaAtual = ObterTarefa();
            tarefaAtual.Comentar("Comentando teste 2", ObterUsuario());

            return (tarefaAnterior, tarefaAtual);
        }
        [Fact]
        public void Historico_criar_valido()
        {
            var historico = new Historico(
                "Histórico teste 1",
                ObterTarefa(),
                ObterTarefa(),
                ObterUsuario()
                );

            Assert.NotNull(historico);
            Assert.Equal("Histórico teste 1", historico.Descricao);
            Assert.NotNull(historico.Detalhes);
            Assert.True(historico.Detalhes.Any());
            Assert.Equal(5, historico.Detalhes.Count());
        }

        [Fact]
        public void Historico_criar_comentarios_valido()
        {
            var (tarefaAnterior, tarefaAtual) = ObterTarefasComComentarios();
            var historico = new Historico(
                "Histórico teste 1",
                tarefaAnterior,
               tarefaAtual,
                ObterUsuario()
                );

            Assert.NotNull(historico);
            Assert.Equal("Histórico teste 1", historico.Descricao);
            Assert.NotNull(historico.Detalhes);
            Assert.True(historico.Detalhes.Any());
            Assert.Equal(6, historico.Detalhes.Count());
        }
    }
}
