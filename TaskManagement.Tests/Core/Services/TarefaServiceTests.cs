using Moq;
using TaskManagement.Core.Dtos;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Enums;
using TaskManagement.Core.Interfaces;
using TaskManagement.Core.Services;
using Xunit;

namespace TaskManagement.Tests.Core.Services
{
    public class TarefaServiceTests : TestBase
    {
        private readonly Mock<IProjetoRepository> projetoRepository;
        private readonly Mock<IHistoricoRepository> historicoRepository;
        private readonly Mock<IUsuarioRepository> usuarioRepository;

        public TarefaServiceTests()
        {
            projetoRepository = new Mock<IProjetoRepository>();
            historicoRepository = new Mock<IHistoricoRepository>();
            usuarioRepository = new Mock<IUsuarioRepository>();
        }
        private TarefaService ObterService() =>
            new(
            projetoRepository.Object,
            historicoRepository.Object,
            usuarioRepository.Object
            );


        private Tarefa ObterTarefa() =>
            new Tarefa(
                "Tarefa 1",
                "Descrição da tarefa",
                DateTime.Today.AddDays(10),
                PrioridadeEnum.Baixa
                );

        private CriarTarefaDto CriarTarefaDto() =>
             new CriarTarefaDto(
                "Tarefa teste",
                "Descrição tarefa",
                DateTime.Today,
                PrioridadeEnum.Media);

        private AlterarTarefaDto AlterarTarefaDto(Guid id) =>
            new AlterarTarefaDto(
                id,
               "Tarefa teste",
               "Descrição tarefa",
               DateTime.Today,
               StatusEnum.EmAndamento);

        private Projeto ObterProjeto() =>
              new Projeto("Nome teste 1");

        private CriarComentarioDto CriarComentarioDto() => new CriarComentarioDto("Comentario teste");


        private Projeto ObterProjetoComTarefas(int limiteTarefas)
        {
            var projeto = ObterProjeto();

            for(var i=0; i< limiteTarefas; i++)
            {
                projeto.AdicionarTarefa(
                   $"Tarefa teste {i}",
                   $"Teste {i}",
                   DateTime.Today.AddDays(i+1),
                   PrioridadeEnum.Baixa
                   );
            }

            return projeto;
        }

        private void SetupMockDefault()
        {
            usuarioRepository
                .Setup(x => x.Obter())
                .ReturnsAsync(ObterUsuario());

            historicoRepository
                .Setup(x => x.Criar(It.IsAny<Historico>()));
        }

        [Fact]
        public async Task TarefaService_CriarTarefa_valido()
        {
            SetupMockDefault();

            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(ObterProjeto());

            projetoRepository
                .Setup(x => x.Alterar(It.IsAny<Projeto>()));

            var service = ObterService();

            var dto = CriarTarefaDto();
            await service.CriarTarefa(Guid.NewGuid(), dto);


            projetoRepository
                .Verify(x => x.Obter(It.IsAny<Guid>()));
            projetoRepository
                .Verify(x => x.Alterar(It.IsAny<Projeto>()));
            historicoRepository
                .Verify(x => x.Criar(It.IsAny<Historico>()));
            usuarioRepository
                .Verify(x => x.Obter());
        }

        [Fact]
        public async Task TarefaService_CriarTarefa_ProjetoNaoExiste_invalido()
        {
            SetupMockDefault();

            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(await Task.FromResult<Projeto>(null));

            projetoRepository
                .Setup(x => x.Alterar(It.IsAny<Projeto>()));

            var service = ObterService();

            var dto = CriarTarefaDto();
            await service.CriarTarefa(Guid.NewGuid(), dto);


            projetoRepository
                .Verify(x => x.Obter(It.IsAny<Guid>()));

        }

