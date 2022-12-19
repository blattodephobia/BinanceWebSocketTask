namespace BinanceWebSocketTask.Domain
{
    public class AggregateTradeStreamPayload
    {
        public static readonly AggregateTradeStreamPayload Null = new AggregateTradeStreamPayload();

        public DateTime EventTime { get; init; }

        public string Symbol { get; init; } = string.Empty;

        public int AggregateTradeId { get; init; }

        public decimal Price { get; init; }

        public double Quantity { get; init; }

        public uint FirstTradeId { get; init; }

        public uint LastTradeId { get; init; }

        public DateTime TradeTime { get; init; }

        public bool IsBuyerMarketMaker { get; init; }

        public bool Ignore { get; init; }
    }
}
