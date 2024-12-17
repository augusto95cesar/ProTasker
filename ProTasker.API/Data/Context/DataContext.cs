namespace ProTasker.API.Data.Context
{
    public static class DataContext
    {
        private static IConfiguration _configuration;
        static DataContext()
        {
            // Carrega o arquivo appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Caminho atual da aplicação
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        /// <summary>
        /// Retorna a ConnectionString padrão configurada no appsettings.json.
        /// </summary>
        /// <returns>ConnectionString</returns>
        public static string GetDefaultConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Busca uma ConnectionString pelo nome.
        /// </summary>
        /// <param name="name">Nome da ConnectionString.</param>
        /// <returns>ConnectionString</returns>
        public static string GetConnectionString(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("O nome da conexão não pode ser nulo ou vazio.");

            return _configuration.GetConnectionString(name);
        }
    }
}
