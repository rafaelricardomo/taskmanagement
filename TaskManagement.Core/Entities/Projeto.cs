using TaskManagement.Core.Enums;

namespace TaskManagement.Core.Entities
{
    public class Projeto : Entity
    {
        public string Nome { get; private set; }
        public List<Tarefa> Tarefas { get; private set; }

        public Projeto(string nome) : base()
        {
            Nome = nome;
            Tarefas = new List<Tarefa>();
        }

        protected Projeto() { }

        private const int LimiteMaximoTarefas = 20;
        public bool AtingiuLimiteTarefas => Tarefas.Count == LimiteMaximoTarefas;
        public bool PossuiTarefasPendentes => Tarefas.Any(t => t.Status.Equals(Enums.StatusEnum.Pendente));

        public void Atualizar(string nome)
        {
            Nome = nome;
            AtualizarDataAlteracao();
        }

        public void AdicionarTarefa(string titulo, string descricao, DateTime vencimento, PrioridadeEnum prioridade)
        {
           
            var novaTarefa = new Tarefa(
                titulo,
                descricao,
                vencimento,
                prioridade
                );

            Tarefas.Add(novaTarefa);
        }

        public void AtualizarTarefa(Guid id, string titulo, string descricao, StatusEnum status)
        {
            var tarefaAtual = Tarefas?.FirstOrDefault(t => t.Id == id);
            if (tarefaAtual != null)
            {
                tarefaAtual.Atualizar(
                    titulo,
                    descricao,
                    status
                );
            }

        }

        public void ComentarTarefa(Guid id, string descricao, Usuario usuario)
        {
            var tarefaAtual = Tarefas?.FirstOrDefault(t => t.Id == id);
            if (tarefaAtual != null)
            {
                tarefaAtual.Comentar(descricao, usuario);
            }

        }

        public void RemoverTarefa(Guid id)
        {
            var tarefaAtual = Tarefas?.FirstOrDefault(t => t.Id == id);
            if (tarefaAtual != null)
            {
                Tarefas?.Remove(tarefaAtual);
            }

        }

        public Tarefa? ClonarTarefa(Guid id)
        {
            var tarefaAtual = Tarefas?.FirstOrDefault(t => t.Id == id);
            if (tarefaAtual != null)
            {
                return (Tarefa)tarefaAtual.Clone();
            }
            return null;
        }

        public Tarefa? ObterTarefa(Guid id)
        {
            return Tarefas?.FirstOrDefault(t => t.Id == id);         
        }
    }
}
