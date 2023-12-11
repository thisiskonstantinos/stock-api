using Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Service.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class ExchangeController : ControllerBase
    {
        private readonly ILogger<ExchangeController> _logger;
        private readonly IExchangeService _exchangeService;

        public ExchangeController(
            ILogger<ExchangeController> logger,
            IExchangeService exchangeService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _exchangeService = exchangeService ?? throw new ArgumentNullException(nameof(exchangeService));
        }

        /// <summary>
        /// This endpoint lists all exchanges in the storage.
        /// </summary>
        /// <returns>Returns an array with exchanges.</returns>
        [HttpGet]
        [Route("[controller]/ListAll")]
        public async Task<IActionResult> ListExchangesAsync()
        {
            _logger.LogInformation($"Entering {nameof(ListExchangesAsync)}");

            // needs try/catch statement for exceptions
            var results = await _exchangeService.ListExchanges();
            return Ok(results);
        }
    }
}
