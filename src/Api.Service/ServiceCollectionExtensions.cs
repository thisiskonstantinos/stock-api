using Data.EF;
using Data.EF.Infrastructure;
using Data.EF.Services;
using Domain.Abstractions;
using Domain.Logic.Services;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Api.Service
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AppDb");

            services.AddDbContext<StockExchangeContext>(options =>
            {
                options.UseSqlite(connectionString);
                options.EnableSensitiveDataLogging();
            })
                .AddScoped<IStockExchangeContext, StockExchangeContext>();

            services.AddAutoMapper(expression =>
            {
                expression.AllowNullCollections = true;
            }, AppDomain.CurrentDomain.GetAssemblies());

            services
                .AddScoped<IExchangeDataService, ExchangeDataService>()
                .AddScoped<IExchangeService, ExchangeService>();

            return services;
        }
    }
}
