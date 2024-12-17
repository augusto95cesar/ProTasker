using ProTasker.API.Models.Entity;

namespace ProTasker.API.DTOs.Tarefas
{
    public class GetAllTarefasDTO
    {
        public int Code { get;  set; }
        public string NomeTarefa { get;  set; }
        public string Descricao { get;  set; }
        public string Prioridade { get;  set; } 
    }
}
