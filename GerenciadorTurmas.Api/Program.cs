using FluentValidation;
using GerenciadorTurmas.Api.Models.Aluno;
using GerenciadorTurmas.Application.UseCases;
using GerenciadorTurmas.Domain.Contracts.Repositories.Aluno;
using GerenciadorTurmas.Domain.Contracts.UseCases.Aluno;
using GerenciadorTurmas.Infrastructure.DbContext;
using GerenciadorTurmas.Infrastructure.Repositories.Aluno;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using GerenciadorTurmas.Api.Swagger;
using GerenciadorTurmas.Infrastructure.Repositories.Turma;
using GerenciadorTurmas.Domain.Contracts.Repositories.Turma;
using GerenciadorTurmas.Domain.Contracts.UseCases.Turma;
using GerenciadorTurmas.Api.Models.Turma;

var builder = WebApplication.CreateBuilder(args);

#region :: DbContext
builder.Services.AddSingleton<IDbContext, DbContext>();
#endregion

#region :: Repository
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<ITurmaRepository, TurmaRepository>();
#endregion

#region :: UseCase
builder.Services.AddScoped<IAlunoUseCase, AlunoUseCase>();
builder.Services.AddScoped<ITurmaUseCase, TurmaUseCase>();
#endregion

#region :: MapProfile
builder.Services.AddAutoMapper(typeof(AlunoMapProfile));
builder.Services.AddAutoMapper(typeof(TurmaMapProfile));
#endregion

#region :: FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<AlunoInputValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<TurmaInputValidator>();
#endregion

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GerenciadorTurmas API", Version = "v1" });
    c.SchemaFilter<AlunoInputSchemaFilter>();
    c.SchemaFilter<TurmaInputSchemaFilter>();
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
