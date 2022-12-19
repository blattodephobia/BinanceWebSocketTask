using BinanceWebSocketTask.Web;

namespace BinanceWebSocketTask.Domain
{
    public class PriceCollectorUseCase : IDisposable
    {
        private readonly List<AggregateTradeStreamPayload> _collectedData = new List<AggregateTradeStreamPayload>();
        private readonly IWebSocketAdapter _webSocketInterface;

        public PriceCollectorUseCase(IWebSocketAdapter webSocketInterface)
        {
            _webSocketInterface = webSocketInterface;
            _webSocketInterface.OnPayloadReceived += WebSocketInterface_OnPayloadReceived;

            _webSocketInterface.Start();
        }

        private void WebSocketInterface_OnPayloadReceived(AggregateTradeStreamPayload obj)
        {
            _collectedData.Add(obj);
        }

        public void Dispose()
        {
            _webSocketInterface.Dispose();
        }
    }
}
