using ProTasker.API.DTOs.Projetos;
using ProTasker.API.DTOs.Tarefas;
using ProTasker.API.Models.Entity;

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
                    NomeTarefa = t.Nome,
                    Descricao = t.Detalhes,
                    Prioridade = t.PrioridadeTarefa.ToString()
                });
            }

            return l;
        }
    }
}
