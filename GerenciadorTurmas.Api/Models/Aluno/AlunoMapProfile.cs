using AutoMapper;
using BancoDadosTest.Domain.Entities;

namespace GerenciadorTurmas.Api.Models.Aluno
{
    public class AlunoMapProfile : Profile
    {
        public AlunoMapProfile()
        {
            CreateMap<AlunoInput, AlunoEntity>()
                .ForMember(d => d.Id, s => s.MapFrom(x => x.Id))
                .ForMember(d => d.Nome, s => s.MapFrom(x => x.Nome))
                .ForMember(d => d.Usuario, s => s.MapFrom(x => x.Usuario))
                .ReverseMap()
                .ForMember(d => d.Id, s => s.MapFrom(x => x.Id))
                .ForMember(d => d.Nome, s => s.MapFrom(x => x.Nome))
                .ForMember(d => d.Usuario, s => s.MapFrom(x => x.Usuario))
                .ForMember(d => d.Senha, s => s.MapFrom(x => x.Senha));
        }
    }
}
