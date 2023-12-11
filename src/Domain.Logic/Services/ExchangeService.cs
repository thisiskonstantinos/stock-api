using Api.Models;
using Data.EF.Infrastructure;
using Domain.Abstractions;

namespace Domain.Logic.Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly IExchangeDataService _exchangeDataService;

        public ExchangeService(IExchangeDataService exchangeDataService)
        {
            _exchangeDataService = exchangeDataService ?? throw new ArgumentNullException(nameof(exchangeDataService));
        }

        public async Task<List<StockExchange>> ListExchanges()
        {
            return await _exchangeDataService.ListExchangesAsync();
        }

    }
}
