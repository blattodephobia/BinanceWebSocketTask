using Newtonsoft.Json;

namespace BinanceWebSocketTask.Web.Dto
{
    public class AggregateTradeStreamPayloadJsonDto
    {
        [JsonProperty("e")]
        public string EventType { get; set; } = string.Empty;

        [JsonProperty("E")]
        public long EventTime { get; set; }

        [JsonProperty("s")]
        public string Symbol { get; set; } = string.Empty;

        [JsonProperty("a")]
        public int AggregateTradeId { get; set; }

        [JsonProperty("p")]
        public string Price { get; set; } = string.Empty;

        [JsonProperty("q")]
        public string Quantity { get; set; } = string.Empty;

        [JsonProperty("f")]
        public uint FirstTradeId { get; set; }

        [JsonProperty("l")]
        public uint LastTradeId { get; set; }

        [JsonProperty("T")]
        public long TradeTime { get; set; }

        [JsonProperty("m")]
        public bool IsBuyerMarketMaker { get; set; }

        [JsonProperty("M")]
        public bool Ignore { get; set; }
    }
}
