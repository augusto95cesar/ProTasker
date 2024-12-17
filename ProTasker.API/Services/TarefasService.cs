using ProTasker.API.DTOs.Tarefas;
using ProTasker.API.Helpers.Maps;
using ProTasker.API.Repositorio;

namespace ProTasker.API.Services
{
    public class TarefasService
    {
        private TarefasRepositorio tarefasRepositorio;

        public TarefasService()
        {
            this.tarefasRepositorio = new TarefasRepositorio();
        }
        internal List<GetAllTarefasDTO> GetAll(int projetoId)
        {
            return this.tarefasRepositorio.GetAll(projetoId).Map();
        }

        public PostTarefaDTO Create(PostTarefaDTO tarefa)
        {
            var t = tarefa.Map();
            this.tarefasRepositorio.CreateTarefas(t);
            return tarefa;
        }
    }
}
