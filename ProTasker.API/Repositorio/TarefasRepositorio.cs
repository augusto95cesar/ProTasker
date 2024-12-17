using Dapper;
using Microsoft.Data.Sqlite;
using ProTasker.API.Data.Context;
using ProTasker.API.Models.Entity;
using ProTasker.API.Models.Enum;
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

        internal void CreateTarefas(Tarefa t)
        {
            using (IDbConnection dbConnection = new SqliteConnection(DataContext.GetDefaultConnectionString()))
            {
                dbConnection.Open();
                string insertQuery = @$"INSERT INTO TAREFA (IdProjeto,Nome,Detalhes,PrioridadeTarefa,DataCriacao, Status)  
                                     VALUES (@IdProjeto, @Nome, @Detalhes, @PrioridadeTarefa, @DataCriacao, @Status)";

                dbConnection.Execute(insertQuery, new { IdProjeto = t.IdProjeto, Nome = t.Nome, Detalhes = t.Detalhes, PrioridadeTarefa = t.PrioridadeTarefa, DataCriacao = t.DataCriacao.ToString("yyyy-MM-dd"), Status = t.Status });
            }
        }
    }
}
