using BinanceWebSocketTask.Domain;

namespace BinanceWebSocketTask.Web
{
    public interface IAggregateStreamWebSocketAdapter : IDisposable
    {
        Task Start();
        event Action<AggregateTradeStreamPayload> OnPayloadReceived;
        Task Stop();
    }
}