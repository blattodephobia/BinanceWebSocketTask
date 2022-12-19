using BinanceWebSocketTask.Domain;

namespace BinanceWebSocketTask.Web
{
    public interface IWebSocketAdapter : IDisposable
    {
        Task Start();
        event Action<AggregateTradeStreamPayload> OnPayloadReceived;
        Task Stop();
    }
}