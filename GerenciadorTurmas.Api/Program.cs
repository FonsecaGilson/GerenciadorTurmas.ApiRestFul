using FluentValidation;
using FluentValidation.AspNetCore;
using GerenciadorTurmas.Api.Models.Aluno;
using GerenciadorTurmas.Api.Models.Inscricao;
using GerenciadorTurmas.Api.Models.Turma;
using GerenciadorTurmas.Api.Swagger;
using GerenciadorTurmas.Application.UseCases;
using GerenciadorTurmas.Domain.Contracts.Repositories.Aluno;
using GerenciadorTurmas.Domain.Contracts.Repositories.Inscricao;
using GerenciadorTurmas.Domain.Contracts.Repositories.Turma;
using GerenciadorTurmas.Domain.Contracts.UseCases.Aluno;
using GerenciadorTurmas.Domain.Contracts.UseCases.Inscriao;
using GerenciadorTurmas.Domain.Contracts.UseCases.Turma;
using GerenciadorTurmas.Infrastructure.DbContext;
using GerenciadorTurmas.Infrastructure.Repositories.Aluno;
using GerenciadorTurmas.Infrastructure.Repositories.Inscricao;
using GerenciadorTurmas.Infrastructure.Repositories.Turma;
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
