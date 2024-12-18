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
        public List<Tarefa> GetAll(int projetoId)
        {
            using (IDbConnection dbConnection = new SqliteConnection(DataContext.GetDefaultConnectionString()))
            {
                dbConnection.Open();
                string checkTableQuery = @"SELECT * FROM TAREFA WHERE IdProjeto = @Id";

                return dbConnection.Query<Tarefa>(checkTableQuery, new { Id = projetoId }).ToList();
            }
        }

        public Tarefa Get(int id)
        {
            using (IDbConnection dbConnection = new SqliteConnection(DataContext.GetDefaultConnectionString()))
            {
                dbConnection.Open();
                string checkTableQuery = @"SELECT * FROM TAREFA WHERE Id = @Id";

                return dbConnection.Query<Tarefa>(checkTableQuery, new { Id = id }).FirstOrDefault();
            }
        }

        internal void CreateTarefas(Tarefa t)
        {
            using (IDbConnection dbConnection = new SqliteConnection(DataContext.GetDefaultConnectionString()))
            {
                dbConnection.Open();
                string insertQuery = @$"INSERT INTO TAREFA (IdProjeto,Titulo,Descricao,PrioridadeTarefa,DataCriacao, Status)  
                                     VALUES (@IdProjeto, @Titulo, @Descricao, @PrioridadeTarefa, @DataCriacao, @Status)";

                dbConnection.Execute(insertQuery, new
                {
                    IdProjeto = t.IdProjeto,
                    Titulo = t.Titulo,
                    Descricao = t.Descricao,
                    PrioridadeTarefa = t.PrioridadeTarefa,
                    DataCriacao = t.DataCriacao.ToString("yyyy-MM-dd"),
                    Status = t.Status
                });
            }
        }

        internal void PutTarefasDescricao(Tarefa t)
        {
            using (IDbConnection dbConnection = new SqliteConnection(DataContext.GetDefaultConnectionString()))
            {
                dbConnection.Open();
                string insertQuery = @$"UPDATE TAREFA SET Descricao = @Descricao WHERE Id = @Id  ";

                dbConnection.Execute(insertQuery, new
                {
                    Id = t.Id,
                    Descricao = t.Descricao
                });
            }
        }

        internal void PutTarefasStatus(Tarefa t)
        {
            using (IDbConnection dbConnection = new SqliteConnection(DataContext.GetDefaultConnectionString()))
            {
                dbConnection.Open();
                string insertQuery = @$"UPDATE TAREFA SET   Status = @Status WHERE Id = @Id  ";

                dbConnection.Execute(insertQuery, new
                {
                    Id = t.Id,
                    Status = t.Status
                });
            }
        }

        internal void Delete(int tarefaId)
        {
            using (IDbConnection dbConnection = new SqliteConnection(DataContext.GetDefaultConnectionString()))
            {
                dbConnection.Open();
                string insertQuery = @$"DELETE FROM TAREFA WHERE Id = @Id  ";

                dbConnection.Execute(insertQuery, new
                {
                    Id = tarefaId
                });
            }
        }

        internal bool ExisteTarefaPendenteParaOProjeto(int projetoId)
        {
            using (IDbConnection dbConnection = new SqliteConnection(DataContext.GetDefaultConnectionString()))
            {
                dbConnection.Open();

                string insertQuery = @$"SELECT Count(*) FROM TAREFA WHERE IdProjeto = @Id AND Status = @Status ";

                var existe = dbConnection.Query<int>(insertQuery, new
                {
                    Id = projetoId,
                    Status = StatusTarefa.Pendente
                }).FirstOrDefault();

                return existe > 0 ? true : false;
            }
        }
    }
}
