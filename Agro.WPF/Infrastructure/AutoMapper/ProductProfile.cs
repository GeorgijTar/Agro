
using Agro.DAL.Entities;
using Agro.Domain.Base;
using AutoMapper;

namespace Agro.WPF.Infrastructure.AutoMapper;
public class ProductProfile:Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDto, Product>()
            .ForMember(ct => ct.StatusId, opt => opt.MapFrom(src => src.Status.Id))
            .ForMember(ct => ct.Status, opt => opt.Ignore())
            .ForMember(ct => ct.GroupId, opt => opt.MapFrom(src => src.Group.Id))
            .ForMember(ct => ct.Group, opt => opt.Ignore())
            .ForMember(ct => ct.TypeId, opt => opt.MapFrom(src => src.Type.Id))
            .ForMember(ct => ct.Type, opt => opt.Ignore())
            .ForMember(ct => ct.UnitId, opt => opt.MapFrom(src => src.Unit.Id))
            .ForMember(ct => ct.Unit, opt => opt.Ignore())
            .ForMember(ct => ct.NdsId, opt => opt.MapFrom(src => src.Nds.Id))
            .ForMember(ct => ct.Nds, opt => opt.Ignore());

        CreateMap<Product, ProductDto>();
    }
}
