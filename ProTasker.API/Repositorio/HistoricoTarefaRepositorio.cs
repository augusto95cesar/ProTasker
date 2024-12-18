using Dapper;
using Microsoft.Data.Sqlite;
using ProTasker.API.Data.Context;
using ProTasker.API.Models.Entity;
using System.Data;

namespace ProTasker.API.Repositorio
{
    public class HistoricoTarefaRepositorio
    {
        internal void GravarHistoricoTarefa(HistoricoTarefa historico)
        {
            using (IDbConnection dbConnection = new SqliteConnection(DataContext.GetDefaultConnectionString()))
            {
                dbConnection.Open();
                string insertQuery = @$"INSERT INTO HISTORICO_TAREFA
                                        (DataHistorico, CodigoUsuario, IdProjeto, IdTarefa, Titulo, Descricao, DataCriacao, DataVencimento, Status, PrioridadeTarefa)
                                        VALUES(@DataHistorico, @CodigoUsuario, @IdProjeto, @IdTarefa, @Titulo, @Descricao, @DataCriacao, @DataVencimento, @Status, @PrioridadeTarefa);";

                try
                {
                    dbConnection.Execute(insertQuery, historico);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
