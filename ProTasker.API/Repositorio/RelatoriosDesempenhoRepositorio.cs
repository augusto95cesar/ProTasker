using Dapper;
using Microsoft.Data.Sqlite;
using ProTasker.API.Data.Context; 
using ProTasker.API.Models.Rdl;
using System.Data;

namespace ProTasker.API.Repositorio
{
    public class RelatoriosDesempenhoRepositorio
    {
        internal List<Desempenho> GetRdlDesempenho()
        {
            var checkTableQuery = $@"SELECT PROJETO.IdUser AS User , COUNT(T.Id) As QtdTaskConclida 
                                        FROM PROJETO INNER JOIN TAREFA T ON PROJETO.Id = T.IdProjeto 
                                        WHERE T.Status = 3
                                        GROUP BY PROJETO.IdUser ";

            using (IDbConnection dbConnection = new SqliteConnection(DataContext.GetDefaultConnectionString()))
            {
                dbConnection.Open(); 
                return dbConnection.Query<Desempenho>(checkTableQuery).ToList();
            }

        }
    }
}
