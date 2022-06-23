

using Agro.DAL.Entities;
using Agro.Domain.Base;
using AutoMapper;

namespace Agro.WPF.Infrastructure.AutoMapper;
public class NdsProfile:Profile
{
    public NdsProfile()
    {
        CreateMap<NdsDto, Nds>().ReverseMap();
    }
    
}
