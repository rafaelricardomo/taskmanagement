namespace TaskManagement.Core.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; } = Guid.Empty;
        public DateTime DataInclusao { get; }
        public DateTime? DataAlteracao { get; private set; }

        public Entity() {            
            DataInclusao = DateTime.Now;
        }
        protected void AtualizarDataAlteracao()
        {
            DataAlteracao = DateTime.Now;
        }
    }
}
