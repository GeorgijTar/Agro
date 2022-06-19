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
            CreateMap<GroupDto, GroupDoc>().ReverseMap();
        }
     
    }
}
