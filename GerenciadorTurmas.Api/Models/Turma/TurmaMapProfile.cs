using AutoMapper;
using GerenciadorTurmas.Domain.Entities;

namespace GerenciadorTurmas.Api.Models.Turma
{
    public class TurmaMapProfile : Profile
    {
        public TurmaMapProfile()
        {
            CreateMap<TurmaInput, TurmaEntity>().ReverseMap();
        }
    }
}
