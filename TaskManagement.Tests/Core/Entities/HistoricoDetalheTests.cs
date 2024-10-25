using TaskManagement.Core.Entities;
using Xunit;

namespace TaskManagement.Tests.Core.Entities
{
    public class HistoricoDetalheTests
    {
        [Fact]
        public void HistoricoDetalhe_criar_valido()
        {
            var historicoDetalhe = new HistoricoDetalhe(
                "Valor",
                123.ToString(),
                456.ToString()
                );

            Assert.NotNull(historicoDetalhe);
            Assert.Equal("Valor", historicoDetalhe.Campo);
            Assert.Equal(123.ToString(), historicoDetalhe.ValorAntigo);
            Assert.Equal(456.ToString(), historicoDetalhe.ValorNovo);

        }
    }
}
