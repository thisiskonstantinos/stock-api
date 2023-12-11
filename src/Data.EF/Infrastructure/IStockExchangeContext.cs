using Data.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Infrastructure
{
    public interface IStockExchangeContext : IDbContext
    {
        DbSet<Market> Markets { get; set; }
        DbSet<Broker> Brokers { get; set; }
        DbSet<Stock> Stocks { get; set; }
        DbSet<Exchange> Exchanges { get; set; }
    }
}
