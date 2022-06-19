
using Agro.DAL.Entities;
using Agro.Domain.Base;
using AutoMapper;

namespace Agro.WPF.Infrastructure.AutoMapper
{
    public class StatusProfile:Profile
    {
        public StatusProfile()
        {
            CreateMap<StatusDto, Status>().ReverseMap();
        }
    }
}
