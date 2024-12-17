using ProTasker.API.DTOs.Tarefas;
using ProTasker.API.Helpers.Maps;
using ProTasker.API.Repositorio;

namespace ProTasker.API.Services
{
    public class TarefasService
    {
        internal List<GetAllTarefasDTO> GetAll(int projetoId)
        {
            return new TarefasRepositorio().GetAll(projetoId).Map();
        }
    }
}
