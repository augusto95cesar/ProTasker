using Dapper;
using Microsoft.Data.Sqlite;
using ProTasker.API.Data.Context;
using ProTasker.API.Models.Entity;
using System.Data;

namespace ProTasker.API.Repositorio
{
    public class TarefasRepositorio
    {
        public List<Tarefa> GetAll (int projetoId)
        {
            using (IDbConnection dbConnection = new SqliteConnection(DataContext.GetDefaultConnectionString()))
            {
                dbConnection.Open();
                string checkTableQuery = @"SELECT * FROM TAREFA WHERE IdProjeto = @Id";

                return dbConnection.Query<Tarefa>(checkTableQuery, new { Id = projetoId }).ToList();
            }
        }
    }
}
