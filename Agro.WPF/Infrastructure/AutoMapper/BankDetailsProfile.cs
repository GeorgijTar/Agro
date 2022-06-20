
using Agro.DAL.Entities;
using Agro.Domain.Base;
using AutoMapper;

namespace Agro.WPF.Infrastructure.AutoMapper;
internal class BankDetailsProfile : Profile
{
    public BankDetailsProfile()
    {
        CreateMap<BankDetailsDto, BankDetails>().ReverseMap();
    }
}