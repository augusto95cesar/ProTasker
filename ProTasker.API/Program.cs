using Microsoft.OpenApi.Models;
using ProTasker.API.Data.ScriptBancoDados;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API PRO-Tasker",
        Description = "Uma API de Gerenciamento de tarefas",
        Contact = new OpenApiContact
        {
            Name = "Augusto Cesar",
            Email = "augusto95cesar@gmail.com",
            Url = new Uri("https://github.com/augusto95cesar")
        }
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var services = scope.ServiceProvider;
        var configuration = services.GetRequiredService<IConfiguration>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        new CreateDataBaseScript().Exec(connectionString);
    }
    catch (Exception ex)
    {
        throw ex;
    }
}


// Configuração do pipeline de requisições HTTP.
//if (app.Environment.IsDevelopment())
//{
// Habilitar o Swagger apenas em ambiente de desenvolvimento
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API ProTasker");
    c.RoutePrefix = string.Empty; // Para acessar diretamente no root
});
//}

app.UseHttpsRedirection();
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
