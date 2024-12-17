using ProTasker.API.Models.Enum;

namespace ProTasker.API.Models.Entity
{
    public class Projeto
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public StatusProjeto StatusProjeto { get; set; }
    }
}
