using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using ProTasker.API.Data.ScriptBancoDados;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ProTasker.API.Helpers.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configura��o do Swagger
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

    // Configura��o do esquema de seguran�a
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT no formato: Bearer {seu_token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

    // Filtro para autentica��o por classe
    c.OperationFilter<AuthOperationFilter>();

});

var jwtSettings = builder.Configuration.GetSection("JwtSettings");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine($"Token inv�lido: {context.Exception.Message}");
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine($"Token v�lido: {context.SecurityToken}");
                return Task.CompletedTask;
            },
            OnChallenge = context =>
            {
                Console.WriteLine($"Falha de autentica��o: {context.ErrorDescription}");
                return Task.CompletedTask;
            }
        };
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


// Configura��o do pipeline de requisi��es HTTP.
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

app.UseAuthentication(); // Middleware para autentica��o
app.UseAuthorization();  // Middleware para autoriza��o 

app.MapControllers();

app.Run();
