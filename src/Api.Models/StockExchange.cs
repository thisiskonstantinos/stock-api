using Newtonsoft.Json;

namespace Api.Models
{
    public class StockExchange
    {
        [JsonProperty]
        public string Ticker { get; set; }

        [JsonProperty]
        public int BrokerId { get; set; }

        [JsonProperty()]
        public decimal Quantity { get; set; }

        [JsonProperty]
        public decimal Price { get; set; }
    }
}
