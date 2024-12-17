namespace ProTasker.API.DTOs.Tarefas
{
    public class PostTarefaDTO
    {
        public int CodigoProjeto { get; set; }
        public string NomeTarefa { get; set; }
        public string DescricaoTarefa { get; set; }
        public int CodigoPrioridade { get; set; }
    }
}