        [Fact]
        public async Task TarefaService_CriarTarefa_ProjetoAtingiuLimite_invalido()
        {
            SetupMockDefault();

            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(ObterProjetoComTarefas(20));

            projetoRepository
                .Setup(x => x.Alterar(It.IsAny<Projeto>()));

            var service = ObterService();

            var dto = CriarTarefaDto();
           var erro = await Assert.ThrowsAsync<InvalidOperationException>(async () => 
                await service.CriarTarefa(Guid.NewGuid(), dto)
                );

            Assert.NotNull(erro);

            projetoRepository
                .Verify(x => x.Obter(It.IsAny<Guid>()));
           
        }

        [Fact]
        public async Task TarefaService_ListarTarefas_valido()
        {
            SetupMockDefault();

            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(ObterProjetoComTarefas(15));

            var service = ObterService();

            var tarefas = await service.ListarTarefas(Guid.NewGuid());

            Assert.NotNull(tarefas);
            Assert.Equal(15, tarefas.Count);

            projetoRepository
                .Verify(x => x.Obter(It.IsAny<Guid>()));
         
        }

        [Fact]
        public async Task TarefaService_ListarTarefas_ProjetoNaoExiste_invalido()
        {
            SetupMockDefault();

            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(await Task.FromResult<Projeto>(null));

            var service = ObterService();

            var tarefas = await service.ListarTarefas(Guid.NewGuid());

            Assert.Null(tarefas);

            projetoRepository
                .Verify(x => x.Obter(It.IsAny<Guid>()));

        }

        [Fact]
        public async Task TarefaService_AlterarTarefa_valido()
        {
            SetupMockDefault();

            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(ObterProjetoComTarefas(5));

            projetoRepository
                .Setup(x => x.Alterar(It.IsAny<Projeto>()));

            var service = ObterService();

            var id = Guid.Empty;
            var dto = AlterarTarefaDto(id);
            await service.AlterarTarefa(Guid.NewGuid(), id, dto);


            projetoRepository
                .Verify(x => x.Obter(It.IsAny<Guid>()));
            projetoRepository
                .Verify(x => x.Alterar(It.IsAny<Projeto>()));
            historicoRepository
                .Verify(x => x.Criar(It.IsAny<Historico>()));
            usuarioRepository
                .Verify(x => x.Obter());
        }

        [Fact]
        public async Task TarefaService_AlterarTarefa_ProjetoNaoExiste_invalido()
        {
            SetupMockDefault();

            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(await Task.FromResult<Projeto>(null));

            projetoRepository
                .Setup(x => x.Alterar(It.IsAny<Projeto>()));

            var service = ObterService();

            var id = Guid.Empty;
            var dto = AlterarTarefaDto(id);
            await service.AlterarTarefa(Guid.NewGuid(), id, dto);


            projetoRepository
                .Verify(x => x.Obter(It.IsAny<Guid>()));
         
        }

        [Fact]
        public async Task TarefaService_AlterarTarefa_TarefaNaoEncontrada_invalido()
        {
            SetupMockDefault();

            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(ObterProjetoComTarefas(5));

            projetoRepository
                .Setup(x => x.Alterar(It.IsAny<Projeto>()));

            var service = ObterService();

            var id = Guid.NewGuid();
            var dto = AlterarTarefaDto(id);
            await service.AlterarTarefa(Guid.NewGuid(), id, dto);


            projetoRepository
                .Verify(x => x.Obter(It.IsAny<Guid>()));
            projetoRepository
                .Verify(x => x.Alterar(It.IsAny<Projeto>()));
           
            usuarioRepository
                .Verify(x => x.Obter());
        }

        [Fact]
        public async Task TarefaService_CriarComentarioTarefa_valido()
        {
            SetupMockDefault();

            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(ObterProjetoComTarefas(6));

            projetoRepository
                .Setup(x => x.Alterar(It.IsAny<Projeto>()));

            var service = ObterService();
            var id = Guid.Empty;
            var dto = CriarComentarioDto();
            await service.CriarComentarioTarefa(Guid.NewGuid(),id, dto);


            projetoRepository
                .Verify(x => x.Obter(It.IsAny<Guid>()));
            projetoRepository
                .Verify(x => x.Alterar(It.IsAny<Projeto>()));
            historicoRepository
                .Verify(x => x.Criar(It.IsAny<Historico>()));
            usuarioRepository
                .Verify(x => x.Obter());
        }

