using GerenciadorTurmas.Api.Models.Turma;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GerenciadorTurmas.Api.Swagger
{
    public class TurmaInputSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(TurmaInput))
            {
                schema.Example = new OpenApiObject()
                {
                    ["Id"] = new OpenApiInteger(1),
                    ["Turma"] = new OpenApiString("Fisíca"),
                    ["Ano"] = new OpenApiInteger(2024),
                };
            }
        }
    }
}
