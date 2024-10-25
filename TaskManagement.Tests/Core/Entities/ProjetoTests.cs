using TaskManagement.Core.Entities;
using TaskManagement.Core.Enums;
using Xunit;

namespace TaskManagement.Tests.Core.Entities
{
    public class ProjetoTests : TestBase
    {
        [Fact]
        public void Projeto_criar_valido()
        {
            var projeto = new Projeto("Nome teste 1");

            Assert.NotNull(projeto);
            Assert.Equal("Nome teste 1", projeto.Nome);
        }

        [Fact]
        public void Projeto_Atualizar_valido()
        {
            var projeto = new Projeto("Nome teste 1");
            
            projeto.Atualizar("Nome teste 2");

            Assert.NotNull(projeto);
            Assert.Equal("Nome teste 2", projeto.Nome);
        }

        [Fact]
        public void Projeto_AdicionarTarefa_valido()
        {
            var projeto = new Projeto("Nome teste 1");

            projeto.AdicionarTarefa(
                "Tarefa teste",
                "Teste",
                DateTime.Today.AddDays(3), 
                PrioridadeEnum.Media); 

            Assert.NotNull(projeto);
            Assert.Equal("Nome teste 1", projeto.Nome);
            Assert.NotNull(projeto.Tarefas);
            Assert.Contains(projeto.Tarefas, t => t.Titulo.Contains("Tarefa teste"));
        }

        [Fact]
        public void Projeto_AtualizarTarefa_valido()
        {
            var projeto = new Projeto("Nome teste 1");

            projeto.AdicionarTarefa(
                "Tarefa teste",
                "Teste",
                DateTime.Today.AddDays(3),
                PrioridadeEnum.Media);

            var tarefaAdicionada = projeto.Tarefas.FirstOrDefault();
            Assert.NotNull(tarefaAdicionada);

            projeto.AtualizarTarefa(
                tarefaAdicionada.Id,
                "Tarefa teste alt",
                "teste alt",
                StatusEnum.EmAndamento);

            Assert.NotNull(projeto);
            Assert.Equal("Nome teste 1", projeto.Nome);
            Assert.NotNull(projeto.Tarefas);
            Assert.Contains(projeto.Tarefas, t => t.Titulo.Contains("Tarefa teste alt"));
            Assert.Contains(projeto.Tarefas, t => t.Descricao.Contains("teste alt"));
            Assert.Contains(projeto.Tarefas, t => t.Status.Equals(StatusEnum.EmAndamento));
        }

        [Fact]
        public void Projeto_AtualizarTarefa_invalido()
        {
            var projeto = new Projeto("Nome teste 1");

            projeto.AdicionarTarefa(
                "Tarefa teste",
                "Teste",
                DateTime.Today.AddDays(3),
                PrioridadeEnum.Media);

            var tarefaAdicionada = projeto.Tarefas.FirstOrDefault();
            Assert.NotNull(tarefaAdicionada);

            projeto.AtualizarTarefa(
                Guid.NewGuid(),
                "Tarefa teste alt",
                "teste alt",
                StatusEnum.EmAndamento);

            Assert.NotNull(projeto);
            Assert.Equal("Nome teste 1", projeto.Nome);
            Assert.NotNull(projeto.Tarefas);
            Assert.Contains(projeto.Tarefas, t => t.Titulo.Contains("Tarefa teste"));
            Assert.Contains(projeto.Tarefas, t => t.Descricao.Contains("Teste"));
            Assert.Contains(projeto.Tarefas, t => t.Status.Equals(StatusEnum.Pendente));
        }

        [Fact]
        public void Projeto_ComentarTarefa_valido()
        {
            var projeto = new Projeto("Nome teste 1");

            projeto.AdicionarTarefa(
                "Tarefa teste",
                "Teste",
                DateTime.Today.AddDays(3),
                PrioridadeEnum.Media);

            var tarefaAdicionada = projeto.Tarefas.FirstOrDefault();
            Assert.NotNull(tarefaAdicionada);

            projeto.ComentarTarefa(
                tarefaAdicionada.Id,
                "Comentando tarefa",
                ObterUsuario()
                );

            Assert.NotNull(projeto);
            Assert.Equal("Nome teste 1", projeto.Nome);
            Assert.NotNull(projeto.Tarefas);
            Assert.Contains(projeto.Tarefas, t => t.Titulo.Contains("Tarefa teste"));
            Assert.Contains(tarefaAdicionada.Comentarios, t => t.Descricao.Contains("Comentando tarefa"));
        }

        [Fact]
        public void Projeto_ComentarTarefa_invalido()
        {
            var projeto = new Projeto("Nome teste 1");

            projeto.AdicionarTarefa(
                "Tarefa teste",
                "Teste",
                DateTime.Today.AddDays(3),
                PrioridadeEnum.Media);

            var tarefaAdicionada = projeto.Tarefas.FirstOrDefault();
            Assert.NotNull(tarefaAdicionada);

            projeto.ComentarTarefa(
                Guid.NewGuid(),
                "Comentando tarefa",
                ObterUsuario()
                );

            Assert.NotNull(projeto);
            Assert.Equal("Nome teste 1", projeto.Nome);
            Assert.NotNull(projeto.Tarefas);
            Assert.Contains(projeto.Tarefas, t => t.Titulo.Contains("Tarefa teste"));
            Assert.False(tarefaAdicionada.Comentarios.Any());
        }

