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
            CriarDetalhesComentarios(tarefaAnterior, tarefaAtual);
        }

        protected Historico() { }

        private void CriarDetalhesTarefas(Tarefa tarefaAnterior, Tarefa tarefaAtual)
        {
            var historicoTitulo = new HistoricoDetalhe(
                nameof(tarefaAnterior.Titulo),
                tarefaAnterior.Titulo,
                tarefaAtual.Titulo
                );

            Detalhes.Add(historicoTitulo);

            var historicoDescricao = new HistoricoDetalhe(
               nameof(tarefaAnterior.Descricao),
               tarefaAnterior.Descricao,
               tarefaAtual.Descricao
               );

            Detalhes.Add(historicoDescricao);

            var historicoStatus = new HistoricoDetalhe(
                 nameof(tarefaAnterior.Status),
                 tarefaAnterior.Status.ToString(),
                 tarefaAtual.Status.ToString()
                 );

            Detalhes.Add(historicoStatus);

            var historicoPrioridade = new HistoricoDetalhe(
                nameof(tarefaAnterior.Prioridade),
                tarefaAnterior.Prioridade.ToString(),
                tarefaAtual.Prioridade.ToString()
                );

            Detalhes.Add(historicoPrioridade);

            var historicoVencimento = new HistoricoDetalhe(
                nameof(tarefaAnterior.Vencimento),
                tarefaAnterior.Vencimento.ToString(),
                tarefaAtual.Vencimento.ToString()
                );

            Detalhes.Add(historicoVencimento);
        }

        private void CriarDetalhesComentarios(Tarefa tarefaAnterior, Tarefa tarefaAtual)
        {
            if (tarefaAtual.Comentarios == null || !tarefaAtual.Comentarios.Any()) return;

            foreach (var comentarioAtual in tarefaAtual.Comentarios)
            {
                var comentarioAnterior = tarefaAnterior.Comentarios?.FirstOrDefault(c => c.Id == comentarioAtual.Id);
               
                var historicoComentario = new HistoricoDetalhe(
                    nameof(tarefaAtual.Comentarios),
                    comentarioAnterior?.Descricao ?? string.Empty,
                    comentarioAtual?.Descricao ?? string.Empty
                    );

                Detalhes.Add(historicoComentario);
            }
        }
    }
}
