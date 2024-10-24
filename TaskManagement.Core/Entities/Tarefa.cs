using TaskManagement.Core.Enums;

namespace TaskManagement.Core.Entities
{
    public class Tarefa : Entity, ICloneable
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime Vencimento { get; }
        public StatusEnum Status { get; private set; }
        public PrioridadeEnum Prioridade { get; }
        public List<Comentario> Comentarios { get; private set; }
        public Tarefa(string titulo, string descricao, DateTime vencimento, PrioridadeEnum prioridade)
            : base()
        {
            Titulo = titulo;
            Descricao = descricao;
            Vencimento = vencimento;
            Status = StatusEnum.Pendente;
            Prioridade = prioridade;
            Comentarios = new List<Comentario>();
        }

        public Tarefa(string titulo, string descricao, DateTime vencimento, StatusEnum status, PrioridadeEnum prioridade, List<Comentario> comentarios)
        {
            Titulo = titulo;
            Descricao = descricao;
            Vencimento = vencimento;
            Status = status;
            Prioridade = prioridade;
            Comentarios = comentarios;
        }

        protected Tarefa() { }

        public void Atualizar(string titulo, string descricao, StatusEnum status)
        {
            Titulo = titulo;
            Descricao = descricao;
            AtualizarStatus(status);
            AtualizarDataAlteracao();
        }

        private void AtualizarStatus(StatusEnum status)
        {
            if (status != StatusEnum.Pendente
                && Status != StatusEnum.Concluido)
                Status = status;
        }

        public void Comentar(string descricao)
        {
            if (Comentarios == null)
                Comentarios = new List<Comentario>();

            var novoComentario = new Comentario(descricao);

            Comentarios.Add(novoComentario);
        }

        public object Clone()
        {
            return new Tarefa(
                Titulo,
                Descricao,
                Vencimento,                 
                Status,
                Prioridade,
                Comentarios);
        }
    }
}
