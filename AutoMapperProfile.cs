using AutoMapper;
using paddockCcell.DTO;
using paddockCcell.Models;

namespace paddockCcell
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ClienteDTO, Cliente>()
                .ForAllMembers(opt => opt.Condition((src, dst, srcMember) => srcMember != null));

            CreateMap<ServicoDTO, Servico>()
                .ForAllMembers(opt => opt.Condition((src, dst, srcMember) => srcMember != null));
        }
    }
}