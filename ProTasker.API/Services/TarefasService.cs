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
        /// <summary>
        /// Visualização de Tarefas - visualizar todas as tarefas de um projeto específico
        /// </summary>
        /// <param name="projetoId"></param>
        /// <returns></returns>
        internal List<GetAllTarefasDTO> GetAll(int projetoId)
        {
            return this.tarefasRepositorio.GetAll(projetoId).Map();
        }

        /// <summary>
        /// Criação de Tarefas - adicionar uma nova tarefa a um projeto
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        public PostTarefaDTO Create(PostTarefaDTO tarefa)
        {
            var t = tarefa.Map();
            this.tarefasRepositorio.CreateTarefas(t);
            return tarefa;
        }

        /// <summary>
        /// Atualização de Tarefas - atualizar o status ou detalhes de uma tarefa
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        public PutTarefaDTO Put(PutTarefaDTO tarefa)
        {
            var t = tarefa.Map();
            this.tarefasRepositorio.PutTarefasStatus(t);
            this.tarefasRepositorio.PutTarefasDescricao(t);
            return tarefa;
        }
    }
}
