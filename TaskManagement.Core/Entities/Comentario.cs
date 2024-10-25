namespace TaskManagement.Core.Entities
{
    public class Comentario : Entity
    {
        public string Descricao { get; }
        public Usuario Usuario { get; }

        public Comentario(string descricao, Usuario usuario) : base()
        {
            Descricao = descricao;
            Usuario = usuario;
        }

        protected Comentario() { }
    }
}
