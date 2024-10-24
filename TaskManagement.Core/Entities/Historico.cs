namespace TaskManagement.Core.Entities
{
    public class Historico : Entity
    {
        public string Descricao { get; }
        public Usuario Usuario { get; }
        public List<HistoricoDetalhe> Detalhes { get; }
        public Historico(string descricao, Tarefa tarefaAnterior, Tarefa tarefaAtual, Usuario usuario) : base()
        {
            Descricao = descricao;
            Usuario = usuario;
            Detalhes = new List<HistoricoDetalhe>();
            CriarDetalhesTarefas(tarefaAnterior, tarefaAtual);
        }

        protected Historico() { }

        private void CriarDetalhesTarefas(Tarefa tarefaAnterior, Tarefa tarefaAtual)
        {
            var historicoTitulo = new HistoricoDetalhe(
                nameof(tarefaAnterior.Titulo),
                tarefaAnterior.Titulo,
                tarefaAtual.Titulo,
                Usuario);

            Detalhes.Add(historicoTitulo);

            var historicoDescricao = new HistoricoDetalhe(
               nameof(tarefaAnterior.Descricao),
               tarefaAnterior.Descricao,
               tarefaAtual.Descricao,
               Usuario
               );

            Detalhes.Add(historicoDescricao);

            var historicoStatus = new HistoricoDetalhe(
                 nameof(tarefaAnterior.Status),
                 tarefaAnterior.Status.ToString(),
                 tarefaAtual.Status.ToString(),
                 Usuario
                 );

            Detalhes.Add(historicoStatus);

            var historicoPrioridade = new HistoricoDetalhe(
                nameof(tarefaAnterior.Prioridade),
                tarefaAnterior.Prioridade.ToString(),
                tarefaAtual.Prioridade.ToString(),
                Usuario
                );

            Detalhes.Add(historicoPrioridade);

            var historicoVencimento = new HistoricoDetalhe(
                nameof(tarefaAnterior.Vencimento),
                tarefaAnterior.Vencimento.ToString(),
                tarefaAtual.Vencimento.ToString(),
                Usuario
                );

            Detalhes.Add(historicoVencimento);
        }

        private void CriarDetalhesComentarios(Tarefa tarefaAnterior, Tarefa tarefaAtual)
        {
            if (tarefaAnterior.Comentarios == null || !tarefaAnterior.Comentarios.Any()) return;

            foreach (var comentarioAnterior in tarefaAnterior.Comentarios)
            {
                var comentarioAtual = tarefaAtual.Comentarios.FirstOrDefault(c => c.Id == comentarioAnterior.Id);
                var historicoComentario = new HistoricoDetalhe(
                    nameof(comentarioAnterior.Descricao),
                    comentarioAnterior.Descricao.ToString(),
                    comentarioAtual?.Descricao?.ToString(),
                    Usuario
                    );

                Detalhes.Add(historicoComentario);
            }
        }
    }
}