        [Fact]
        public void Projeto_RemoverTarefa_valido()
        {
            var projeto = new Projeto("Nome teste 1");

            projeto.AdicionarTarefa(
                "Tarefa teste",
                "Teste",
                DateTime.Today.AddDays(3),
                PrioridadeEnum.Media);

            var tarefaAdicionada = projeto.Tarefas.FirstOrDefault();
            Assert.NotNull(tarefaAdicionada);

            projeto.RemoverTarefa(
                tarefaAdicionada.Id);

            Assert.NotNull(projeto);
            Assert.Equal("Nome teste 1", projeto.Nome);
            Assert.NotNull(projeto.Tarefas);
            Assert.False(projeto.Tarefas.Any());
        }

        [Fact]
        public void Projeto_RemoverTarefa_invalido()
        {
            var projeto = new Projeto("Nome teste 1");

            projeto.AdicionarTarefa(
                "Tarefa teste",
                "Teste",
                DateTime.Today.AddDays(3),
                PrioridadeEnum.Media);

            var tarefaAdicionada = projeto.Tarefas.FirstOrDefault();
            Assert.NotNull(tarefaAdicionada);

            projeto.RemoverTarefa(
                Guid.NewGuid());

            Assert.NotNull(projeto);
            Assert.Equal("Nome teste 1", projeto.Nome);
            Assert.NotNull(projeto.Tarefas);
            Assert.True(projeto.Tarefas.Any());
        }

        [Fact]
        public void Projeto_ObterTarefa_valido()
        {
            var projeto = new Projeto("Nome teste 1");

            projeto.AdicionarTarefa(
                "Tarefa teste",
                "Teste",
                DateTime.Today.AddDays(3),
                PrioridadeEnum.Media);

            var tarefaAdicionada = projeto.Tarefas.FirstOrDefault();
            Assert.NotNull(tarefaAdicionada);

            var tarefa = projeto.ObterTarefa(tarefaAdicionada.Id);
            Assert.NotNull(tarefa);

            Assert.NotNull(projeto);
            Assert.Equal("Nome teste 1", projeto.Nome);
            Assert.NotNull(projeto.Tarefas);
            Assert.Contains(projeto.Tarefas, t => t.Titulo.Contains("Tarefa teste"));
        }

        [Fact]
        public void Projeto_ObterTarefa_invalido()
        {
            var projeto = new Projeto("Nome teste 1");

            projeto.AdicionarTarefa(
                "Tarefa teste",
                "Teste",
                DateTime.Today.AddDays(3),
                PrioridadeEnum.Media);

            var tarefaAdicionada = projeto.Tarefas.FirstOrDefault();
            Assert.NotNull(tarefaAdicionada);

            var tarefa = projeto.ObterTarefa(Guid.NewGuid());
            Assert.Null(tarefa);

            Assert.NotNull(projeto);
            Assert.Equal("Nome teste 1", projeto.Nome);
            Assert.NotNull(projeto.Tarefas);
            Assert.Contains(projeto.Tarefas, t => t.Titulo.Contains("Tarefa teste"));
        }

        [Fact]
        public void Projeto_ClonarTarefa_valido()
        {
            var projeto = new Projeto("Nome teste 1");

            projeto.AdicionarTarefa(
                "Tarefa teste",
                "Teste",
                DateTime.Today.AddDays(3),
                PrioridadeEnum.Media);

            var tarefaAdicionada = projeto.Tarefas.FirstOrDefault();
            Assert.NotNull(tarefaAdicionada);

            var tarefa = projeto.ClonarTarefa(tarefaAdicionada.Id);
            Assert.NotNull(tarefa);

            Assert.NotNull(projeto);
            Assert.Equal("Nome teste 1", projeto.Nome);
            Assert.NotNull(projeto.Tarefas);
            Assert.Contains(projeto.Tarefas, t => t.Titulo.Contains("Tarefa teste"));

            Assert.Equal(tarefa.Titulo, tarefaAdicionada.Titulo);
            Assert.Equal(tarefa.Descricao, tarefaAdicionada.Descricao);
            Assert.Equal(tarefa.Vencimento, tarefaAdicionada.Vencimento);
            Assert.Equal(tarefa.Prioridade, tarefaAdicionada.Prioridade);
            Assert.Equal(tarefa.Status, tarefaAdicionada.Status);
        }

        [Fact]
        public void Projeto_ClonarTarefa_invalido()
        {
            var projeto = new Projeto("Nome teste 1");

            projeto.AdicionarTarefa(
                "Tarefa teste",
                "Teste",
                DateTime.Today.AddDays(3),
                PrioridadeEnum.Media);

            var tarefaAdicionada = projeto.Tarefas.FirstOrDefault();
            Assert.NotNull(tarefaAdicionada);

            var tarefa = projeto.ClonarTarefa(Guid.NewGuid());
            Assert.Null(tarefa);

            Assert.NotNull(projeto);
            Assert.Equal("Nome teste 1", projeto.Nome);
            Assert.NotNull(projeto.Tarefas);
            Assert.Contains(projeto.Tarefas, t => t.Titulo.Contains("Tarefa teste"));

        }
    }
}
