using ProTasker.API.DTOs;

namespace ProTasker.API.Services
{
    public class ProjetoService
    {
        internal List<GetAllProjetosDTO> GetAll(int userId)
        {
            var lista = new List<GetAllProjetosDTO>();
            lista.Add(new GetAllProjetosDTO { Code = 1 , Nome = "Projeto 1", Status = "Ativo"});
            lista.Add(new GetAllProjetosDTO { Code = 2 , Nome = "Projeto 2", Status = "Ativo"});
            lista.Add(new GetAllProjetosDTO { Code = 3 , Nome = "Projeto 3", Status = "Ativo"});
 
            return lista;
        }
    }
}
