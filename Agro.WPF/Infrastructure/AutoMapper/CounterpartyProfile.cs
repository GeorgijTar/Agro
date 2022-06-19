
using Agro.DAL.Entities;
using Agro.Domain.Base;
using AutoMapper;

namespace Agro.WPF.Infrastructure.AutoMapper;
public class CounterpartyProfile:Profile
{
    public CounterpartyProfile()
    {
        CreateMap<CounterpartyDto, Counterparty>()
            //.ForMember(dest=>dest.Inn, opt=>opt.MapFrom(src=>src.Inn))
            //.ForMember(dest => dest.Kpp, opt => opt.MapFrom(src => src.Kpp))
            //.ForMember(dest => dest.Okpo, opt => opt.MapFrom(src => src.Okpo))
            //.ForMember(dest => dest.Ogrn, opt => opt.MapFrom(src => src.Ogrn))
            //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //.ForMember(dest => dest.PayName, opt => opt.MapFrom(src => src.PayName))
            //.ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            //.ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.Group))
            //.ForMember(dest => dest.TypeDoc, opt => opt.MapFrom(src => src.TypeDoc))
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();
    }
}
