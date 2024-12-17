using ProTasker.API.Data.ScriptBancoDados;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Executar um código na inicialização
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider; 
    new CreateDataBaseScript().Exec(connectionString);
}

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