        [Fact]
        public async Task TarefaService_CriarComentarioTarefa_ProjetoNaoExiste_invalido()
        {
            SetupMockDefault();

            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(await Task.FromResult<Projeto>(null));

            projetoRepository
                .Setup(x => x.Alterar(It.IsAny<Projeto>()));

            var service = ObterService();
            var id = Guid.Empty;
            var dto = CriarComentarioDto();
            await service.CriarComentarioTarefa(Guid.NewGuid(), id, dto);


            projetoRepository
                .Verify(x => x.Obter(It.IsAny<Guid>()));
           
        }

        [Fact]
        public async Task TarefaService_CriarComentarioTarefa_TarefaNaoEncontrada_valido()
        {
            SetupMockDefault();

            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(ObterProjetoComTarefas(6));

            projetoRepository
                .Setup(x => x.Alterar(It.IsAny<Projeto>()));

            var service = ObterService();
            var id = Guid.NewGuid();
            var dto = CriarComentarioDto();
            await service.CriarComentarioTarefa(Guid.NewGuid(), id, dto);


            projetoRepository
                .Verify(x => x.Obter(It.IsAny<Guid>()));
            projetoRepository
                .Verify(x => x.Alterar(It.IsAny<Projeto>()));
           
            usuarioRepository
                .Verify(x => x.Obter());
        }

        [Fact]
        public async Task TarefaService_RemoverTarefa_valido()
        {
            SetupMockDefault();

            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(ObterProjetoComTarefas(5));

            projetoRepository
                .Setup(x => x.Alterar(It.IsAny<Projeto>()));

            var service = ObterService();

            var id = Guid.Empty;
            await service.RemoverTarefa(Guid.NewGuid(), id);


            projetoRepository
                .Verify(x => x.Obter(It.IsAny<Guid>()));
            projetoRepository
                .Verify(x => x.Alterar(It.IsAny<Projeto>()));
           
        }

        [Fact]
        public async Task TarefaService_RemoverTarefa_ProjetoNaoExiste_invalido()
        {
            SetupMockDefault();

            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(await Task.FromResult<Projeto>(null));

            projetoRepository
                .Setup(x => x.Alterar(It.IsAny<Projeto>()));

            var service = ObterService();

            var id = Guid.Empty;
            await service.RemoverTarefa(Guid.NewGuid(), id);


            projetoRepository
                .Verify(x => x.Obter(It.IsAny<Guid>()));
          
        }

        [Fact]
        public async Task TarefaService_ObterDetalheTarefas_valido()
        {
            SetupMockDefault();

            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(ObterProjetoComTarefas(15));

            var service = ObterService();
            var id = Guid.Empty;
            var tarefaDetalhe = await service.ObterTarefaDetalhe(Guid.NewGuid(), id);

            Assert.NotNull(tarefaDetalhe);

            projetoRepository
                .Verify(x => x.Obter(It.IsAny<Guid>()));

        }

        [Fact]
        public async Task TarefaService_ObterDetalheTarefas_ProjetoNaoExiste_invalido()
        {
            SetupMockDefault();

            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(await Task.FromResult<Projeto>(null));

            var service = ObterService();
            var id = Guid.Empty;
            var tarefaDetalhe = await service.ObterTarefaDetalhe(Guid.NewGuid(), id);

            Assert.Null(tarefaDetalhe);

            projetoRepository
                .Verify(x => x.Obter(It.IsAny<Guid>()));

        }

        [Fact]
        public async Task TarefaService_ObterDetalheTarefas_TarefaNaoEncontrada_invalido()
        {
            SetupMockDefault();

            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(ObterProjetoComTarefas(15));

            var service = ObterService();
            var id = Guid.NewGuid();
            var tarefaDetalhe = await service.ObterTarefaDetalhe(Guid.NewGuid(), id);

            Assert.Null(tarefaDetalhe);

            projetoRepository
                .Verify(x => x.Obter(It.IsAny<Guid>()));

        }
    }
}
