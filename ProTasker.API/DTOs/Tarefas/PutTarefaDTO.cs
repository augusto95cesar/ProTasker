namespace ProTasker.API.DTOs.Tarefas
{
    public class PutTarefaDTO
    {
        public int CodigoTarefa { get; set; }
        public string Detalhes { get; set; }
        public int Status { get; set; }
    }
}
