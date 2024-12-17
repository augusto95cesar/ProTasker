using ProTasker.API.DTOs;
using ProTasker.API.DTOs.Projetos;
using ProTasker.API.Helpers.Maps;
using ProTasker.API.Repositorio; 

namespace ProTasker.API.Services
{
    public class ProjetoService
    {
        private ProjetoRepositorio projetoRepositorio;

        public ProjetoService()
        {
            this.projetoRepositorio = new ProjetoRepositorio();
        }
        public List<GetAllProjetosDTO> GetAll(int userId)
        {
          return this.projetoRepositorio.GetProjestos(userId).Map();
        }
        public PostProjetoDTO Create(PostProjetoDTO newProjeto)
        {
            //Verificar se Usuario Existe
            //()

            var projeto = newProjeto.CreateMap();
            this.projetoRepositorio.CreateProjetos(projeto);
            return newProjeto;
        }
    }
}
