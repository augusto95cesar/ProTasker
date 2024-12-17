using ProTasker.API.DTOs.Tarefas;
using ProTasker.API.Helpers.Maps;
using ProTasker.API.Models.Enum;
using ProTasker.API.Repositorio;
using System.Drawing;

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
            //Validação Enum Prioridade
            if (!Enum.IsDefined(typeof(PrioridadeTarefa), tarefa.CodigoPrioridade))
                throw new Exception("Selecione um Codigo de Prioridade Valido!");

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

        /// <summary>
        /// Remoção de Tarefas - remover uma tarefa de um projeto
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        public void Delete(int tarefaId)
        {
            this.tarefasRepositorio.Delete(tarefaId);
        }
    }
}
