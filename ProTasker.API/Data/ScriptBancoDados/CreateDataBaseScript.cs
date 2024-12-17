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

        internal void Exec(string connectionString)
        {
            try
            {
                using (IDbConnection dbConnection = new SqliteConnection(connectionString))
                {
                    dbConnection.Open();

                    CreateUsuarios(dbConnection);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
