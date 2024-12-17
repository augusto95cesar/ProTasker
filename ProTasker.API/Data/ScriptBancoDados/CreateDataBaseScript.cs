using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;

namespace ProTasker.API.Data.ScriptBancoDados
{
    public class CreateDataBaseScript
    {
        string TBUsuarios = $@"
                CREATE TABLE IF NOT EXISTS USUARIO (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Login TEXT NOT NULL,
                    Senha TEXT NOT NULL,
                    TipoUsuario INTEGER NOT NULL
                );";

        string TBProjetos = $@"
                CREATE TABLE IF NOT EXISTS PROJETO (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    IdUser INTEGER NOT NULL,
                    Nome TEXT NOT NULL,
                    DataCriacao TEXT NOT NULL,
                    StatusProjeto INTEGER NOT NULL
                );";

        string TBTarefas = $@"
                CREATE TABLE IF NOT EXISTS TAREFA (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    IdProjeto INTEGER NOT NULL,
                    Nome TEXT NOT NULL,
                    Detalhes TEXT NOT NULL,
                    PrioridadeTarefa INTEGER NOT NULL,
                    DataCriacao TEXT NOT NULL,
                    DataFinalizacao TEXT,
                    Status INTEGER NOT NULL
                );";

        internal void Exec(string connectionString)
        {
            try
            {
                using (IDbConnection dbConnection = new SqliteConnection(connectionString))
                {
                    dbConnection.Open();

                    CreateUsuarios(dbConnection);
                    CreateProjetos(dbConnection);
                    CreateTarefas(dbConnection);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CreateTarefas(IDbConnection dbConnection)
        {
            string createTableQuery = TBTarefas;
            dbConnection.Execute(createTableQuery);
        }
        private void CreateProjetos(IDbConnection dbConnection)
        {
            string createTableQuery = TBProjetos;
            dbConnection.Execute(createTableQuery);
        }
        private void CreateUsuarios(IDbConnection dbConnection)
        {
            var Login = "Master";

            string createTableQuery = TBUsuarios;
            dbConnection.Execute(createTableQuery);

            string checkTableQuery = @"SELECT Login FROM USUARIO WHERE LOGIN = @Login";

            var result = dbConnection.Query<string>(checkTableQuery, new { Login = Login }).Count();

            if (!(result > 0))
            {
                string insertQuery = "INSERT INTO USUARIO (Login, Senha, TipoUsuario) VALUES (@Login, @Senha, @TipoUsuario);";
                dbConnection.Execute(insertQuery, new { Login = Login, Senha = "123456", TipoUsuario = 2 });
            }
        }
    }
}
