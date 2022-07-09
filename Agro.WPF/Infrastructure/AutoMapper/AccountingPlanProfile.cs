using Agro.DAL.Entities;
using Agro.Domain.Base;
using AutoMapper;

namespace Agro.WPF.Infrastructure.AutoMapper;

public class AccountingPlanProfile : Profile
{
    public AccountingPlanProfile()
    {
        CreateMap<AccountingPlanDto, AccountingPlan>()
            .ForMember(ct=>ct.StatusId, opt=>opt.MapFrom(src=>src.Status.Id))
            .ForMember(ct => ct.Status, opt => opt.Ignore())
            .ForMember(ct => ct.ParentPlanId, opt => opt.MapFrom(src => src.ParentPlan!.Id))
            .ForMember(ct => ct.ParentPlan, opt => opt.Ignore());

        CreateMap<AccountingPlan, AccountingPlanDto>();
    }

}
