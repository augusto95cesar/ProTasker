using ProTasker.API.Models.Enum;

namespace ProTasker.API.Models.Entity
{
    public class Tarefa
    {
        public int Id { get; set; }
        public int IdProjeto { get; set; } 
        public string Nome { get; set; }
        public string Detalhes { get; set; }
        public PrioridadeTarefa PrioridadeTarefa { get; set; }
    }
}
