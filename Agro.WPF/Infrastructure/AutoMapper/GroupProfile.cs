using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agro.DAL.Entities;
using Agro.Domain.Base;
using AutoMapper;

namespace Agro.WPF.Infrastructure.AutoMapper
{
    public class GroupProfile:Profile
    {
        public GroupProfile()
        {
            CreateMap<GroupDto, GroupDoc>()
                .ForMember(ct => ct.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(ct => ct.ParentId, opt => opt.MapFrom(src => src.ParentGroup!.Id))
                .ForMember(ct=>ct.ParentGroup, opt=>opt.Ignore())
                .ForMember(ct => ct.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(ct => ct.ChildGroups, opt => opt.MapFrom(src => src.ChildGroups));

            CreateMap<GroupDoc, GroupDto>()
                .ForMember(ct => ct.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(ct=>ct.ParentGroup, opt=>opt.MapFrom(src=>src.ParentGroup))
                .ForMember(ct=>ct.Name, opt=>opt.MapFrom(src=>src.Name))
                .ForMember(ct=>ct.ChildGroups, opt=>opt.MapFrom(src=>src.ChildGroups));

        }
     
    }
}
