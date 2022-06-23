
using Agro.DAL.Entities;
using Agro.Domain.Base;
using AutoMapper;

namespace Agro.WPF.Infrastructure.AutoMapper;
internal class BankDetailsProfile : Profile
{
    public BankDetailsProfile()
    {
        CreateMap<BankDetailsDto, BankDetails>()
            .ForMember(ct=>ct.StatusId, opt=>opt.MapFrom(src=>src.Status.Id))
            .ForMember(ct=>ct.Status, opt=>opt.Ignore())
            .ForMember(ct => ct.CounterpartyId, opt => opt.MapFrom(src => src.Counterparty.Id))
            .ForMember(ct => ct.Counterparty, opt => opt.Ignore());


        CreateMap<BankDetails, BankDetailsDto>();
    }
}