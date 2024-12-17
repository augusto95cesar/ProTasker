using Dapper; 
using Microsoft.Data.Sqlite;
using ProTasker.API.Data.Context; 
using ProTasker.API.Models.Entity;
using ProTasker.API.Models.Enum;
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

        internal void CreateProjetos(Projeto p)
        {
            using (IDbConnection dbConnection = new SqliteConnection(DataContext.GetDefaultConnectionString()))
            {
                dbConnection.Open();
                string insertQuery = @"INSERT INTO PROJETO (IdUser, Nome, DataCriacao, StatusProjeto) VALUES (@IdUser, @Nome, @DataCriacao, @StatusProjeto)"; 
                dbConnection.Execute(insertQuery, new { IdUser = p.IdUser, Nome = p.Nome, DataCriacao = p.DataCriacao.ToString("yyyy-MM-dd"), StatusProjeto = (int)p.StatusProjeto });
            }
        }
    }
}
