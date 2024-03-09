using FluentValidation;
using GerenciadorTurmas.Api.Common;
using GerenciadorTurmas.Api.Models.Aluno;
using GerenciadorTurmas.Application.UseCases;
using GerenciadorTurmas.Domain.Contracts.Repositories.Aluno;
using GerenciadorTurmas.Domain.Contracts.UseCases.Aluno;
using GerenciadorTurmas.Infrastructure.DbContext;
using GerenciadorTurmas.Infrastructure.Repositories.Aluno;
using Microsoft.AspNetCore.SignalR;
using System.Globalization;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDbContext, DbContext>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IAlunoUseCase, AlunoUseCase>();
builder.Services.AddScoped<IValidator, AlunoInputValidator>();

builder.Services.AddAutoMapper(typeof(AlunoMapProfile));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseMiddleware<ValidationMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
