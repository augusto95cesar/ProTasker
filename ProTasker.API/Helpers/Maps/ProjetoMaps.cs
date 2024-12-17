using ProTasker.API.DTOs;
using ProTasker.API.DTOs.Projetos;
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
                    Status = p.StatusProjeto.ToString()
                });
            }

            return l;
        }

        public static Projeto CreateMap(this PostProjetoDTO p)
        {
            return new Projeto
            {
                IdUser = p.UsuarioId,
                Nome = p.NomeProjeto,
                DataCriacao = DateTime.Now,
                StatusProjeto = Models.Enum.StatusProjeto.Ativo
            };
        }
    }
}
