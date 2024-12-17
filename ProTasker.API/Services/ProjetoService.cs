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

        /// <summary>
        /// Listagem de Projetos - listar todos os projetos do usuário
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<GetAllProjetosDTO> GetAll(int userId)
        {
          return this.projetoRepositorio.GetProjestos(userId).Map();
        }

        /// <summary>
        /// Criação de Projetos - criar um novo projeto
        /// </summary>
        /// <param name="newProjeto"></param>
        /// <returns></returns>
        public PostProjetoDTO Create(PostProjetoDTO newProjeto)
        {
            //Verificar se Usuario Existe
            //()

            var projeto = newProjeto.CreateMap();
            this.projetoRepositorio.CreateProjetos(projeto);
            return newProjeto;
        }

        /// <summary>
        /// Remove Projeto
        /// </summary>
        /// <param name="newProjeto"></param>
        /// <returns></returns>
        public void Delete(int projetoId)
        { 
            this.projetoRepositorio.Delete(projetoId); 
        }
    }
}
