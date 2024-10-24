using TaskManagement.Core.Enums;

namespace TaskManagement.Core.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; }
        public PerfilUsuarioEnum Perfil { get; }

        public Usuario(string nome, PerfilUsuarioEnum perfil) : base()
        {
            Nome = nome;
            Perfil = perfil;
        }

        protected Usuario() { }
    }
}
