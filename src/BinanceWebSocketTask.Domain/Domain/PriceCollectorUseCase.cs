using BinanceWebSocketTask.Web;
using BinanceWebSocketTask.DataAccess;

namespace BinanceWebSocketTask.Domain
{
    public class PriceCollectorUseCase : IDisposable
    {
        private readonly IAggregateStreamWebSocketAdapter _webSocketInterface;
        private readonly IAggregateTradeStreamDataAdapter _dataAdapter;

        public PriceCollectorUseCase(IAggregateStreamWebSocketAdapter webSocketInterface, IAggregateTradeStreamDataAdapter dataAdapter)
        {
            _webSocketInterface = webSocketInterface;
            _dataAdapter = dataAdapter;
            _webSocketInterface.OnPayloadReceived += WebSocketInterface_OnPayloadReceived;

            _webSocketInterface.Start();
        }

        public Task<decimal> GetDayAverageForSymbol(string symbol)
        {
            DateTime now = DateTime.Now;
            var range = new DateTimeRange(start: now - TimeSpan.FromDays(1), end: now);

            return _dataAdapter.GetAverageFor(symbol, range);
        }

        private void WebSocketInterface_OnPayloadReceived(AggregateTradeStreamPayload obj)
        {
            _dataAdapter.Save(obj);
        }

        public void Dispose()
        {
            _webSocketInterface.Dispose();
        }
    }
}
