
using Agro.DAL.Entities;
using Agro.Domain.Base;
using AutoMapper;

namespace Agro.WPF.Infrastructure.AutoMapper;
public class UnitProfile:Profile
{
    public UnitProfile()
    {

        CreateMap<UnitOkeiDto, UnitOkei>()
            .ForMember(ct=>ct.StatusId, opt=>opt.MapFrom(src=>src.Status.Id))
            .ForMember(ct=>ct.Status, opt=>opt.Ignore());

        CreateMap<UnitOkei, UnitOkeiDto>();
    }
}
