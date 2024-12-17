using ProTasker.API.Models.Enum;

namespace ProTasker.API.Models.Entity
{
    public class Tarefa
    {
        public int Id { get; set; }
        public int IdProjeto { get; set; } 
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get;  set; }
        public DateTime? DataVencimento { get;  set; }
        public StatusTarefa Status { get;  set; }
        public PrioridadeTarefa PrioridadeTarefa { get; set; }
    }
}
