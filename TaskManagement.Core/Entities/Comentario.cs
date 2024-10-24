namespace TaskManagement.Core.Entities
{
    public class Comentario : Entity
    {
        public string Descricao { get; }
        public Comentario(string descricao):base()
        {
            Descricao = descricao;
        }

        protected Comentario() { }
    }
}
