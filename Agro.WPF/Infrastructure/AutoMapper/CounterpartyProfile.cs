
using Agro.DAL.Entities;
using Agro.Domain.Base;
using AutoMapper;

namespace Agro.WPF.Infrastructure.AutoMapper;
public class CounterpartyProfile:Profile
{
    public CounterpartyProfile()
    {
        CreateMap<CounterpartyDto, Counterparty>().ReverseMap();
    }
}
