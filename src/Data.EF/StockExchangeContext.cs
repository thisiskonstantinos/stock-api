using Data.EF.Infrastructure;
using Data.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF
{
    public class StockExchangeContext : DbContext, IStockExchangeContext
    {
        public StockExchangeContext(DbContextOptions<StockExchangeContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public virtual DbSet<Market> Markets { get; set; }
        public DbSet<Broker> Brokers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Market>(entity =>
            {
                entity.HasKey(e => e.Code);
                entity.Property(e => e.CodeType).IsRequired();
                entity.Property(e => e.Name).IsRequired();

                entity.HasData(new Market { Code = 1, CodeType = CodeTypes.Bloomberg, Name = "LN" });
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.Ticker);
                entity.Property(e => e.Name).IsRequired();
                entity.HasOne(e => e.MarketFkNavigation).WithMany(e => e.StockFkNavigation);
                //entity.HasMany(e => e.ExchangeFkNavigation).WithOne(e => e.StockFkNavigation);

                entity.HasData(new Stock { Ticker = "NWG", Name = "NatWest Group plc", MarketId = 1 });
                entity.HasData(new Stock { Ticker = "AJB", Name = "AJ Bell PLC", MarketId = 1 });
                entity.HasData(new Stock { Ticker = "BA.", Name = "BAE Systems Plc", MarketId = 1 });
            });

            modelBuilder.Entity<Broker>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();

                entity.HasData(new Broker { Id = 1, Name = "John Smith Brokers Ltd" });
            });

            modelBuilder.Entity<Exchange>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.Price).IsRequired();
                entity.HasOne(e => e.BrokerFkNavigation).WithMany(e => e.ExchangeFkNavigation);
                entity.HasOne(e => e.StockFkNavigation).WithMany(e => e.ExchangeFkNavigation).HasForeignKey(e => e.Ticker);

                entity.HasData(new Exchange { Id = 1, BrokerId = 1, Ticker = "NWG", Quantity = 1, Price = 10.00M });
                entity.HasData(new Exchange { Id = 2, BrokerId = 1, Ticker = "AJB", Quantity = 5, Price = 8.99M });
                entity.HasData(new Exchange { Id = 3, BrokerId = 1, Ticker = "BA.", Quantity = 2, Price = 1.20M });
            });
        }
    }
}
