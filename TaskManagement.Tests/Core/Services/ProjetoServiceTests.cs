using Moq;
using TaskManagement.Core.Dtos;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Enums;
using TaskManagement.Core.Interfaces;
using TaskManagement.Core.Services;
using Xunit;

namespace TaskManagement.Tests.Core.Services
{
    public class ProjetoServiceTests : TestBase
    {
        private readonly Mock<IProjetoRepository> projetoRepository;

        public ProjetoServiceTests()
        {
            projetoRepository = new Mock<IProjetoRepository>();
        }

        private ProjetoService ObterService() =>
            new(projetoRepository.Object);
        private Projeto ObterProjeto() =>
             new Projeto("Nome teste 1");

        private List<Projeto> ListarProjetos()=> new List<Projeto>() { ObterProjeto() };

        private Projeto ObterProjetoComTarefas(int limiteTarefas)
        {
            var projeto = ObterProjeto();

            for (var i = 0; i < limiteTarefas; i++)
            {
                projeto.AdicionarTarefa(
                   $"Tarefa teste {i}",
                   $"Teste {i}",
                   DateTime.Today.AddDays(i + 1),
                   PrioridadeEnum.Baixa
                   );
            }

            return projeto;
        }

        private CriarProjetoDto CriarProjetoDto() => new CriarProjetoDto("Nome teste 2");

        private AlterarProjetoDto AlterarProjetoDto() => new AlterarProjetoDto(Guid.NewGuid(), "Nome teste 2");

        [Fact]
        public async Task ProjetoService_CriarProjeto_valido()
        {
            projetoRepository
                .Setup(x => x.Criar(It.IsAny<Projeto>()));

            var dto = CriarProjetoDto();
            var service = ObterService();

            await service.CriarProjeto(dto);

            projetoRepository
               .Verify(x => x.Criar(It.IsAny<Projeto>()));

        }

        [Fact]
        public async Task ProjetoService_AlterarProjeto_valido()
        {
            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(ObterProjeto());

            projetoRepository
                .Setup(x => x.Alterar(It.IsAny<Projeto>()));

            var dto = AlterarProjetoDto();
            var service = ObterService();
            var id = Guid.NewGuid();
            await service.AlterarProjeto(id, dto);

            projetoRepository
              .Verify(x => x.Obter(It.IsAny<Guid>()));
            projetoRepository
               .Verify(x => x.Alterar(It.IsAny<Projeto>()));

        }

        [Fact]
        public async Task ProjetoService_AlterarProjeto_NaoExiste_invalido()
        {
            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(await Task.FromResult<Projeto>(null));

            projetoRepository
                .Setup(x => x.Alterar(It.IsAny<Projeto>()));

            var dto = AlterarProjetoDto();
            var service = ObterService();
            var id = Guid.NewGuid();
            await service.AlterarProjeto(id, dto);

            projetoRepository
              .Verify(x => x.Obter(It.IsAny<Guid>()));

        }

        [Fact]
        public async Task ProjetoService_RemoverProjeto_valido()
        {
            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(ObterProjeto());

            projetoRepository
                .Setup(x => x.Remover(It.IsAny<Guid>()));

            var service = ObterService();
            var id = Guid.NewGuid();
            await service.RemoverProjeto(id);

            projetoRepository
              .Verify(x => x.Obter(It.IsAny<Guid>()));
            projetoRepository
               .Verify(x => x.Remover(It.IsAny<Guid>()));

        }

        [Fact]
        public async Task ProjetoService_RemoverProjeto_NaoExiste_invalido()
        {
            projetoRepository
                 .Setup(x => x.Obter(It.IsAny<Guid>()))
                 .ReturnsAsync(await Task.FromResult<Projeto>(null));

            projetoRepository
                .Setup(x => x.Remover(It.IsAny<Guid>()));

            var service = ObterService();
            var id = Guid.NewGuid();
            await service.RemoverProjeto(id);

            projetoRepository
              .Verify(x => x.Obter(It.IsAny<Guid>()));

        }

        [Fact]
        public async Task ProjetoService_RemoverProjeto_TarefasPendentes_invalido()
        {
            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(ObterProjetoComTarefas(5));

            projetoRepository
                .Setup(x => x.Remover(It.IsAny<Guid>()));

            var service = ObterService();
            var id = Guid.NewGuid();
            var erro = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await service.RemoverProjeto(id)
            );

            Assert.NotNull(erro);

            projetoRepository
              .Verify(x => x.Obter(It.IsAny<Guid>()));

        }

        [Fact]
        public async Task ProjetoService_ListarProjetos_valido()
        {
            projetoRepository
                .Setup(x => x.Listar())
                .ReturnsAsync(ListarProjetos());

            var service = ObterService();
           
            var projetos = await service.ListarProjetos();

            Assert.NotNull(projetos);
            Assert.True(projetos.Any());    

            projetoRepository
              .Verify(x => x.Listar());
          
        }

        [Fact]
        public async Task ProjetoService_ListarProjetos_invalido()
        {
            projetoRepository
                .Setup(x => x.Listar())
                .ReturnsAsync(await Task.FromResult<List<Projeto>>(null));

            var service = ObterService();

            var projetos = await service.ListarProjetos();

            Assert.NotNull(projetos);
            Assert.False(projetos.Any());

            projetoRepository
              .Verify(x => x.Listar());

        }

        [Fact]
        public async Task ProjetoService_ObterDetalhesProjetos_valido()
        {
            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(ObterProjetoComTarefas(2));

            var service = ObterService();

            var projetoDetalhe = await service.ObterProjetoDetalhe(Guid.NewGuid());

            Assert.NotNull(projetoDetalhe);
            Assert.NotNull(projetoDetalhe.tarefas);
            Assert.True(projetoDetalhe.tarefas.Any());  

            projetoRepository
               .Verify(x => x.Obter(It.IsAny<Guid>()));

        }

        [Fact]
        public async Task ProjetoService_ObterDetalhesProjetos_NaoExiste_invalido()
        {
            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(await Task.FromResult<Projeto>(null));

            var service = ObterService();

            var projetoDetalhe = await service.ObterProjetoDetalhe(Guid.NewGuid());

            Assert.Null(projetoDetalhe);

            projetoRepository
               .Verify(x => x.Obter(It.IsAny<Guid>()));

        }

        [Fact]
        public async Task ProjetoService_ObterDetalhesProjetos_SemTarefas_valido()
        {
            projetoRepository
                .Setup(x => x.Obter(It.IsAny<Guid>()))
                .ReturnsAsync(ObterProjeto());

            var service = ObterService();

            var projetoDetalhe = await service.ObterProjetoDetalhe(Guid.NewGuid());

            Assert.NotNull(projetoDetalhe);
            Assert.NotNull(projetoDetalhe.tarefas);
            Assert.False(projetoDetalhe.tarefas.Any());

            projetoRepository
               .Verify(x => x.Obter(It.IsAny<Guid>()));

        }


    }
}
