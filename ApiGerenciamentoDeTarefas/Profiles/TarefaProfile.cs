using AutoMapper;
using ApiGerenciamentoDeTarefas.Models;
using ApiGerenciamentoDeTarefas.Dtos;
using GerenciadorTarefas.Dtos;

namespace ApiGerenciamentoDeTarefas.Profiles
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            CreateMap<Tarefa, TarefaReadDto>();
            CreateMap<TarefaCreateDto, Tarefa>();
            CreateMap<TarefaUpdateDto, Tarefa>();
        }
    }
}