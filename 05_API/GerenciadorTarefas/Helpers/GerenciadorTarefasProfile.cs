using AutoMapper;
using GerenciadorTarefas.Enums;
using GerenciadorTarefas.Models;

namespace GerenciadorTarefas;

public class GerenciadorTarefasProfile : Profile
{
    public GerenciadorTarefasProfile()
    {
        CreateMap<Tarefa, TarefaDTO>().ForMember(des => des.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        CreateMap<TarefaDTO, Tarefa>().ForMember(des => des.Status, opt => opt.MapFrom(src => (Status)Enum.Parse(typeof(Status), src.Status!)));
    }
}
