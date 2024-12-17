using Dapper; 
using Microsoft.Data.Sqlite;
using ProTasker.API.Data.Context; 
using ProTasker.API.Models.Entity;
using System.Data;

namespace ProTasker.API.Repositorio
{
    public class ProjetoRepositorio
    {
        internal List<Projeto> GetProjestos(int userId)
        {
            using (IDbConnection dbConnection = new SqliteConnection(DataContext.GetDefaultConnectionString()))
            {
                dbConnection.Open();
                string checkTableQuery = @"SELECT * FROM PROJETO WHERE IdUser = @Id";

                return dbConnection.Query<Projeto>(checkTableQuery, new { Id = userId }).ToList();
            }
        }
    }
}
