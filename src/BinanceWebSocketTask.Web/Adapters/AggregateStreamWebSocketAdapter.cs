using BinanceWebSocketTask.Web.Dto;
using BinanceWebSocketTask.Web.Mappers;
using Newtonsoft.Json;
using System.Net.WebSockets;
using Websocket.Client;

namespace BinanceWebSocketTask.Web.Adapters
{
    public class AggregateStreamWebSocketAdapter : IAggregateStreamWebSocketAdapter
    {
        private readonly WebsocketClient _client;

        public AggregateStreamWebSocketAdapter(Uri streamEndpoint, string symbol)
        {
            _client = new WebsocketClient(new Uri(streamEndpoint, $"/stream?streams={symbol}@aggTrade"));
            _client.MessageReceived.Subscribe(OnMessageReceived);
            Symbol = symbol;
        }

        public string Symbol { get; }

        public event Action<AggregateTradeStreamPayload>? OnPayloadReceived;

        public void Dispose()
        {
            _client.Dispose();
        }

        public async Task Start()
        {
            await _client.Start();
            _client.Send(JsonConvert.SerializeObject(new BinanceAggregateStreamSubscriptionMessage(Symbol)));
        }

        public async Task Stop()
        {
            await _client.Stop(WebSocketCloseStatus.NormalClosure, string.Empty);
        }

        private void OnMessageReceived(ResponseMessage msg)
        {
            AggregateTradeStreamPayload payload = msg.Text != null
                ? JsonConvert.DeserializeObject<WebSocketResponseJsonDto<AggregateTradeStreamPayloadJsonDto>>(msg.Text)?.Data?.Map() ?? AggregateTradeStreamPayload.Null
                : AggregateTradeStreamPayload.Null;

            if (payload != AggregateTradeStreamPayload.Null) OnPayloadReceived?.Invoke(payload);
        }
    }
}
