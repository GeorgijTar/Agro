
using Agro.DAL.Entities;
using Agro.Domain.Base;
using AutoMapper;

namespace Agro.WPF.Infrastructure.AutoMapper;
public class CounterpartyProfile:Profile
{

    public CounterpartyProfile()
    {
        CreateMap<CounterpartyDto, Counterparty>()
            .ForMember(ct => ct.TypeDocId, opt => opt.MapFrom(src => src.TypeDoc.Id))
            .ForMember(ct => ct.TypeDoc, opt => opt.Ignore())
            .ForMember(ct => ct.StatusId, opt => opt.MapFrom(src => src.Status.Id))
            .ForMember(ct => ct.Status, opt => opt.Ignore())
            .ForMember(ct => ct.GroupId, opt => opt.MapFrom(src => src.Group!.Id))
            .ForMember(ct => ct.Group, opt => opt.Ignore());

        CreateMap<Counterparty, CounterpartyDto>();
    }
}
