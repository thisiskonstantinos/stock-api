﻿using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Infrastructure
{
    public interface IExchangeDataService
    {
        Task<List<StockExchange>> ListExchangesAsync();
    }
}
