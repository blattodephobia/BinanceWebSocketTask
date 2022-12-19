namespace BinanceWebSocketTask.DataAccess
{
    public interface IAggregateTradeStreamDataAdapter
    {
        void Save(AggregateTradeStreamPayload payload);
        Task<decimal> GetAverageFor(string symbol, DateTimeRange period);
    }
}
