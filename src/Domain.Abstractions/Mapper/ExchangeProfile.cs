using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Abstractions.Mapper
{
    public class ExchangeProfile : Profile
    {
        public ExchangeProfile()
        {
            CreateMap<Data.EF.Models.Exchange, Api.Models.StockExchange>()
                .ForMember(d => d.Ticker, s => s.MapFrom(s => s.Ticker))
                .ForMember(d => d.Quantity, s => s.MapFrom(s => s.Quantity))
                .ForMember(d => d.Price, s => s.MapFrom(s => s.Price))
                .ForMember(d => d.BrokerId, s => s.MapFrom(s => s.BrokerFkNavigation.Id))
                .ReverseMap();
        }
    }
}
