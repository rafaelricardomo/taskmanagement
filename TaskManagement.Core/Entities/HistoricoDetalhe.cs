namespace TaskManagement.Core.Entities
{
    public class HistoricoDetalhe : Entity
    {
        public string Campo { get; }
        public Usuario Usuario { get; }
        public string ValorAntigo { get; }
        public string ValorNovo { get; }
        public HistoricoDetalhe(string campo, string valorAntigo, string valorNovo, Usuario usuario) : base()
        {
            Campo = campo;
            Usuario = usuario;
            ValorAntigo = valorAntigo;
            ValorNovo = valorNovo;
        }

        protected HistoricoDetalhe() { }
    }
}
