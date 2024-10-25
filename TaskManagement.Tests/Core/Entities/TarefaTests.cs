using TaskManagement.Core.Entities;
using TaskManagement.Core.Enums;
using Xunit;

namespace TaskManagement.Tests.Core.Entities
{
    public class TarefaTests : TestBase
    {
        [Fact]
        public void Tarefa_criar_valido()
        {
            var tarefa = new Tarefa(
                "Tarefa 1",
                "Descrição da tarefa",
                DateTime.Today.AddDays(10),
                PrioridadeEnum.Baixa
                );

            Assert.NotNull(tarefa);
            Assert.Equal("Tarefa 1", tarefa.Titulo);
            Assert.Equal("Descrição da tarefa", tarefa.Descricao);
            Assert.Equal(DateTime.Today.AddDays(10), tarefa.Vencimento);
            Assert.Equal(PrioridadeEnum.Baixa, tarefa.Prioridade);
            Assert.Equal(StatusEnum.Pendente, tarefa.Status);
        }

        [Fact]
        public void Tarefa_atualizar_valido()
        {
            var tarefa = new Tarefa(
                "Tarefa 1",
                "Descrição da tarefa",
                DateTime.Today.AddDays(10),
                PrioridadeEnum.Baixa
                );

            tarefa.Atualizar(
                "Tarefa nova 1",
                "Descrição tarefa nova",
                StatusEnum.EmAndamento);

            Assert.NotNull(tarefa);
            Assert.Equal("Tarefa nova 1", tarefa.Titulo);
            Assert.Equal("Descrição tarefa nova", tarefa.Descricao);
            Assert.Equal(DateTime.Today.AddDays(10), tarefa.Vencimento);
            Assert.Equal(PrioridadeEnum.Baixa, tarefa.Prioridade);
            Assert.Equal(StatusEnum.EmAndamento, tarefa.Status);
        }

        [Fact]
        public void Tarefa_atualizar_StatusPendente_invalido()
        {
            var tarefa = new Tarefa(
                "Tarefa 1",
                "Descrição da tarefa",
                DateTime.Today.AddDays(10),
                PrioridadeEnum.Baixa
                );

            tarefa.Atualizar(
                "Tarefa nova 1",
                "Descrição tarefa nova",
                StatusEnum.Pendente);

            Assert.NotNull(tarefa);
            Assert.Equal("Tarefa nova 1", tarefa.Titulo);
            Assert.Equal("Descrição tarefa nova", tarefa.Descricao);
            Assert.Equal(DateTime.Today.AddDays(10), tarefa.Vencimento);
            Assert.Equal(PrioridadeEnum.Baixa, tarefa.Prioridade);
            Assert.Equal(StatusEnum.Pendente, tarefa.Status);
        }

        [Fact]
        public void Tarefa_atualizar_StatusConcluido_invalido()
        {
            var tarefa = new Tarefa(
                "Tarefa 1",
                "Descrição da tarefa",
                DateTime.Today.AddDays(10),
                PrioridadeEnum.Baixa
                );

            tarefa.Atualizar(
                "Tarefa nova 1",
                "Descrição tarefa nova",
                StatusEnum.EmAndamento);

            tarefa.Atualizar(
               "Tarefa nova 1",
               "Descrição tarefa nova",
               StatusEnum.Concluido);

            tarefa.Atualizar(
              "Tarefa nova 1",
              "Descrição tarefa nova",
              StatusEnum.EmAndamento);

            Assert.NotNull(tarefa);
            Assert.Equal("Tarefa nova 1", tarefa.Titulo);
            Assert.Equal("Descrição tarefa nova", tarefa.Descricao);
            Assert.Equal(DateTime.Today.AddDays(10), tarefa.Vencimento);
            Assert.Equal(PrioridadeEnum.Baixa, tarefa.Prioridade);
            Assert.Equal(StatusEnum.Concluido, tarefa.Status);
        }

        [Fact]
        public void Tarefa_clonar_valido()
        {
            var tarefaParaClone = new Tarefa(
                "Tarefa 1",
                "Descrição da tarefa",
                DateTime.Today.AddDays(10),
                PrioridadeEnum.Baixa
                );

            var tarefa = (Tarefa)tarefaParaClone.Clone();

            Assert.NotNull(tarefa);
            Assert.Equal("Tarefa 1", tarefa.Titulo);
            Assert.Equal("Descrição da tarefa", tarefa.Descricao);
            Assert.Equal(DateTime.Today.AddDays(10), tarefa.Vencimento);
            Assert.Equal(PrioridadeEnum.Baixa, tarefa.Prioridade);
            Assert.Equal(StatusEnum.Pendente, tarefa.Status);
        }

        [Fact]
        public void Tarefa_comentar_valido()
        {
            var tarefa = new Tarefa(
                "Tarefa 1",
                "Descrição da tarefa",
                DateTime.Today.AddDays(10),
                PrioridadeEnum.Baixa
                );

            tarefa.Comentar("Testando 123", ObterUsuario());

            Assert.NotNull(tarefa);
            Assert.Equal("Tarefa 1", tarefa.Titulo);
            Assert.Equal("Descrição da tarefa", tarefa.Descricao);
            Assert.Equal(DateTime.Today.AddDays(10), tarefa.Vencimento);
            Assert.Equal(PrioridadeEnum.Baixa, tarefa.Prioridade);
            Assert.Equal(StatusEnum.Pendente, tarefa.Status);
            Assert.Contains(tarefa.Comentarios, t => t.Descricao.Contains("Testando 123"));
        }
    }
}
