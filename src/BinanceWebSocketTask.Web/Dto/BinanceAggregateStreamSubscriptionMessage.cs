namespace BinanceWebSocketTask.Web.Dto
{
    public class BinanceAggregateStreamSubscriptionMessage
    {
        public string Method => "SUBSCRIBE";

        public string[] Params { get; }

        public int Id { get; } = 1;

        public BinanceAggregateStreamSubscriptionMessage(string symbol)
        {
            Params = new[] { $"{symbol}@aggTrade", $"{symbol}@depth" };
        }
    }
}
