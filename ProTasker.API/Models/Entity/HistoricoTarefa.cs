using ProTasker.API.Models.Enum;

namespace ProTasker.API.Models.Entity
{
    public class HistoricoTarefa : Tarefa
    { 
        public int IdTarefa { get; set; }
        public DateTime DataHistorico { get; internal set; }
        public int CodigoUsuario { get; internal set; }
    }
}
