namespace TaskManagement.Core.Entities
{
    public class HistoricoDetalhe : Entity
    {
        public string Campo { get; }        
        public string ValorAntigo { get; }
        public string ValorNovo { get; }
        public HistoricoDetalhe(string campo, string valorAntigo, string valorNovo) : base()
        {
            Campo = campo;          
            ValorAntigo = valorAntigo;
            ValorNovo = valorNovo;
        }

        protected HistoricoDetalhe() { }
    }
}
