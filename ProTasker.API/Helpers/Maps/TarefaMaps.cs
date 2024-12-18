using ProTasker.API.DTOs.Tarefas;
using ProTasker.API.Models.Entity;
using ProTasker.API.Models.Enum;

namespace ProTasker.API.Helpers.Maps
{
    public static class TarefaMaps
    {
        public static List<GetAllTarefasDTO> Map(this List<Tarefa> tarefas)
        {
            var l = new List<GetAllTarefasDTO>();

            foreach (var t in tarefas)
            {
                l.Add(new GetAllTarefasDTO
                {
                    Code = t.Id,
                    NomeTarefa = t.Titulo,
                    Descricao = t.Descricao,
                    Prioridade = t.PrioridadeTarefa.ToString()
                });
            }

            return l;
        }

        public static Tarefa Map(this PostTarefaDTO t)
        {
            var tarefas = new Tarefa
            {
                Titulo = t.NomeTarefa,
                Descricao = t.DescricaoTarefa,
                IdProjeto = t.CodigoProjeto,
                PrioridadeTarefa = (PrioridadeTarefa)t.CodigoPrioridade,
                DataCriacao = DateTime.Now,
                Status = StatusTarefa.Pendente
            };

            return tarefas;
        }

        public static Tarefa Map(this PutTarefaDTO t)
        {
            var tarefas = new Tarefa
            {
                Id = t.CodigoTarefa,
                Descricao = t.Detalhes,
                Status = (StatusTarefa)t.Status
            };

            return tarefas;
        }

        public static HistoricoTarefa Map(this Tarefa t)
        {
            HistoricoTarefa h = new HistoricoTarefa
            {
                IdTarefa = t.Id,
                IdProjeto = t.IdProjeto,
                DataCriacao = t.DataCriacao,
                Descricao = t.Descricao,
                Titulo = t.Titulo,
                PrioridadeTarefa = t.PrioridadeTarefa,
                Status = t.Status,
                DataVencimento = t.DataVencimento,
                DataHistorico = DateTime.Now
            };

            return h;
        }
    }
}
