using Api.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.EF.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Services
{
    public class ExchangeDataService : IExchangeDataService
    {
        private readonly IStockExchangeContext _stockExchangeContext;
        private readonly IMapper _mapper;

        public ExchangeDataService(IStockExchangeContext stockExchangeContext, IMapper mapper)
        {
            _stockExchangeContext = stockExchangeContext ?? throw new ArgumentNullException(nameof(stockExchangeContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<StockExchange>> ListExchangesAsync()
        {
            return await _stockExchangeContext.Exchanges
                .ProjectTo<StockExchange>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
