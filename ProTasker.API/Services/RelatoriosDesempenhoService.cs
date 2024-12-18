using ProTasker.API.DTOs.RelatoriosDesempenho;
using ProTasker.API.Models.Rdl;
using ProTasker.API.Repositorio;
using System.Collections.Generic;

namespace ProTasker.API.Services
{
    public class RelatoriosDesempenhoService
    {
        internal List<GetDesempenhoDTO> GetRdlDesempenho()
        {
            var rdl = new List<GetDesempenhoDTO>();
           foreach(var item in new RelatoriosDesempenhoRepositorio().GetRdlDesempenho())
            {
                rdl.Add(new GetDesempenhoDTO
                {
                    Usuario = item.User,
                    QuatidadeTarefasConcluida = item.QtdTaskConclida
                });
            }

            return rdl;
        }
    }
}
