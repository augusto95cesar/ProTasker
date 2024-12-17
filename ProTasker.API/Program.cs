using ProTasker.API.Data.ScriptBancoDados;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var services = scope.ServiceProvider;
        var configuration = services.GetRequiredService<IConfiguration>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var createDbScript = services.GetRequiredService<CreateDataBaseScript>();
        createDbScript.Exec(connectionString);
    }
    catch (Exception ex)
    { 
        throw ex;
    }
}

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
