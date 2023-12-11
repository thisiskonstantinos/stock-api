using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Models
{
    public class Exchange
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public int BrokerId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual Broker BrokerFkNavigation { get; set; }
        public virtual Stock StockFkNavigation { get; set; }
    }
}
