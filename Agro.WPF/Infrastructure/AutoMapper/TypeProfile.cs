using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agro.Domain.Base;
using AutoMapper;
using TypeDoc = Agro.DAL.Entities.TypeDoc;

namespace Agro.WPF.Infrastructure.AutoMapper;
internal class TypeProfile : Profile
{
    public TypeProfile()
    {
        CreateMap<TypeDocDto, TypeDoc>().ReverseMap();
    }

}