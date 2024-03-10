using GerenciadorTurmas.Api.Models.Aluno;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GerenciadorTurmas.Api.Swagger
{
    public class AlunoInputSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(AlunoInput))
            {
                schema.Example = new OpenApiObject()
                {
                    ["Id"] = new OpenApiInteger(1),
                    ["Nome"] = new OpenApiString("Maria da Silva"),
                    ["Usuario"] = new OpenApiString("Maria"),
                    ["Senha"] = new OpenApiPassword("Maria12345@"),
                };
            }
        }
    }
}
