using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProTasker.API.Helpers.Swagger
{
    public class AuthOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Verifica se a classe ou o método tem o atributo [Authorize]
            var hasAuthorize = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                                   .OfType<Microsoft.AspNetCore.Authorization.AuthorizeAttribute>()
                                   .Any() ||
                               context.MethodInfo.GetCustomAttributes(true)
                                   .OfType<Microsoft.AspNetCore.Authorization.AuthorizeAttribute>()
                                   .Any();

            if (hasAuthorize)
            {
                if (operation.Security == null)
                {
                    operation.Security = new List<OpenApiSecurityRequirement>();
                }

                var _OpenApiReference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                };

                operation.Security.Add( 
                new OpenApiSecurityRequirement  
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = _OpenApiReference
                        },
                        new string[] {}
                    }
                });
            }
        }
    }
}
