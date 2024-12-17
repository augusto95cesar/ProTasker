using ProTasker.API.DTOs;
using ProTasker.API.DTOs.Projetos;
using ProTasker.API.Helpers.Maps;
using ProTasker.API.Repositorio; 

namespace ProTasker.API.Services
{
    public class ProjetoService
    {
        public List<GetAllProjetosDTO> GetAll(int userId)
        {
          return new ProjetoRepositorio().GetProjestos(userId).Map();
        }
        public PostProjetoDTO Create(PostProjetoDTO newProjeto)
        {
            return newProjeto;
        }
    }
}
