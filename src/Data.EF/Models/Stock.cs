using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Models
{
    public class Stock
    {
        public string Ticker { get; set; }
        public int MarketId { get; set; }
        public string Name { get; set; }

        public virtual Market MarketFkNavigation { get; set; }
        public virtual ICollection<Exchange> ExchangeFkNavigation { get; set; }
    }
}
