using BancoDadosTest.Api.Models.Inscricao;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BancoDadosTest.Api.Swagger
{
    public class InscricaoInputSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(InscricaoInput))
            {
                schema.Example = new OpenApiObject()
                {
                    ["Id"] = new OpenApiInteger(1),
                    ["AlunoId"] = new OpenApiInteger(1),
                    ["TurmaId"] = new OpenApiInteger(1),
                };
            }
        }
    }
}
