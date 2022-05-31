using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agro.Domain.Base;
using AutoMapper;
using Type = Agro.DAL.Entities.Type;

namespace Agro.WPF.Infrastructure.AutoMapper;
internal class TypeProfile : Profile
{
    public TypeProfile()
    {
        CreateMap<TypeDto, Type>().ReverseMap();
    }

}