using FluentValidation;
using FluentValidation.AspNetCore;
using BancoDadosTest.Api.Common.Middleware;
using BancoDadosTest.Api.Models.Aluno;
using BancoDadosTest.Api.Models.Inscricao;
using BancoDadosTest.Api.Models.Turma;
using BancoDadosTest.Api.Swagger;
using BancoDadosTest.Application.UseCases;
using BancoDadosTest.Domain.Contracts.Repositories.Aluno;
using BancoDadosTest.Domain.Contracts.Repositories.Inscricao;
using BancoDadosTest.Domain.Contracts.Repositories.Turma;
using BancoDadosTest.Domain.Contracts.UseCases.Aluno;
using BancoDadosTest.Domain.Contracts.UseCases.Inscriao;
using BancoDadosTest.Domain.Contracts.UseCases.Turma;
using BancoDadosTest.Infrastructure.DbContext;
using BancoDadosTest.Infrastructure.Repositories.Aluno;
using BancoDadosTest.Infrastructure.Repositories.Inscricao;
using BancoDadosTest.Infrastructure.Repositories.Turma;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

#region :: DbContext
builder.Services.AddSingleton<IDbContext, DbContext>();
#endregion

#region :: Repository
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<ITurmaRepository, TurmaRepository>();
builder.Services.AddScoped<IInscricaoRepository, InscricaoRepository>();
#endregion

#region :: UseCase
builder.Services.AddScoped<IAlunoUseCase, AlunoUseCase>();
builder.Services.AddScoped<ITurmaUseCase, TurmaUseCase>();
builder.Services.AddScoped<IInscricaoUseCase, InscricaoUseCase>();
#endregion

#region :: MapProfile
builder.Services.AddAutoMapper(typeof(AlunoMapProfile));
builder.Services.AddAutoMapper(typeof(TurmaMapProfile));
builder.Services.AddAutoMapper(typeof(InscricaoMapProfile));
#endregion

#region :: FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<AlunoInputValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<TurmaInputValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InscricaoInputValidator>();
#endregion

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GerenciadorTurmas API", Version = "v1" });
    c.SchemaFilter<AlunoInputSchemaFilter>();
    c.SchemaFilter<TurmaInputSchemaFilter>();
    c.SchemaFilter<InscricaoInputSchemaFilter>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseErrorHandlingMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }