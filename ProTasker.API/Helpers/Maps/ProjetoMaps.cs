using ProTasker.API.DTOs;
using ProTasker.API.Models.Entity;

namespace ProTasker.API.Helpers.Maps
{
    public static class ProjetoMaps
    {
       public static List<GetAllProjetosDTO> Map(this List<Projeto> projetos)
        {
            var l = new List<GetAllProjetosDTO>();

            foreach (var p in projetos)
            {
                l.Add(new GetAllProjetosDTO
                {
                    Code = p.Id,
                    Nome = p.Nome,
                    Status =  p.StatusProjeto.ToString()
                });
            }

            return l;
        }
    }
}
